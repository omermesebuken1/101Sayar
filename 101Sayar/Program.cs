using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;



public class Piece
{
    public int? Number { get; set; }
    public string Color { get; set; }
    public bool IsOkey { get; set; }
    public bool IsFakeOkey { get; set; }

}

public class Set
{
    public int Number { get; set; }
    public string Color1 { get; set; }
    public string Color2 { get; set; }
    public string Color3 { get; set; }
    public string Color4 { get; set; }
    public int OkeyUsed { get; set; }
}



public class MainClass
{

    public List<Piece> createdPieces = new List<Piece>();
    public List<Piece> playersPieces = new List<Piece>();
    public List<Piece> redPieces = new List<Piece>();
    public List<Piece> bluePieces = new List<Piece>();
    public List<Piece> yellowPieces = new List<Piece>();
    public List<Piece> greenPieces = new List<Piece>();
    public List<Piece> denemeList = new List<Piece>();
    public List<Piece> okeyList = new List<Piece>();
    public List<Piece> tmpRedList = new List<Piece>();
    public List<Piece> tmpBlueList = new List<Piece>();
    public List<Piece> tmpYellowList = new List<Piece>();
    public List<Piece> tmpGreenList = new List<Piece>();

    List<Set> SetList = new List<Set>();

    List<(int?, int?, int?)> rangePacks = new List<(int?, int?, int?)>();

    List<(int?, int?, int?)> redRangePacks = new List<(int?, int?, int?)>();
    List<(int?, int?, int?)> blueRangePacks = new List<(int?, int?, int?)>();
    List<(int?, int?, int?)> yellowRangePacks = new List<(int?, int?, int?)>();
    List<(int?, int?, int?)> greenRangePacks = new List<(int?, int?, int?)>();




    public int okeyCounter;


    Random rand = new Random();

    public void CreatingPieces()
    {
        Piece tmpPiece;

        for (int k = 0; k < 4; k++) // colors
        {
            for (int j = 0; j < 2; j++) // repeat
            {
                for (int i = 0; i < 13; i++) // numbers
                {

                    tmpPiece = new Piece();

                    tmpPiece.Number = i + 1;

                    switch (k)
                    {
                        case 0:
                            {
                                tmpPiece.Color = "Red";
                                break;
                            }
                        case 1:
                            {
                                tmpPiece.Color = "Blue";
                                break;
                            }
                        case 2:
                            {
                                tmpPiece.Color = "Yellow";
                                break;
                            }
                        case 3:
                            {
                                tmpPiece.Color = "Green";
                                break;
                            }


                    }



                    tmpPiece.IsOkey = false;
                    tmpPiece.IsFakeOkey = false;

                    createdPieces.Add(tmpPiece);

                }

            }

        }

        tmpPiece = new Piece();
        tmpPiece.Color = null;
        tmpPiece.Number = null;
        tmpPiece.IsOkey = false;
        tmpPiece.IsFakeOkey = true;

        createdPieces.Add(tmpPiece);

        tmpPiece = new Piece();
        tmpPiece.Color = null;
        tmpPiece.Number = null;
        tmpPiece.IsOkey = false;
        tmpPiece.IsFakeOkey = true;

        createdPieces.Add(tmpPiece);


    }

    public void WriteCreatedPieces()
    {
        foreach (Piece i in createdPieces)
        {
            Console.WriteLine($"Number: {i.Number}, Color: {i.Color}");
        }

        Console.WriteLine(createdPieces.Count);
    }

    public void ShufflePieces()
    {
        createdPieces = createdPieces.OrderBy(x => rand.Next()).ToList();
    }

    public void PickOkeyRandomly()
    {

        int r = rand.Next(0, 106);

        if (createdPieces[r].IsFakeOkey == true)
        {

            do
            {
                r = rand.Next(0, 106);

            } while (createdPieces[r].IsFakeOkey != false);

        }


        string col = createdPieces[r].Color;
        int? num = createdPieces[r].Number;

        foreach (var item in createdPieces)
        {

            if (item.Color == col && item.Number == num)
            {
                item.IsOkey = true;

            }

        }


    }

    public void ShowOkey()
    {
        Piece result = createdPieces.Find(x => x.IsOkey == true);
        int okeysIndex = createdPieces.FindIndex(x => x.IsOkey == true);

        if (result != null)
        {
            Console.WriteLine($"OKEY's Number: {result.Number}, Color: {result.Color}, position: {okeysIndex}");
            result.IsOkey = false;
        }

    }

    public void FindFakeOkeysAndApplyValue()
    {

        Piece okeyOne = createdPieces.Find(x => x.IsOkey == true);

        for (int i = 0; i < 106; i++)
        {

            if (createdPieces[i].IsFakeOkey)
            {
                //Console.WriteLine($"Fake OKEY's Position: {i}");

                createdPieces[i].Color = okeyOne.Color;
                createdPieces[i].Number = okeyOne.Number;


            }

        }


    }

    public void PreparePlayersPieces()
    {

        for (int i = 0; i < 21; i++)
        {

            playersPieces.Add(createdPieces[i]);


        }

    }

    public void ArrangePlayerPieces()
    {
        playersPieces = playersPieces.OrderBy(x => x.Number).ToList();
        playersPieces = playersPieces.OrderBy(x => x.Color).ToList();
    }

    public void ShowPlayersPieces()
    {
        Console.WriteLine("PLAYER'S PIECES");
        Console.WriteLine("");

        foreach (Piece item in playersPieces)
        {


            switch (item.Color)
            {
                case "Red":
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    }
                case "Blue":
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                    }
                case "Yellow":
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    }
                case "Green":
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    }
            }

            if (item.IsOkey)
            {

                Console.Write($"{item.Number}(OK)   ");
                Console.ForegroundColor = ConsoleColor.White;

            }
            else if (item.IsFakeOkey)
            {

                Console.Write($"{item.Number}(FOK)   ");
                Console.ForegroundColor = ConsoleColor.White;

            }
            else
            {
                Console.Write($"{item.Number}   ");
                Console.ForegroundColor = ConsoleColor.White;

            }



        }


    }

    public void ShowPlayersPiecesInRows()
    {
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("    Player's Pieces");

        Console.WriteLine("");
        Console.WriteLine("");


        Console.Write("    ");

        foreach (Piece item in playersPieces)
        {

            if (item.Color == "Red")
            {

                Console.ForegroundColor = ConsoleColor.Red;

                if (item.IsOkey)
                {

                    Console.Write($"{item.Number}(OK)   ");
                    Console.ForegroundColor = ConsoleColor.White;

                }
                else if (item.IsFakeOkey)
                {

                    Console.Write($"{item.Number}(FOK)   ");
                    Console.ForegroundColor = ConsoleColor.White;

                }
                else
                {
                    Console.Write($"{item.Number}   ");
                    Console.ForegroundColor = ConsoleColor.White;

                }
            }

        }

        Console.WriteLine("");
        Console.WriteLine("");

        Console.Write("    ");

        foreach (Piece item in playersPieces)
        {

            if (item.Color == "Blue")
            {

                Console.ForegroundColor = ConsoleColor.Cyan;

                if (item.IsOkey)
                {

                    Console.Write($"{item.Number}(OK)   ");
                    Console.ForegroundColor = ConsoleColor.White;

                }
                else if (item.IsFakeOkey)
                {

                    Console.Write($"{item.Number}(FOK)   ");
                    Console.ForegroundColor = ConsoleColor.White;

                }
                else
                {
                    Console.Write($"{item.Number}   ");
                    Console.ForegroundColor = ConsoleColor.White;

                }
            }

        }

        Console.WriteLine("");
        Console.WriteLine("");

        Console.Write("    ");

        foreach (Piece item in playersPieces)
        {

            if (item.Color == "Yellow")
            {

                Console.ForegroundColor = ConsoleColor.Yellow;

                if (item.IsOkey)
                {

                    Console.Write($"{item.Number}(OK)   ");
                    Console.ForegroundColor = ConsoleColor.White;

                }
                else if (item.IsFakeOkey)
                {

                    Console.Write($"{item.Number}(FOK)   ");
                    Console.ForegroundColor = ConsoleColor.White;

                }
                else
                {
                    Console.Write($"{item.Number}   ");
                    Console.ForegroundColor = ConsoleColor.White;

                }
            }

        }

        Console.WriteLine("");
        Console.WriteLine("");

        Console.Write("    ");

        foreach (Piece item in playersPieces)
        {

            if (item.Color == "Green")
            {

                Console.ForegroundColor = ConsoleColor.Green;

                if (item.IsOkey)
                {

                    Console.Write($"{item.Number}(OK)   ");
                    Console.ForegroundColor = ConsoleColor.White;

                }
                else if (item.IsFakeOkey)
                {

                    Console.Write($"{item.Number}(FOK)   ");
                    Console.ForegroundColor = ConsoleColor.White;

                }
                else
                {
                    Console.Write($"{item.Number}   ");
                    Console.ForegroundColor = ConsoleColor.White;

                }
            }

        }

        Console.WriteLine("");
        Console.WriteLine("");

    }

    public void SeperateColorsOfPlayersPieces()
    {

        var tmpList = playersPieces.FindAll(x => x.Color == "Red");

        foreach (var item in tmpList)
        {
            redPieces.Add(item);
        }

        tmpList.Clear();

        tmpList = playersPieces.FindAll(x => x.Color == "Blue");

        foreach (var item in tmpList)
        {
            bluePieces.Add(item);
        }

        tmpList.Clear();

        tmpList = playersPieces.FindAll(x => x.Color == "Yellow");

        foreach (var item in tmpList)
        {

            yellowPieces.Add(item);
        }

        tmpList.Clear();

        tmpList = playersPieces.FindAll(x => x.Color == "Green");

        foreach (var item in tmpList)
        {
            greenPieces.Add(item);
        }

        tmpList.Clear();


    }

    public List<(int?, int?, int?)> CleanUpRuns(List<(int?, int?, int?)> tmpList)
    {

        for (int i = 0; i < tmpList.Count; i++)
        {
            for (int y = i + 1; y < tmpList.Count; y++)
            {
                if (tmpList[i].Item1 == tmpList[y].Item1 &&
                    tmpList[i].Item2 == tmpList[y].Item2 &&
                    tmpList[i].Item3 != tmpList[y].Item3)
                {
                    if (tmpList[i].Item3 < tmpList[y].Item3)
                    {
                        tmpList[y] = (0, 0, 0);
                    }
                    else
                    {
                        tmpList[i] = (0, 0, 0);
                    }

                }
                else if (tmpList[i].Item1 == tmpList[y].Item1 &&
                    tmpList[i].Item2 == tmpList[y].Item2 &&
                    tmpList[i].Item3 == tmpList[y].Item3)
                {
                    tmpList[y] = (0, 0, 0);
                }

            }
        }

        return tmpList;

    }

    public void WriteRuns(List<(int?, int?, int?)> tmpList1)
    {
        foreach (var rangePack in tmpList1)
        {
            if (rangePack.Item1 != 0 && rangePack.Item2 != 0)
            {
                
                Console.WriteLine($"[ {rangePack.Item1} - {rangePack.Item2} ]\t\tOkey Used:{rangePack.Item3}");



            }

        }
    }

    public void FindRuns()
    {

        Console.WriteLine("");
        Console.WriteLine("");

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Seriler");

        Console.WriteLine("");
        Console.WriteLine("");

        Console.ForegroundColor = ConsoleColor.Red;
        redRangePacks = ChooseTheWayToCalculateRuns(redPieces);
        redRangePacks = CleanUpRuns(redRangePacks);
        WriteRuns(redRangePacks);
        rangePacks.Clear();
        Console.WriteLine("");


        Console.ForegroundColor = ConsoleColor.Cyan;
        blueRangePacks = ChooseTheWayToCalculateRuns(bluePieces);
        blueRangePacks = CleanUpRuns(blueRangePacks);
        WriteRuns(blueRangePacks);
        rangePacks.Clear();
        Console.WriteLine("");


        Console.ForegroundColor = ConsoleColor.Yellow;
        yellowRangePacks = ChooseTheWayToCalculateRuns(yellowPieces);
        yellowRangePacks = CleanUpRuns(yellowRangePacks);
        WriteRuns(yellowRangePacks);
        rangePacks.Clear();
        Console.WriteLine("");


        Console.ForegroundColor = ConsoleColor.Green;
        greenRangePacks = ChooseTheWayToCalculateRuns(greenPieces);
        greenRangePacks = CleanUpRuns(greenRangePacks);
        WriteRuns(greenRangePacks);
        rangePacks.Clear();
        Console.WriteLine("");

    }

    public void FindOkeyCount()
    {
        okeyList.Clear();
        okeyCounter = 0;
        Piece okeyPiece;

        foreach (var item in playersPieces)
        {
            if (item.IsOkey == true)
            {
                okeyPiece = new Piece();
                okeyPiece.Color = item.Color;
                okeyPiece.Number = -5;
                okeyPiece.IsOkey = true;
                okeyPiece.IsFakeOkey = false;
                okeyList.Add(okeyPiece);
                okeyCounter++;
            }
        }

        //manuel add 2 okey

        //for (int i = 0; i < 2; i++)
        //{
        //    okeyPiece = new Piece();
        //    okeyPiece.Color = null;
        //    okeyPiece.Number = -5;
        //    okeyPiece.IsOkey = true;
        //    okeyPiece.IsFakeOkey = false;
        //    okeyList.Add(okeyPiece);
        //    okeyCounter++;

        //}

    }

    public List<(int?, int?, int?)> ChooseTheWayToCalculateRuns(List<Piece> piecesOfColor)
    {
        switch (okeyCounter)
        {
            case 0:

                RangePacksWithoutOkey(piecesOfColor);

                break;

            case 1:

                RangePacksWithoutOkey(piecesOfColor);
                RangePacksOneOkey(piecesOfColor);

                break;


            case 2:

                RangePacksWithoutOkey(piecesOfColor);
                RangePacksOneOkey(piecesOfColor);
                RangePacksTwoOkey(piecesOfColor);

                break;

        }

        return rangePacks;
    }

    public List<(int?, int?, int?)> RangePacksTwoOkey(List<Piece> piecesOfColor)
    {

        foreach (var item in piecesOfColor)
        {
            if (item.IsOkey == false)
            {
                denemeList.Add(item);
            }

        }

        if (denemeList.Count <= 2)
        {
            goto yeterliTasYok;
        }

        int? startNumber = denemeList[0].Number;

        int? endNumber = 0;

        //Console.WriteLine("okey counter: " + okeyCounter);


        denemeList.Add(okeyList[0]);
        denemeList.Add(okeyList[1]);

        for (int y = 1; y <= 13; y++)
        {

            okeyList[0].Number = y;

            for (int k = 1; k <= 13; k++)
            {

                okeyList[1].Number = k;

                denemeList = denemeList.OrderBy(x => x.Number).ToList();

                startNumber = denemeList[0].Number;

                endNumber = 0;


                //Console.WriteLine("");
                //foreach (var item in denemeList)
                //{
                //    Console.Write($"{item.Number} ");
                //}
                //Console.WriteLine("");



                for (int i = 0; i <= denemeList.Count; i++)
                {

                    if (i + 1 < denemeList.Count)
                    {
                        if (denemeList[i + 1].Number - denemeList[i].Number == 1)
                        {
                            endNumber = denemeList[i + 1].Number;
                        }
                        else if (denemeList[i + 1].Number - denemeList[i].Number == 0)
                        {
                            endNumber = denemeList[i + 1].Number;
                        }
                        else
                        {
                            if (endNumber - startNumber >= 2) // check if the range has 3 or more elements
                            {
                                rangePacks.Add((startNumber, endNumber, 2));
                            }

                            startNumber = denemeList[i + 1].Number;
                        }

                    }
                    else if (i + 1 == denemeList.Count) //last item on the list
                    {

                        if (denemeList[i].Number - denemeList[i - 1].Number == 1)
                        {

                            endNumber = denemeList[i].Number;
                            if (endNumber - startNumber >= 2) // check if the range has 3 or more elements
                            {
                                rangePacks.Add((startNumber, endNumber, 2));
                            }

                        }
                        else if (denemeList[i].Number - denemeList[i - 1].Number == 0)
                        {
                            endNumber = denemeList[i].Number;

                            if (endNumber - startNumber >= 2) // check if the range has 3 or more elements
                            {
                                rangePacks.Add((startNumber, endNumber, 2));
                            }
                        }


                    }


                }


            }

        }




    yeterliTasYok:

        denemeList.Clear();

        return rangePacks;



    }

    public List<(int?, int?, int?)> RangePacksOneOkey(List<Piece> piecesOfColor)
    {

        foreach (var item in piecesOfColor)
        {
            if (item.IsOkey == false)
            {
                denemeList.Add(item);
            }

        }

        if (denemeList.Count <= 2)
        {
            goto yeterliTasYok;
        }

        int? startNumber = denemeList[0].Number;

        int? endNumber = 0;

        //Console.WriteLine("okey counter: " + okeyCounter);

        denemeList.Add(okeyList[0]);

        for (int y = 1; y <= 13; y++)
        {

            okeyList[0].Number = y;

            denemeList = denemeList.OrderBy(x => x.Number).ToList();

            startNumber = denemeList[0].Number;

            endNumber = 0;


            //Console.WriteLine("");
            //foreach (var item in denemeList)
            //{
            //    Console.Write($"{item.Number} ");
            //}
            //Console.WriteLine("");



            for (int i = 0; i <= denemeList.Count; i++)
            {

                if (i + 1 < denemeList.Count)
                {
                    if (denemeList[i + 1].Number - denemeList[i].Number == 1)
                    {
                        endNumber = denemeList[i + 1].Number;
                    }
                    else if (denemeList[i + 1].Number - denemeList[i].Number == 0)
                    {
                        endNumber = denemeList[i + 1].Number;
                    }
                    else
                    {
                        if (endNumber - startNumber >= 2) // check if the range has 3 or more elements
                        {
                            rangePacks.Add((startNumber, endNumber, 1));
                        }

                        startNumber = denemeList[i + 1].Number;
                    }

                }
                else if (i + 1 == denemeList.Count) //last item on the list
                {

                    if (denemeList[i].Number - denemeList[i - 1].Number == 1)
                    {

                        endNumber = denemeList[i].Number;
                        if (endNumber - startNumber >= 2) // check if the range has 3 or more elements
                        {
                            rangePacks.Add((startNumber, endNumber, 1));
                        }

                    }
                    else if (denemeList[i].Number - denemeList[i - 1].Number == 0)
                    {
                        endNumber = denemeList[i].Number;

                        if (endNumber - startNumber >= 2) // check if the range has 3 or more elements
                        {
                            rangePacks.Add((startNumber, endNumber, 1));
                        }
                    }


                }


            }




        }

    yeterliTasYok:

        denemeList.Clear();

        return rangePacks;

    }

    public List<(int?, int?, int?)> RangePacksWithoutOkey(List<Piece> piecesOfColor)
    {

        foreach (var item in piecesOfColor)
        {
            if (item.IsOkey == false)
            {
                denemeList.Add(item);
            }

        }

        if (denemeList.Count <= 2)
        {
            goto yeterliTasYok2;
        }

        int? startNumber = denemeList[0].Number;

        int? endNumber = 0;


        startNumber = denemeList[0].Number;

        endNumber = 0;


        for (int i = 0; i <= denemeList.Count; i++)
        {

            if (i + 1 < denemeList.Count)
            {
                if (denemeList[i + 1].Number - denemeList[i].Number == 1)
                {
                    endNumber = denemeList[i + 1].Number;
                }
                else if (denemeList[i + 1].Number - denemeList[i].Number == 0)
                {
                    endNumber = denemeList[i + 1].Number;
                }
                else
                {
                    if (endNumber - startNumber >= 2) // check if the range has 3 or more elements
                    {
                        rangePacks.Add((startNumber, endNumber, 0));
                    }

                    startNumber = denemeList[i + 1].Number;
                }

            }
            else if (i + 1 == denemeList.Count) //last item on the list
            {

                if (denemeList[i].Number - denemeList[i - 1].Number == 1)
                {

                    endNumber = denemeList[i].Number;
                    if (endNumber - startNumber >= 2) // check if the range has 3 or more elements
                    {
                        rangePacks.Add((startNumber, endNumber, 0));
                    }

                }
                else if (denemeList[i].Number - denemeList[i - 1].Number == 0)
                {
                    endNumber = denemeList[i].Number;

                    if (endNumber - startNumber >= 2) // check if the range has 3 or more elements
                    {
                        rangePacks.Add((startNumber, endNumber, 0));
                    }
                }


            }


        }




    yeterliTasYok2:

        denemeList.Clear();

        return rangePacks;



    }

    public void FindSetsWithoutOkey()
    {

        Set tmpSet;


        foreach (var item in redPieces)
        {
            if (item.IsOkey == false)
            {
                tmpRedList.Add(item);
            }

        }

        foreach (var item in bluePieces)
        {
            if (item.IsOkey == false)
            {
                tmpBlueList.Add(item);
            }

        }

        foreach (var item in yellowPieces)
        {
            if (item.IsOkey == false)
            {
                tmpYellowList.Add(item);
            }

        }

        foreach (var item in greenPieces)
        {
            if (item.IsOkey == false)
            {
                tmpGreenList.Add(item);
            }

        }


        for (int i = 1; i <= 13; i++)
        {

                tmpSet = new Set();

                tmpSet.Number = i;
                tmpSet.Color1 = null;
                tmpSet.Color2 = null;
                tmpSet.Color3 = null;
                tmpSet.Color4 = null;
                tmpSet.OkeyUsed = 0;

                #region // set the color if exist

                    foreach (var item in tmpRedList)
                    {
                        if (item.Number == i)
                        {
                            tmpSet.Color1 = "Red";
                        }
                    }

                    foreach (var item in tmpBlueList)
                    {
                        if (item.Number == i)
                        {
                            tmpSet.Color2 = "Blue";
                        }
                    }

                    foreach (var item in tmpYellowList)
                    {
                        if (item.Number == i)
                        {
                            tmpSet.Color3 = "Yellow";
                        }
                    }

                    foreach (var item in tmpGreenList)
                    {
                        if (item.Number == i)
                        {
                            tmpSet.Color4 = "Green";
                        }
                    }

                    #endregion

                #region // adding the set to setlist



                    if (tmpSet.Color1 != null &&
                       tmpSet.Color2 != null &&
                       tmpSet.Color3 != null &&
                       tmpSet.Color4 != null)
                    {

                        SetList.Add(tmpSet);

                    }
                    else if (tmpSet.Color1 != null &&
                            tmpSet.Color2 != null &&
                            tmpSet.Color3 != null)
                    {
                        SetList.Add(tmpSet);
                    }
                    else if (tmpSet.Color1 != null &&
                             tmpSet.Color2 != null &&
                             tmpSet.Color4 != null)
                    {
                        SetList.Add(tmpSet);
                    }
                    else if (tmpSet.Color1 != null &&
                             tmpSet.Color3 != null &&
                             tmpSet.Color4 != null)
                    {
                        SetList.Add(tmpSet);
                    }
                    else if (tmpSet.Color2 != null &&
                             tmpSet.Color3 != null &&
                             tmpSet.Color4 != null)
                    {
                        SetList.Add(tmpSet);
                    }

                    #endregion


        }

        tmpRedList.Clear();
        tmpBlueList.Clear();
        tmpYellowList.Clear();
        tmpGreenList.Clear();



    }

    public void FindSetsWithOneOkey()
    {

        Set tmpSet;

        Piece okey1;

        okey1 = new Piece();
        okey1.Color = null;
        okey1.Number = null;
        okey1.IsOkey = true;
        okey1.IsFakeOkey = false;

        foreach (var item in redPieces)
        {
            if (item.IsOkey == false)
            {
                tmpRedList.Add(item);
            }

        }

        foreach (var item in bluePieces)
        {
            if (item.IsOkey == false)
            {
                tmpBlueList.Add(item);
            }

        }

        foreach (var item in yellowPieces)
        {
            if (item.IsOkey == false)
            {
                tmpYellowList.Add(item);
            }

        }

        foreach (var item in greenPieces)
        {
            if (item.IsOkey == false)
            {
                tmpGreenList.Add(item);
            }

        }


        for (int i = 1; i <= 13; i++)
        {

            for (int colorOfOkey1 = 1; colorOfOkey1 <= 4; colorOfOkey1++)
            {
                tmpSet = new Set();

                tmpSet.Number = i;
                tmpSet.Color1 = null;
                tmpSet.Color2 = null;
                tmpSet.Color3 = null;
                tmpSet.Color4 = null;
                tmpSet.OkeyUsed = 1;

                if (colorOfOkey1 == 1)
                {
                    tmpRedList.Add(okey1);
                    okey1.Number = i;
                    okey1.Color = "Red";

                    #region // set the color if exist

                    foreach (var item in tmpRedList)
                    {
                        if (item.Number == i)
                        {
                            tmpSet.Color1 = "Red";
                        }
                    }

                    foreach (var item in tmpBlueList)
                    {
                        if (item.Number == i)
                        {
                            tmpSet.Color2 = "Blue";
                        }
                    }

                    foreach (var item in tmpYellowList)
                    {
                        if (item.Number == i)
                        {
                            tmpSet.Color3 = "Yellow";
                        }
                    }

                    foreach (var item in tmpGreenList)
                    {
                        if (item.Number == i)
                        {
                            tmpSet.Color4 = "Green";
                        }
                    }

                    #endregion

                    #region // adding the set to setlist



                    if (tmpSet.Color1 != null &&
                       tmpSet.Color2 != null &&
                       tmpSet.Color3 != null &&
                       tmpSet.Color4 != null)
                    {

                        SetList.Add(tmpSet);

                    }
                    else if (tmpSet.Color1 != null &&
                            tmpSet.Color2 != null &&
                            tmpSet.Color3 != null)
                    {
                        SetList.Add(tmpSet);
                    }
                    else if (tmpSet.Color1 != null &&
                             tmpSet.Color2 != null &&
                             tmpSet.Color4 != null)
                    {
                        SetList.Add(tmpSet);
                    }
                    else if (tmpSet.Color1 != null &&
                             tmpSet.Color3 != null &&
                             tmpSet.Color4 != null)
                    {
                        SetList.Add(tmpSet);
                    }
                    else if (tmpSet.Color2 != null &&
                             tmpSet.Color3 != null &&
                             tmpSet.Color4 != null)
                    {
                        SetList.Add(tmpSet);
                    }

                    #endregion

                    tmpRedList.Remove(okey1);

                }

                if (colorOfOkey1 == 2)
                {
                    tmpBlueList.Add(okey1);
                    okey1.Number = i;
                    okey1.Color = "Blue";

                    #region // set the color if exist

                    foreach (var item in tmpRedList)
                    {
                        if (item.Number == i)
                        {
                            tmpSet.Color1 = "Red";
                        }
                    }

                    foreach (var item in tmpBlueList)
                    {
                        if (item.Number == i)
                        {
                            tmpSet.Color2 = "Blue";
                        }
                    }

                    foreach (var item in tmpYellowList)
                    {
                        if (item.Number == i)
                        {
                            tmpSet.Color3 = "Yellow";
                        }
                    }

                    foreach (var item in tmpGreenList)
                    {
                        if (item.Number == i)
                        {
                            tmpSet.Color4 = "Green";
                        }
                    }

                    #endregion

                    #region // adding the set to setlist



                    if (tmpSet.Color1 != null &&
                       tmpSet.Color2 != null &&
                       tmpSet.Color3 != null &&
                       tmpSet.Color4 != null)
                    {

                        SetList.Add(tmpSet);

                    }
                    else if (tmpSet.Color1 != null &&
                            tmpSet.Color2 != null &&
                            tmpSet.Color3 != null)
                    {
                        SetList.Add(tmpSet);
                    }
                    else if (tmpSet.Color1 != null &&
                             tmpSet.Color2 != null &&
                             tmpSet.Color4 != null)
                    {
                        SetList.Add(tmpSet);
                    }
                    else if (tmpSet.Color1 != null &&
                             tmpSet.Color3 != null &&
                             tmpSet.Color4 != null)
                    {
                        SetList.Add(tmpSet);
                    }
                    else if (tmpSet.Color2 != null &&
                             tmpSet.Color3 != null &&
                             tmpSet.Color4 != null)
                    {
                        SetList.Add(tmpSet);
                    }

                    #endregion

                    tmpBlueList.Remove(okey1);

                }

                if (colorOfOkey1 == 3)
                {
                    tmpYellowList.Add(okey1);
                    okey1.Number = i;
                    okey1.Color = "Yellow";

                    #region // set the color if exist

                    foreach (var item in tmpRedList)
                    {
                        if (item.Number == i)
                        {
                            tmpSet.Color1 = "Red";
                        }
                    }

                    foreach (var item in tmpBlueList)
                    {
                        if (item.Number == i)
                        {
                            tmpSet.Color2 = "Blue";
                        }
                    }

                    foreach (var item in tmpYellowList)
                    {
                        if (item.Number == i)
                        {
                            tmpSet.Color3 = "Yellow";
                        }
                    }

                    foreach (var item in tmpGreenList)
                    {
                        if (item.Number == i)
                        {
                            tmpSet.Color4 = "Green";
                        }
                    }

                    #endregion

                    #region // adding the set to setlist



                    if (tmpSet.Color1 != null &&
                       tmpSet.Color2 != null &&
                       tmpSet.Color3 != null &&
                       tmpSet.Color4 != null)
                    {

                        SetList.Add(tmpSet);

                    }
                    else if (tmpSet.Color1 != null &&
                            tmpSet.Color2 != null &&
                            tmpSet.Color3 != null)
                    {
                        SetList.Add(tmpSet);
                    }
                    else if (tmpSet.Color1 != null &&
                             tmpSet.Color2 != null &&
                             tmpSet.Color4 != null)
                    {
                        SetList.Add(tmpSet);
                    }
                    else if (tmpSet.Color1 != null &&
                             tmpSet.Color3 != null &&
                             tmpSet.Color4 != null)
                    {
                        SetList.Add(tmpSet);
                    }
                    else if (tmpSet.Color2 != null &&
                             tmpSet.Color3 != null &&
                             tmpSet.Color4 != null)
                    {
                        SetList.Add(tmpSet);
                    }

                    #endregion

                    tmpYellowList.Remove(okey1);

                }

                if (colorOfOkey1 == 4)
                {
                    tmpGreenList.Add(okey1);
                    okey1.Number = i;
                    okey1.Color = "Green";

                    #region // set the color if exist

                    foreach (var item in tmpRedList)
                    {
                        if (item.Number == i)
                        {
                            tmpSet.Color1 = "Red";
                        }
                    }

                    foreach (var item in tmpBlueList)
                    {
                        if (item.Number == i)
                        {
                            tmpSet.Color2 = "Blue";
                        }
                    }

                    foreach (var item in tmpYellowList)
                    {
                        if (item.Number == i)
                        {
                            tmpSet.Color3 = "Yellow";
                        }
                    }

                    foreach (var item in tmpGreenList)
                    {
                        if (item.Number == i)
                        {
                            tmpSet.Color4 = "Green";
                        }
                    }

                    #endregion

                    #region // adding the set to setlist



                    if (tmpSet.Color1 != null &&
                       tmpSet.Color2 != null &&
                       tmpSet.Color3 != null &&
                       tmpSet.Color4 != null)
                    {

                        SetList.Add(tmpSet);

                    }
                    else if (tmpSet.Color1 != null &&
                            tmpSet.Color2 != null &&
                            tmpSet.Color3 != null)
                    {
                        SetList.Add(tmpSet);
                    }
                    else if (tmpSet.Color1 != null &&
                             tmpSet.Color2 != null &&
                             tmpSet.Color4 != null)
                    {
                        SetList.Add(tmpSet);
                    }
                    else if (tmpSet.Color1 != null &&
                             tmpSet.Color3 != null &&
                             tmpSet.Color4 != null)
                    {
                        SetList.Add(tmpSet);
                    }
                    else if (tmpSet.Color2 != null &&
                             tmpSet.Color3 != null &&
                             tmpSet.Color4 != null)
                    {
                        SetList.Add(tmpSet);
                    }

                    #endregion

                    tmpGreenList.Remove(okey1);

                }

            }



        }

        tmpRedList.Clear();
        tmpBlueList.Clear();
        tmpYellowList.Clear();
        tmpGreenList.Clear();



    }

    public void FindSetsWithTwoOkey()
    {

        Set tmpSet;

        Piece okey1;

        okey1 = new Piece();
        okey1.Color = null;
        okey1.Number = null;
        okey1.IsOkey = true;
        okey1.IsFakeOkey = false;

        Piece okey2;

        okey2 = new Piece();
        okey2.Color = null;
        okey2.Number = null;
        okey2.IsOkey = true;
        okey2.IsFakeOkey = false;

        foreach (var item in redPieces)
        {
            if (item.IsOkey == false)
            {
                tmpRedList.Add(item);
            }

        }

        foreach (var item in bluePieces)
        {
            if (item.IsOkey == false)
            {
                tmpBlueList.Add(item);
            }

        }

        foreach (var item in yellowPieces)
        {
            if (item.IsOkey == false)
            {
                tmpYellowList.Add(item);
            }

        }

        foreach (var item in greenPieces)
        {
            if (item.IsOkey == false)
            {
                tmpGreenList.Add(item);
            }

        }


        for (int i = 1; i <= 13; i++)
        {

            for (int colorOfOkey2 = 1; colorOfOkey2 <= 4; colorOfOkey2++)
            {

                if (colorOfOkey2 == 1)
                {
                    tmpRedList.Add(okey2);
                    okey2.Number = i;
                    okey2.Color = "Red";

                    for (int colorOfOkey1 = 1; colorOfOkey1 <= 4; colorOfOkey1++)
                    {
                        tmpSet = new Set();

                        tmpSet.Number = i;
                        tmpSet.Color1 = null;
                        tmpSet.Color2 = null;
                        tmpSet.Color3 = null;
                        tmpSet.Color4 = null;
                        tmpSet.OkeyUsed = 2;

                        if (colorOfOkey1 == 1)
                        {
                            tmpRedList.Add(okey1);
                            okey1.Number = i;
                            okey1.Color = "Red";

                            #region // set the color if exist

                            foreach (var item in tmpRedList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color1 = "Red";
                                }
                            }

                            foreach (var item in tmpBlueList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color2 = "Blue";
                                }
                            }

                            foreach (var item in tmpYellowList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color3 = "Yellow";
                                }
                            }

                            foreach (var item in tmpGreenList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color4 = "Green";
                                }
                            }

                            #endregion

                            #region // adding the set to setlist



                            if (tmpSet.Color1 != null &&
                               tmpSet.Color2 != null &&
                               tmpSet.Color3 != null &&
                               tmpSet.Color4 != null)
                            {

                                SetList.Add(tmpSet);

                            }
                            else if (tmpSet.Color1 != null &&
                                    tmpSet.Color2 != null &&
                                    tmpSet.Color3 != null)
                            {
                                SetList.Add(tmpSet);
                            }
                            else if (tmpSet.Color1 != null &&
                                     tmpSet.Color2 != null &&
                                     tmpSet.Color4 != null)
                            {
                                SetList.Add(tmpSet);
                            }
                            else if (tmpSet.Color1 != null &&
                                     tmpSet.Color3 != null &&
                                     tmpSet.Color4 != null)
                            {
                                SetList.Add(tmpSet);
                            }
                            else if (tmpSet.Color2 != null &&
                                     tmpSet.Color3 != null &&
                                     tmpSet.Color4 != null)
                            {
                                SetList.Add(tmpSet);
                            }

                            #endregion

                            tmpRedList.Remove(okey1);

                        }

                        if (colorOfOkey1 == 2)
                        {
                            tmpBlueList.Add(okey1);
                            okey1.Number = i;
                            okey1.Color = "Blue";

                            #region // set the color if exist

                            foreach (var item in tmpRedList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color1 = "Red";
                                }
                            }

                            foreach (var item in tmpBlueList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color2 = "Blue";
                                }
                            }

                            foreach (var item in tmpYellowList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color3 = "Yellow";
                                }
                            }

                            foreach (var item in tmpGreenList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color4 = "Green";
                                }
                            }

                            #endregion

                            #region // adding the set to setlist



                            if (tmpSet.Color1 != null &&
                               tmpSet.Color2 != null &&
                               tmpSet.Color3 != null &&
                               tmpSet.Color4 != null)
                            {

                                SetList.Add(tmpSet);

                            }
                            else if (tmpSet.Color1 != null &&
                                    tmpSet.Color2 != null &&
                                    tmpSet.Color3 != null)
                            {
                                SetList.Add(tmpSet);
                            }
                            else if (tmpSet.Color1 != null &&
                                     tmpSet.Color2 != null &&
                                     tmpSet.Color4 != null)
                            {
                                SetList.Add(tmpSet);
                            }
                            else if (tmpSet.Color1 != null &&
                                     tmpSet.Color3 != null &&
                                     tmpSet.Color4 != null)
                            {
                                SetList.Add(tmpSet);
                            }
                            else if (tmpSet.Color2 != null &&
                                     tmpSet.Color3 != null &&
                                     tmpSet.Color4 != null)
                            {
                                SetList.Add(tmpSet);
                            }

                            #endregion

                            tmpBlueList.Remove(okey1);

                        }

                        if (colorOfOkey1 == 3)
                        {
                            tmpYellowList.Add(okey1);
                            okey1.Number = i;
                            okey1.Color = "Yellow";

                            #region // set the color if exist

                            foreach (var item in tmpRedList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color1 = "Red";
                                }
                            }

                            foreach (var item in tmpBlueList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color2 = "Blue";
                                }
                            }

                            foreach (var item in tmpYellowList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color3 = "Yellow";
                                }
                            }

                            foreach (var item in tmpGreenList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color4 = "Green";
                                }
                            }

                            #endregion

                            #region // adding the set to setlist



                            if (tmpSet.Color1 != null &&
                               tmpSet.Color2 != null &&
                               tmpSet.Color3 != null &&
                               tmpSet.Color4 != null)
                            {

                                SetList.Add(tmpSet);

                            }
                            else if (tmpSet.Color1 != null &&
                                    tmpSet.Color2 != null &&
                                    tmpSet.Color3 != null)
                            {
                                SetList.Add(tmpSet);
                            }
                            else if (tmpSet.Color1 != null &&
                                     tmpSet.Color2 != null &&
                                     tmpSet.Color4 != null)
                            {
                                SetList.Add(tmpSet);
                            }
                            else if (tmpSet.Color1 != null &&
                                     tmpSet.Color3 != null &&
                                     tmpSet.Color4 != null)
                            {
                                SetList.Add(tmpSet);
                            }
                            else if (tmpSet.Color2 != null &&
                                     tmpSet.Color3 != null &&
                                     tmpSet.Color4 != null)
                            {
                                SetList.Add(tmpSet);
                            }

                            #endregion

                            tmpYellowList.Remove(okey1);

                        }

                        if (colorOfOkey1 == 4)
                        {
                            tmpGreenList.Add(okey1);
                            okey1.Number = i;
                            okey1.Color = "Green";

                            #region // set the color if exist

                            foreach (var item in tmpRedList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color1 = "Red";
                                }
                            }

                            foreach (var item in tmpBlueList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color2 = "Blue";
                                }
                            }

                            foreach (var item in tmpYellowList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color3 = "Yellow";
                                }
                            }

                            foreach (var item in tmpGreenList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color4 = "Green";
                                }
                            }

                            #endregion

                            #region // adding the set to setlist



                            if (tmpSet.Color1 != null &&
                               tmpSet.Color2 != null &&
                               tmpSet.Color3 != null &&
                               tmpSet.Color4 != null)
                            {

                                SetList.Add(tmpSet);

                            }
                            else if (tmpSet.Color1 != null &&
                                    tmpSet.Color2 != null &&
                                    tmpSet.Color3 != null)
                            {
                                SetList.Add(tmpSet);
                            }
                            else if (tmpSet.Color1 != null &&
                                     tmpSet.Color2 != null &&
                                     tmpSet.Color4 != null)
                            {
                                SetList.Add(tmpSet);
                            }
                            else if (tmpSet.Color1 != null &&
                                     tmpSet.Color3 != null &&
                                     tmpSet.Color4 != null)
                            {
                                SetList.Add(tmpSet);
                            }
                            else if (tmpSet.Color2 != null &&
                                     tmpSet.Color3 != null &&
                                     tmpSet.Color4 != null)
                            {
                                SetList.Add(tmpSet);
                            }

                            #endregion

                            tmpGreenList.Remove(okey1);

                        }

                    }

                    tmpRedList.Remove(okey2);

                }

                if (colorOfOkey2 == 2)
                {
                    tmpBlueList.Add(okey2);
                    okey2.Number = i;
                    okey2.Color = "Blue";

                    for (int colorOfOkey1 = 1; colorOfOkey1 <= 4; colorOfOkey1++)
                    {
                        tmpSet = new Set();

                        tmpSet.Number = i;
                        tmpSet.Color1 = null;
                        tmpSet.Color2 = null;
                        tmpSet.Color3 = null;
                        tmpSet.Color4 = null;
                        tmpSet.OkeyUsed = 2;

                        if (colorOfOkey1 == 1)
                        {
                            tmpRedList.Add(okey1);
                            okey1.Number = i;
                            okey1.Color = "Red";

                            #region // set the color if exist

                            foreach (var item in tmpRedList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color1 = "Red";
                                }
                            }

                            foreach (var item in tmpBlueList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color2 = "Blue";
                                }
                            }

                            foreach (var item in tmpYellowList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color3 = "Yellow";
                                }
                            }

                            foreach (var item in tmpGreenList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color4 = "Green";
                                }
                            }

                            #endregion

                            #region // adding the set to setlist



                            if (tmpSet.Color1 != null &&
                               tmpSet.Color2 != null &&
                               tmpSet.Color3 != null &&
                               tmpSet.Color4 != null)
                            {

                                SetList.Add(tmpSet);

                            }
                            else if (tmpSet.Color1 != null &&
                                    tmpSet.Color2 != null &&
                                    tmpSet.Color3 != null)
                            {
                                SetList.Add(tmpSet);
                            }
                            else if (tmpSet.Color1 != null &&
                                     tmpSet.Color2 != null &&
                                     tmpSet.Color4 != null)
                            {
                                SetList.Add(tmpSet);
                            }
                            else if (tmpSet.Color1 != null &&
                                     tmpSet.Color3 != null &&
                                     tmpSet.Color4 != null)
                            {
                                SetList.Add(tmpSet);
                            }
                            else if (tmpSet.Color2 != null &&
                                     tmpSet.Color3 != null &&
                                     tmpSet.Color4 != null)
                            {
                                SetList.Add(tmpSet);
                            }

                            #endregion

                            tmpRedList.Remove(okey1);

                        }

                        if (colorOfOkey1 == 2)
                        {
                            tmpBlueList.Add(okey1);
                            okey1.Number = i;
                            okey1.Color = "Blue";

                            #region // set the color if exist

                            foreach (var item in tmpRedList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color1 = "Red";
                                }
                            }

                            foreach (var item in tmpBlueList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color2 = "Blue";
                                }
                            }

                            foreach (var item in tmpYellowList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color3 = "Yellow";
                                }
                            }

                            foreach (var item in tmpGreenList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color4 = "Green";
                                }
                            }

                            #endregion

                            #region // adding the set to setlist



                            if (tmpSet.Color1 != null &&
                               tmpSet.Color2 != null &&
                               tmpSet.Color3 != null &&
                               tmpSet.Color4 != null)
                            {

                                SetList.Add(tmpSet);

                            }
                            else if (tmpSet.Color1 != null &&
                                    tmpSet.Color2 != null &&
                                    tmpSet.Color3 != null)
                            {
                                SetList.Add(tmpSet);
                            }
                            else if (tmpSet.Color1 != null &&
                                     tmpSet.Color2 != null &&
                                     tmpSet.Color4 != null)
                            {
                                SetList.Add(tmpSet);
                            }
                            else if (tmpSet.Color1 != null &&
                                     tmpSet.Color3 != null &&
                                     tmpSet.Color4 != null)
                            {
                                SetList.Add(tmpSet);
                            }
                            else if (tmpSet.Color2 != null &&
                                     tmpSet.Color3 != null &&
                                     tmpSet.Color4 != null)
                            {
                                SetList.Add(tmpSet);
                            }

                            #endregion

                            tmpBlueList.Remove(okey1);

                        }

                        if (colorOfOkey1 == 3)
                        {
                            tmpYellowList.Add(okey1);
                            okey1.Number = i;
                            okey1.Color = "Yellow";

                            #region // set the color if exist

                            foreach (var item in tmpRedList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color1 = "Red";
                                }
                            }

                            foreach (var item in tmpBlueList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color2 = "Blue";
                                }
                            }

                            foreach (var item in tmpYellowList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color3 = "Yellow";
                                }
                            }

                            foreach (var item in tmpGreenList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color4 = "Green";
                                }
                            }

                            #endregion

                            #region // adding the set to setlist



                            if (tmpSet.Color1 != null &&
                               tmpSet.Color2 != null &&
                               tmpSet.Color3 != null &&
                               tmpSet.Color4 != null)
                            {

                                SetList.Add(tmpSet);

                            }
                            else if (tmpSet.Color1 != null &&
                                    tmpSet.Color2 != null &&
                                    tmpSet.Color3 != null)
                            {
                                SetList.Add(tmpSet);
                            }
                            else if (tmpSet.Color1 != null &&
                                     tmpSet.Color2 != null &&
                                     tmpSet.Color4 != null)
                            {
                                SetList.Add(tmpSet);
                            }
                            else if (tmpSet.Color1 != null &&
                                     tmpSet.Color3 != null &&
                                     tmpSet.Color4 != null)
                            {
                                SetList.Add(tmpSet);
                            }
                            else if (tmpSet.Color2 != null &&
                                     tmpSet.Color3 != null &&
                                     tmpSet.Color4 != null)
                            {
                                SetList.Add(tmpSet);
                            }

                            #endregion

                            tmpYellowList.Remove(okey1);

                        }

                        if (colorOfOkey1 == 4)
                        {
                            tmpGreenList.Add(okey1);
                            okey1.Number = i;
                            okey1.Color = "Green";

                            #region // set the color if exist

                            foreach (var item in tmpRedList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color1 = "Red";
                                }
                            }

                            foreach (var item in tmpBlueList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color2 = "Blue";
                                }
                            }

                            foreach (var item in tmpYellowList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color3 = "Yellow";
                                }
                            }

                            foreach (var item in tmpGreenList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color4 = "Green";
                                }
                            }

                            #endregion

                            #region // adding the set to setlist



                            if (tmpSet.Color1 != null &&
                               tmpSet.Color2 != null &&
                               tmpSet.Color3 != null &&
                               tmpSet.Color4 != null)
                            {

                                SetList.Add(tmpSet);

                            }
                            else if (tmpSet.Color1 != null &&
                                    tmpSet.Color2 != null &&
                                    tmpSet.Color3 != null)
                            {
                                SetList.Add(tmpSet);
                            }
                            else if (tmpSet.Color1 != null &&
                                     tmpSet.Color2 != null &&
                                     tmpSet.Color4 != null)
                            {
                                SetList.Add(tmpSet);
                            }
                            else if (tmpSet.Color1 != null &&
                                     tmpSet.Color3 != null &&
                                     tmpSet.Color4 != null)
                            {
                                SetList.Add(tmpSet);
                            }
                            else if (tmpSet.Color2 != null &&
                                     tmpSet.Color3 != null &&
                                     tmpSet.Color4 != null)
                            {
                                SetList.Add(tmpSet);
                            }

                            #endregion

                            tmpGreenList.Remove(okey1);

                        }

                    }

                    tmpBlueList.Remove(okey2);

                }

                if (colorOfOkey2 == 3)
                {
                    tmpYellowList.Add(okey2);
                    okey2.Number = i;
                    okey2.Color = "Yellow";

                    for (int colorOfOkey1 = 1; colorOfOkey1 <= 4; colorOfOkey1++)
                    {
                        tmpSet = new Set();

                        tmpSet.Number = i;
                        tmpSet.Color1 = null;
                        tmpSet.Color2 = null;
                        tmpSet.Color3 = null;
                        tmpSet.Color4 = null;
                        tmpSet.OkeyUsed = 2;

                        if (colorOfOkey1 == 1)
                        {
                            tmpRedList.Add(okey1);
                            okey1.Number = i;
                            okey1.Color = "Red";

                            #region // set the color if exist

                            foreach (var item in tmpRedList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color1 = "Red";
                                }
                            }

                            foreach (var item in tmpBlueList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color2 = "Blue";
                                }
                            }

                            foreach (var item in tmpYellowList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color3 = "Yellow";
                                }
                            }

                            foreach (var item in tmpGreenList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color4 = "Green";
                                }
                            }

                            #endregion

                            #region // adding the set to setlist



                            if (tmpSet.Color1 != null &&
                               tmpSet.Color2 != null &&
                               tmpSet.Color3 != null &&
                               tmpSet.Color4 != null)
                            {

                                SetList.Add(tmpSet);

                            }
                            else if (tmpSet.Color1 != null &&
                                    tmpSet.Color2 != null &&
                                    tmpSet.Color3 != null)
                            {
                                SetList.Add(tmpSet);
                            }
                            else if (tmpSet.Color1 != null &&
                                     tmpSet.Color2 != null &&
                                     tmpSet.Color4 != null)
                            {
                                SetList.Add(tmpSet);
                            }
                            else if (tmpSet.Color1 != null &&
                                     tmpSet.Color3 != null &&
                                     tmpSet.Color4 != null)
                            {
                                SetList.Add(tmpSet);
                            }
                            else if (tmpSet.Color2 != null &&
                                     tmpSet.Color3 != null &&
                                     tmpSet.Color4 != null)
                            {
                                SetList.Add(tmpSet);
                            }

                            #endregion

                            tmpRedList.Remove(okey1);

                        }

                        if (colorOfOkey1 == 2)
                        {
                            tmpBlueList.Add(okey1);
                            okey1.Number = i;
                            okey1.Color = "Blue";

                            #region // set the color if exist

                            foreach (var item in tmpRedList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color1 = "Red";
                                }
                            }

                            foreach (var item in tmpBlueList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color2 = "Blue";
                                }
                            }

                            foreach (var item in tmpYellowList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color3 = "Yellow";
                                }
                            }

                            foreach (var item in tmpGreenList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color4 = "Green";
                                }
                            }

                            #endregion

                            #region // adding the set to setlist



                            if (tmpSet.Color1 != null &&
                               tmpSet.Color2 != null &&
                               tmpSet.Color3 != null &&
                               tmpSet.Color4 != null)
                            {

                                SetList.Add(tmpSet);

                            }
                            else if (tmpSet.Color1 != null &&
                                    tmpSet.Color2 != null &&
                                    tmpSet.Color3 != null)
                            {
                                SetList.Add(tmpSet);
                            }
                            else if (tmpSet.Color1 != null &&
                                     tmpSet.Color2 != null &&
                                     tmpSet.Color4 != null)
                            {
                                SetList.Add(tmpSet);
                            }
                            else if (tmpSet.Color1 != null &&
                                     tmpSet.Color3 != null &&
                                     tmpSet.Color4 != null)
                            {
                                SetList.Add(tmpSet);
                            }
                            else if (tmpSet.Color2 != null &&
                                     tmpSet.Color3 != null &&
                                     tmpSet.Color4 != null)
                            {
                                SetList.Add(tmpSet);
                            }

                            #endregion

                            tmpBlueList.Remove(okey1);

                        }

                        if (colorOfOkey1 == 3)
                        {
                            tmpYellowList.Add(okey1);
                            okey1.Number = i;
                            okey1.Color = "Yellow";

                            #region // set the color if exist

                            foreach (var item in tmpRedList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color1 = "Red";
                                }
                            }

                            foreach (var item in tmpBlueList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color2 = "Blue";
                                }
                            }

                            foreach (var item in tmpYellowList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color3 = "Yellow";
                                }
                            }

                            foreach (var item in tmpGreenList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color4 = "Green";
                                }
                            }

                            #endregion

                            #region // adding the set to setlist



                            if (tmpSet.Color1 != null &&
                               tmpSet.Color2 != null &&
                               tmpSet.Color3 != null &&
                               tmpSet.Color4 != null)
                            {

                                SetList.Add(tmpSet);

                            }
                            else if (tmpSet.Color1 != null &&
                                    tmpSet.Color2 != null &&
                                    tmpSet.Color3 != null)
                            {
                                SetList.Add(tmpSet);
                            }
                            else if (tmpSet.Color1 != null &&
                                     tmpSet.Color2 != null &&
                                     tmpSet.Color4 != null)
                            {
                                SetList.Add(tmpSet);
                            }
                            else if (tmpSet.Color1 != null &&
                                     tmpSet.Color3 != null &&
                                     tmpSet.Color4 != null)
                            {
                                SetList.Add(tmpSet);
                            }
                            else if (tmpSet.Color2 != null &&
                                     tmpSet.Color3 != null &&
                                     tmpSet.Color4 != null)
                            {
                                SetList.Add(tmpSet);
                            }

                            #endregion

                            tmpYellowList.Remove(okey1);

                        }

                        if (colorOfOkey1 == 4)
                        {
                            tmpGreenList.Add(okey1);
                            okey1.Number = i;
                            okey1.Color = "Green";

                            #region // set the color if exist

                            foreach (var item in tmpRedList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color1 = "Red";
                                }
                            }

                            foreach (var item in tmpBlueList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color2 = "Blue";
                                }
                            }

                            foreach (var item in tmpYellowList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color3 = "Yellow";
                                }
                            }

                            foreach (var item in tmpGreenList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color4 = "Green";
                                }
                            }

                            #endregion

                            #region // adding the set to setlist



                            if (tmpSet.Color1 != null &&
                               tmpSet.Color2 != null &&
                               tmpSet.Color3 != null &&
                               tmpSet.Color4 != null)
                            {

                                SetList.Add(tmpSet);

                            }
                            else if (tmpSet.Color1 != null &&
                                    tmpSet.Color2 != null &&
                                    tmpSet.Color3 != null)
                            {
                                SetList.Add(tmpSet);
                            }
                            else if (tmpSet.Color1 != null &&
                                     tmpSet.Color2 != null &&
                                     tmpSet.Color4 != null)
                            {
                                SetList.Add(tmpSet);
                            }
                            else if (tmpSet.Color1 != null &&
                                     tmpSet.Color3 != null &&
                                     tmpSet.Color4 != null)
                            {
                                SetList.Add(tmpSet);
                            }
                            else if (tmpSet.Color2 != null &&
                                     tmpSet.Color3 != null &&
                                     tmpSet.Color4 != null)
                            {
                                SetList.Add(tmpSet);
                            }

                            #endregion

                            tmpGreenList.Remove(okey1);

                        }

                    }

                    tmpYellowList.Remove(okey2);

                }

                if (colorOfOkey2 == 4)
                {
                    tmpGreenList.Add(okey2);
                    okey2.Number = i;
                    okey2.Color = "Green";

                    for (int colorOfOkey1 = 1; colorOfOkey1 <= 4; colorOfOkey1++)
                    {
                        tmpSet = new Set();

                        tmpSet.Number = i;
                        tmpSet.Color1 = null;
                        tmpSet.Color2 = null;
                        tmpSet.Color3 = null;
                        tmpSet.Color4 = null;
                        tmpSet.OkeyUsed = 2;

                        if (colorOfOkey1 == 1)
                        {
                            tmpRedList.Add(okey1);
                            okey1.Number = i;
                            okey1.Color = "Red";

                            #region // set the color if exist

                            foreach (var item in tmpRedList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color1 = "Red";
                                }
                            }

                            foreach (var item in tmpBlueList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color2 = "Blue";
                                }
                            }

                            foreach (var item in tmpYellowList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color3 = "Yellow";
                                }
                            }

                            foreach (var item in tmpGreenList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color4 = "Green";
                                }
                            }

                            #endregion

                            #region // adding the set to setlist



                            if (tmpSet.Color1 != null &&
                               tmpSet.Color2 != null &&
                               tmpSet.Color3 != null &&
                               tmpSet.Color4 != null)
                            {

                                SetList.Add(tmpSet);

                            }
                            else if (tmpSet.Color1 != null &&
                                    tmpSet.Color2 != null &&
                                    tmpSet.Color3 != null)
                            {
                                SetList.Add(tmpSet);
                            }
                            else if (tmpSet.Color1 != null &&
                                     tmpSet.Color2 != null &&
                                     tmpSet.Color4 != null)
                            {
                                SetList.Add(tmpSet);
                            }
                            else if (tmpSet.Color1 != null &&
                                     tmpSet.Color3 != null &&
                                     tmpSet.Color4 != null)
                            {
                                SetList.Add(tmpSet);
                            }
                            else if (tmpSet.Color2 != null &&
                                     tmpSet.Color3 != null &&
                                     tmpSet.Color4 != null)
                            {
                                SetList.Add(tmpSet);
                            }

                            #endregion

                            tmpRedList.Remove(okey1);

                        }

                        if (colorOfOkey1 == 2)
                        {
                            tmpBlueList.Add(okey1);
                            okey1.Number = i;
                            okey1.Color = "Blue";

                            #region // set the color if exist

                            foreach (var item in tmpRedList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color1 = "Red";
                                }
                            }

                            foreach (var item in tmpBlueList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color2 = "Blue";
                                }
                            }

                            foreach (var item in tmpYellowList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color3 = "Yellow";
                                }
                            }

                            foreach (var item in tmpGreenList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color4 = "Green";
                                }
                            }

                            #endregion

                            #region // adding the set to setlist



                            if (tmpSet.Color1 != null &&
                               tmpSet.Color2 != null &&
                               tmpSet.Color3 != null &&
                               tmpSet.Color4 != null)
                            {

                                SetList.Add(tmpSet);

                            }
                            else if (tmpSet.Color1 != null &&
                                    tmpSet.Color2 != null &&
                                    tmpSet.Color3 != null)
                            {
                                SetList.Add(tmpSet);
                            }
                            else if (tmpSet.Color1 != null &&
                                     tmpSet.Color2 != null &&
                                     tmpSet.Color4 != null)
                            {
                                SetList.Add(tmpSet);
                            }
                            else if (tmpSet.Color1 != null &&
                                     tmpSet.Color3 != null &&
                                     tmpSet.Color4 != null)
                            {
                                SetList.Add(tmpSet);
                            }
                            else if (tmpSet.Color2 != null &&
                                     tmpSet.Color3 != null &&
                                     tmpSet.Color4 != null)
                            {
                                SetList.Add(tmpSet);
                            }

                            #endregion

                            tmpBlueList.Remove(okey1);

                        }

                        if (colorOfOkey1 == 3)
                        {
                            tmpYellowList.Add(okey1);
                            okey1.Number = i;
                            okey1.Color = "Yellow";

                            #region // set the color if exist

                            foreach (var item in tmpRedList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color1 = "Red";
                                }
                            }

                            foreach (var item in tmpBlueList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color2 = "Blue";
                                }
                            }

                            foreach (var item in tmpYellowList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color3 = "Yellow";
                                }
                            }

                            foreach (var item in tmpGreenList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color4 = "Green";
                                }
                            }

                            #endregion

                            #region // adding the set to setlist



                            if (tmpSet.Color1 != null &&
                               tmpSet.Color2 != null &&
                               tmpSet.Color3 != null &&
                               tmpSet.Color4 != null)
                            {

                                SetList.Add(tmpSet);

                            }
                            else if (tmpSet.Color1 != null &&
                                    tmpSet.Color2 != null &&
                                    tmpSet.Color3 != null)
                            {
                                SetList.Add(tmpSet);
                            }
                            else if (tmpSet.Color1 != null &&
                                     tmpSet.Color2 != null &&
                                     tmpSet.Color4 != null)
                            {
                                SetList.Add(tmpSet);
                            }
                            else if (tmpSet.Color1 != null &&
                                     tmpSet.Color3 != null &&
                                     tmpSet.Color4 != null)
                            {
                                SetList.Add(tmpSet);
                            }
                            else if (tmpSet.Color2 != null &&
                                     tmpSet.Color3 != null &&
                                     tmpSet.Color4 != null)
                            {
                                SetList.Add(tmpSet);
                            }

                            #endregion

                            tmpYellowList.Remove(okey1);

                        }

                        if (colorOfOkey1 == 4)
                        {
                            tmpGreenList.Add(okey1);
                            okey1.Number = i;
                            okey1.Color = "Green";

                            #region // set the color if exist

                            foreach (var item in tmpRedList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color1 = "Red";
                                }
                            }

                            foreach (var item in tmpBlueList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color2 = "Blue";
                                }
                            }

                            foreach (var item in tmpYellowList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color3 = "Yellow";
                                }
                            }

                            foreach (var item in tmpGreenList)
                            {
                                if (item.Number == i)
                                {
                                    tmpSet.Color4 = "Green";
                                }
                            }

                            #endregion

                            #region // adding the set to setlist



                            if (tmpSet.Color1 != null &&
                               tmpSet.Color2 != null &&
                               tmpSet.Color3 != null &&
                               tmpSet.Color4 != null)
                            {

                                SetList.Add(tmpSet);

                            }
                            else if (tmpSet.Color1 != null &&
                                    tmpSet.Color2 != null &&
                                    tmpSet.Color3 != null)
                            {
                                SetList.Add(tmpSet);
                            }
                            else if (tmpSet.Color1 != null &&
                                     tmpSet.Color2 != null &&
                                     tmpSet.Color4 != null)
                            {
                                SetList.Add(tmpSet);
                            }
                            else if (tmpSet.Color1 != null &&
                                     tmpSet.Color3 != null &&
                                     tmpSet.Color4 != null)
                            {
                                SetList.Add(tmpSet);
                            }
                            else if (tmpSet.Color2 != null &&
                                     tmpSet.Color3 != null &&
                                     tmpSet.Color4 != null)
                            {
                                SetList.Add(tmpSet);
                            }

                            #endregion

                            tmpGreenList.Remove(okey1);

                        }

                    }

                    tmpGreenList.Remove(okey2);

                }


            }


          


        }

        tmpRedList.Clear();
        tmpBlueList.Clear();
        tmpYellowList.Clear();
        tmpGreenList.Clear();


    }

    public void FindSets()
    {

        switch (okeyCounter)
        {
            case 0:

                FindSetsWithoutOkey();

                break;

            case 1:

                FindSetsWithoutOkey();
                FindSetsWithOneOkey();

                break;


            case 2:

                FindSetsWithoutOkey();
                FindSetsWithOneOkey();
                FindSetsWithTwoOkey();

                break;

        }

        CleanUpSets();

    }

    public void CleanUpSets()
    {

        for (int i = 0; i < SetList.Count; i++)
        {
            for (int y = 0; y < SetList.Count; y++)
            {

                if(i != y && 
                   SetList[i].Number == SetList[y].Number &&
                   SetList[i].Color1 == SetList[y].Color1 &&
                   SetList[i].Color2 == SetList[y].Color2 &&
                   SetList[i].Color3 == SetList[y].Color3 &&
                   SetList[i].Color4 == SetList[y].Color4 &&
                   SetList[i].OkeyUsed != SetList[y].OkeyUsed)
                {

                    if(SetList[i].OkeyUsed < SetList[y].OkeyUsed)
                    {
                        SetList.Remove(SetList[y]);
                    }
                    else
                    {
                        SetList.Remove(SetList[i]);
                    }



                }
                else if(i != y &&
                        SetList[i].Number == SetList[y].Number &&
                        SetList[i].Color1 == SetList[y].Color1 &&
                        SetList[i].Color2 == SetList[y].Color2 &&
                        SetList[i].Color3 == SetList[y].Color3 &&
                        SetList[i].Color4 == SetList[y].Color4 &&
                        SetList[i].OkeyUsed == SetList[y].OkeyUsed)
                {

                    SetList.Remove(SetList[y]);
                }


            }

        }


    }

    public void WriteSets()
    {
        Console.WriteLine("");
        Console.WriteLine("");

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Kütler");

        Console.WriteLine("");

        foreach (var item in SetList)
        {
            Console.WriteLine("");
            Console.Write("[");

            if(item.Color1 != null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($" {item.Number} ");
            }

            if (item.Color2 != null)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($" {item.Number} ");
            }

            if (item.Color3 != null)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($" {item.Number} ");
            }

            if (item.Color4 != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($" {item.Number} ");
            }



            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("]");

            Console.Write($"\t\tOkey Used:{item.OkeyUsed}");

        }

        Console.WriteLine("");
        Console.WriteLine("");



    }

    static void Main()
    {

        MainClass a = new MainClass();


        a.createdPieces.Clear();
        a.playersPieces.Clear();

        a.createdPieces = new List<Piece>();


        a.CreatingPieces();

        a.ShufflePieces();

        a.PickOkeyRandomly();

        a.FindFakeOkeysAndApplyValue();

        a.PreparePlayersPieces();

        a.ArrangePlayerPieces();

        a.SeperateColorsOfPlayersPieces();

        a.ShowPlayersPiecesInRows();

        a.FindOkeyCount();

        a.FindRuns();

        a.FindSets();

        a.WriteSets();




        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(". . .");













        Console.ReadKey();

    }

}