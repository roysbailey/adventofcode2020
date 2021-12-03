using adventofcode2020.Puzzles.Day1;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace adventofcode2020.Puzzles.Day5
{
    public class Day5Engine : IDay5Engine
    {
        public int Execute(IEnumerable<string> boardingCardBarcodes)
        {
            List<BoardingCard> boardingCards = BoardingCardsFromBarCodes(boardingCardBarcodes);
            var maxId = boardingCards.Select(bc => bc.SeatId).Max();

            return maxId;
        }

        public int Execute2(IEnumerable<string> boardingCardBarcodes)
        {
            var boardingCards = new List<BoardingCard>();
            foreach (var boardingCardBarcode in boardingCardBarcodes)
                boardingCards.Add(new BoardingCard(boardingCardBarcode));

            var seatIdsToCheck = boardingCards
                    .Where(bc => bc.Row != 0 && bc.Row != 127)
                    .OrderBy(bc => bc.SeatId)
                    .Select(bc => bc.SeatId)
                    .ToArray();

            bool found=false;
            var yourSeat = -1;
            for (int i = 0; i < seatIdsToCheck.Length - 1 && !found; i++)
            {
                found = seatIdsToCheck[i] == seatIdsToCheck[i + 1] - 2;
                if (found)
                    yourSeat = seatIdsToCheck[i] + 1;
            }

            return yourSeat;
        }

        private static List<BoardingCard> BoardingCardsFromBarCodes(IEnumerable<string> boardingCardBarcodes)
        {
            var boardingCards = new List<BoardingCard>();
            foreach (var boardingCardBarcode in boardingCardBarcodes)
                boardingCards.Add(new BoardingCard(boardingCardBarcode));
            return boardingCards;
        }

    }

    public class BoardingCard
    {
        private string _boardingCardBarCode;

        public int Row
        {
            get
            {
                return PosFromBarCode(_boardingCardBarCode.ToUpper(), 0, 0, 127);
            }
        }
        public int Col
        {
            get
            {
                return PosFromBarCode(_boardingCardBarCode, 7, 0, 7);
            }
        }
        public int SeatId
        {
            get
            {
                return Row * 8 + Col;
            }
        }

        public BoardingCard(string encodedBoardingCard)
        {
            _boardingCardBarCode = encodedBoardingCard;
        }

        private int PosFromBarCode(string barCode, int offset, int min, int max)
        {
            int range = (int)Math.Ceiling(((double)max - (double)min) / 2);
            var barCodeChar = barCode[offset];

            switch(barCodeChar)
            {
                case 'F':
                case 'L':
                    if (range == 1)
                        return min;
                    else
                        return PosFromBarCode(barCode, offset + 1, min, min + range);
                    break;

                case 'B':
                case 'R':
                    if (range == 1)
                    {
                        if (barCodeChar == 'B' && max == 127)
                            return max;
                        else if (barCodeChar == 'R' && max == 7)
                            return max;
                        else
                            return max - 1;
                    }
                    else
                        return PosFromBarCode(barCode, offset + 1, min + range, max);
                    break;
            }

            return -1;
        }
    }
}
