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
    public bool Color1 { get; set; }
    public bool Color2 { get; set; }
    public bool Color3 { get; set; }
    public bool Color4 { get; set; }
    public int OkeyCount { get; set; }
    public int? itemCount { get; set; }
    public int? SumOfSet { get; set; }
    public List<Piece> OkeyUsedAs { get; set; }
    public List<Piece> PiecesList { get; set; }
}

public class Run
{
    public int? FirstNumber { get; set; }
    public int? LastNumber { get; set; }
    public string ColorOfRun { get; set; }
    public int? itemCount { get; set; }
    public int? SumOfRun { get; set; }
    public int? OkeyCount { get; set; }
    public List<Piece> OkeyUsedAs { get; set; }
    public List<Piece> PiecesList { get; set; }

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
    List<Run> RunList = new List<Run>();

    List<Set> SelectedSetList = new List<Set>();
    List<Run> SelectedRunList = new List<Run>();

    public int? total = 0;

    public int consoleCounter = 0;

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

        redPieces.Clear();
        bluePieces.Clear();
        yellowPieces.Clear();
        greenPieces.Clear();
        

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

    public void CleanUpRuns()
    {

        RunList = RunList.OrderBy(x => x.FirstNumber).ToList();
        RunList = RunList.OrderBy(x => x.ColorOfRun).ToList();

        for (int i = 0; i < RunList.Count; i++)
        {
            for (int y = i + 1; y < RunList.Count; y++)
            {

                if (RunList[i].FirstNumber != 0 &&
                    RunList[i].FirstNumber == RunList[y].FirstNumber &&
                    RunList[i].LastNumber == RunList[y].LastNumber &&
                    RunList[i].ColorOfRun == RunList[y].ColorOfRun &&
                    RunList[i].OkeyCount != RunList[y].OkeyCount)
                {
                    if (RunList[i].OkeyCount < RunList[y].OkeyCount)
                    {
                        
                        RunList[y].FirstNumber = 0;
                        RunList[y].LastNumber = 0;

                    }
                    else if (RunList[i].OkeyCount > RunList[y].OkeyCount)
                    {
                        
                        RunList[y].FirstNumber = 0;
                        RunList[y].LastNumber = 0;
                    }

                }

                else if (RunList[i].FirstNumber != 0 &&
                    RunList[i].FirstNumber == RunList[y].FirstNumber &&
                    RunList[i].LastNumber == RunList[y].LastNumber &&
                    RunList[i].ColorOfRun == RunList[y].ColorOfRun &&
                    RunList[i].OkeyCount == RunList[y].OkeyCount)
                {
                    
                    RunList[y].FirstNumber = 0;
                    RunList[y].LastNumber = 0;

                }

            }

        }

        List<Run> tmpRunList2 = new List<Run>();


        foreach (var item in RunList)
        {
            if (item.FirstNumber != 0)
            {
                tmpRunList2.Add(item);
            }
        }
        RunList.Clear();

        foreach (var item in tmpRunList2)
        {
            RunList.Add(item);
        }

        //Console.WriteLine("count: " + RunList.Count);
    }

    public void WriteRuns(List<Run> tmpRunList)
    {
        Console.WriteLine("");
        Console.WriteLine("");

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Seriler");

        Console.WriteLine("");
        Console.WriteLine("");

        foreach (var item in tmpRunList)
        {
            switch (item.ColorOfRun)
            {
                case "Red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "Blue":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case "Yellow":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "Green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
            }

            switch (item.OkeyCount)
            {
                case 0:
                    Console.WriteLine($"[ {item.FirstNumber} - {item.LastNumber} ]");
                    break;
                case 1:
                    Console.WriteLine($"[ {item.FirstNumber} - {item.LastNumber} ]\t\tOkey: {item.OkeyUsedAs[0].Number}");
                    break;
                case 2:
                    Console.WriteLine($"[ {item.FirstNumber} - {item.LastNumber} ]\t\tOkeys: {item.OkeyUsedAs[0].Number}, {item.OkeyUsedAs[1].Number}");
                    break;

            }





            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    public void FindRuns()
    {
        RunList.Clear();
        //Console.WriteLine("Calculating Runs...");
        ChooseTheWayToCalculateRuns(redPieces);
        ChooseTheWayToCalculateRuns(bluePieces);
        ChooseTheWayToCalculateRuns(yellowPieces);
        ChooseTheWayToCalculateRuns(greenPieces);
        CleanUpRuns();
       
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

    public void ChooseTheWayToCalculateRuns(List<Piece> piecesOfColor)
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


    }

    public void RangePacksTwoOkey(List<Piece> piecesOfColor)
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

        int? startNumberIndex = 0;

        int? endNumberIndex = 0;

        startNumber = denemeList[0].Number;

        endNumber = 0;


        okeyList[0].Color = denemeList[0].Color;
        okeyList[1].Color = denemeList[0].Color;

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
                            endNumberIndex = i + 1;
                        }
                        else if (denemeList[i + 1].Number - denemeList[i].Number == 0)
                        {
                            endNumber = denemeList[i + 1].Number;
                            endNumberIndex = i + 1;
                        }
                        else
                        {
                            if (endNumber - startNumber >= 2) // check if the range has 3 or more elements
                            {
                                AddRun(i, startNumber, endNumber, startNumberIndex, endNumberIndex, 2);
                            }

                            startNumber = denemeList[i + 1].Number;
                            startNumberIndex = i + 1;
                        }

                    }
                    else if (i + 1 == denemeList.Count) //last item on the list
                    {

                        if (denemeList[i].Number - denemeList[i - 1].Number == 1)
                        {

                            endNumber = denemeList[i].Number;
                            endNumberIndex = i;

                            if (endNumber - startNumber >= 2) // check if the range has 3 or more elements
                            {
                                AddRun(i, startNumber, endNumber, startNumberIndex, endNumberIndex, 2);
                            }

                        }
                        else if (denemeList[i].Number - denemeList[i - 1].Number == 0)
                        {
                            endNumber = denemeList[i].Number;
                            endNumberIndex = i;

                            if (endNumber - startNumber >= 2) // check if the range has 3 or more elements
                            {
                                AddRun(i, startNumber, endNumber, startNumberIndex, endNumberIndex, 2);
                            }
                        }


                    }


                }


            }

        }




    yeterliTasYok:

        denemeList.Clear();





    }

    public void RangePacksOneOkey(List<Piece> piecesOfColor)
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

        int? startNumberIndex = 0;

        int? endNumberIndex = 0;

        startNumber = denemeList[0].Number;

        endNumber = 0;

        okeyList[0].Color = denemeList[0].Color;

        denemeList.Add(okeyList[0]);



        for (int y = 1; y <= 13; y++)
        {

            okeyList[0].Number = y;

            denemeList = denemeList.OrderBy(x => x.Number).ToList();

            startNumber = denemeList[0].Number;

            endNumber = 0;


            for (int i = 0; i <= denemeList.Count; i++)
            {

                if (i + 1 < denemeList.Count)
                {
                    if (denemeList[i + 1].Number - denemeList[i].Number == 1)
                    {
                        endNumber = denemeList[i + 1].Number;
                        endNumberIndex = i + 1;
                    }
                    else if (denemeList[i + 1].Number - denemeList[i].Number == 0)
                    {
                        endNumber = denemeList[i + 1].Number;
                        endNumberIndex = i + 1;
                    }
                    else
                    {
                        if (endNumber - startNumber >= 2) // check if the range has 3 or more elements
                        {
                            AddRun(i, startNumber, endNumber, startNumberIndex, endNumberIndex, 1);
                        }

                        startNumber = denemeList[i + 1].Number;
                        startNumberIndex = i + 1;
                    }

                }
                else if (i + 1 == denemeList.Count) //last item on the list
                {

                    if (denemeList[i].Number - denemeList[i - 1].Number == 1)
                    {

                        endNumber = denemeList[i].Number;
                        endNumberIndex = i;

                        if (endNumber - startNumber >= 2) // check if the range has 3 or more elements
                        {
                            AddRun(i, startNumber, endNumber, startNumberIndex, endNumberIndex, 1);
                        }

                    }
                    else if (denemeList[i].Number - denemeList[i - 1].Number == 0)
                    {
                        endNumber = denemeList[i].Number;
                        endNumberIndex = i;

                        if (endNumber - startNumber >= 2) // check if the range has 3 or more elements
                        {
                            AddRun(i, startNumber, endNumber, startNumberIndex, endNumberIndex, 1);
                        }
                    }


                }


            }




        }

    yeterliTasYok:

        denemeList.Clear();



    }

    public void RangePacksWithoutOkey(List<Piece> piecesOfColor)
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

        int? startNumberIndex = 0;

        int? endNumberIndex = 0;

        startNumber = denemeList[0].Number;

        endNumber = 0;


        for (int i = 0; i <= denemeList.Count; i++)
        {

            if (i + 1 < denemeList.Count)
            {
                if (denemeList[i + 1].Number - denemeList[i].Number == 1)
                {
                    endNumber = denemeList[i + 1].Number;
                    endNumberIndex = i + 1;
                }
                else if (denemeList[i + 1].Number - denemeList[i].Number == 0)
                {
                    endNumber = denemeList[i + 1].Number;
                    endNumberIndex = i + 1;
                }
                else
                {
                    if (endNumber - startNumber >= 2) // check if the range has 3 or more elements
                    {

                        AddRun(i, startNumber, endNumber, startNumberIndex, endNumberIndex, 0);

                    }

                    startNumber = denemeList[i + 1].Number;
                    startNumberIndex = i + 1;
                }

            }
            else if (i + 1 == denemeList.Count) //last item on the list
            {

                if (denemeList[i].Number - denemeList[i - 1].Number == 1)
                {

                    endNumber = denemeList[i].Number;
                    endNumberIndex = i;

                    if (endNumber - startNumber >= 2) // check if the range has 3 or more elements
                    {
                        AddRun(i, startNumber, endNumber, startNumberIndex, endNumberIndex, 0);
                    }

                }
                else if (denemeList[i].Number - denemeList[i - 1].Number == 0)
                {
                    endNumber = denemeList[i].Number;
                    endNumberIndex = i;

                    if (endNumber - startNumber >= 2) // check if the range has 3 or more elements
                    {
                        AddRun(i, startNumber, endNumber, startNumberIndex, endNumberIndex, 0);
                    }
                }


            }


        }




    yeterliTasYok2:

        denemeList.Clear();


    }

    public void AddRun(int i,
                       int? startNumber,
                       int? endNumber,
                       int? startNumberIndex,
                       int? endNumberIndex,
                       int okeyC)
    {
        Piece tmpPiece;
        Run tmpRun;
        tmpRun = new Run();
        tmpRun.OkeyUsedAs = new List<Piece>();
        tmpRun.PiecesList = new List<Piece>();
        tmpRun.ColorOfRun = denemeList[0].Color;
        tmpRun.FirstNumber = startNumber;
        tmpRun.LastNumber = endNumber;

        tmpRun.OkeyCount = okeyC;

        if (okeyC == 1)
        {

            tmpPiece = new Piece();
            tmpPiece.Number = okeyList[0].Number;
            tmpPiece.Color = denemeList[0].Color;
            tmpPiece.IsFakeOkey = false;
            tmpPiece.IsOkey = true;
            tmpRun.OkeyUsedAs.Add(tmpPiece);

        }
        else if (okeyC == 2)
        {
            tmpPiece = new Piece();
            tmpPiece.Number = okeyList[0].Number;
            tmpPiece.Color = denemeList[0].Color;
            tmpPiece.IsFakeOkey = false;
            tmpPiece.IsOkey = true;

            tmpRun.OkeyUsedAs.Add(tmpPiece);

            tmpPiece = new Piece();
            tmpPiece.Number = okeyList[1].Number;
            tmpPiece.Color = denemeList[0].Color;
            tmpPiece.IsFakeOkey = false;
            tmpPiece.IsOkey = true;

            tmpRun.OkeyUsedAs.Add(tmpPiece);
        }

        tmpRun.itemCount = (endNumber - startNumber + 1);
        tmpRun.SumOfRun = (tmpRun.itemCount / 2) * (startNumber + endNumber);

        for (int? j = startNumberIndex; j <= endNumberIndex; j++)
        {

            tmpPiece = new Piece();
            tmpPiece.Number = denemeList[(int)(j)].Number;
            tmpPiece.Color = denemeList[0].Color;
            tmpPiece.IsFakeOkey = denemeList[(int)(j)].IsFakeOkey;
            tmpPiece.IsOkey = denemeList[(int)(j)].IsOkey;

            tmpRun.PiecesList.Add(tmpPiece);

        }


        RunList.Add(tmpRun);
    }

    public void AddSet(int i,
                       bool C1,
                       bool C2,
                       bool C3,
                       bool C4,
                       int okeyC)
    {
        //create empty set
        Piece tmpPiece;
        Set tmpSet;
        tmpSet = new Set();
        tmpSet.PiecesList = new List<Piece>();
        tmpSet.OkeyUsedAs = new List<Piece>();
        tmpSet.Number = 0;
        tmpSet.Color1 = false;
        tmpSet.Color2 = false;
        tmpSet.Color3 = false;
        tmpSet.Color4 = false;
        tmpSet.OkeyCount = 0;
        tmpSet.itemCount = 0;
        tmpSet.SumOfSet = 0;



        //fill the set by parameters

        tmpSet.Number = i;
        tmpSet.Color1 = C1;
        tmpSet.Color2 = C2;
        tmpSet.Color3 = C3;
        tmpSet.Color4 = C4;
        tmpSet.OkeyCount = okeyC;

        if (C1) tmpSet.itemCount++;
        if (C2) tmpSet.itemCount++;
        if (C3) tmpSet.itemCount++;
        if (C4) tmpSet.itemCount++;

        tmpSet.SumOfSet = tmpSet.itemCount * tmpSet.Number;

        if (okeyC == 1)
        {

            tmpPiece = new Piece();
            tmpPiece.Number = okeyList[0].Number;
            tmpPiece.Color = okeyList[0].Color;
            tmpPiece.IsFakeOkey = false;
            tmpPiece.IsOkey = true;
            tmpSet.OkeyUsedAs.Add(tmpPiece);

        }
        else if (okeyC == 2)
        {
            tmpPiece = new Piece();
            tmpPiece.Number = okeyList[0].Number;
            tmpPiece.Color = okeyList[0].Color;
            tmpPiece.IsFakeOkey = false;
            tmpPiece.IsOkey = true;

            tmpSet.OkeyUsedAs.Add(tmpPiece);

            tmpPiece = new Piece();
            tmpPiece.Number = okeyList[1].Number;
            tmpPiece.Color = okeyList[1].Color;
            tmpPiece.IsFakeOkey = false;
            tmpPiece.IsOkey = true;

            tmpSet.OkeyUsedAs.Add(tmpPiece);
        }


        if (tmpSet.itemCount >= 3) SetList.Add(tmpSet);


    }


    public void FindSetsWithoutOkey()
    {

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

            bool Color1 = false;
            bool Color2 = false;
            bool Color3 = false;
            bool Color4 = false;


            #region // set the color if exist

            foreach (var item in tmpRedList)
            {
                if (item.Number == i)
                {
                    Color1 = true;
                }
            }

            foreach (var item in tmpBlueList)
            {
                if (item.Number == i)
                {
                    Color2 = true;
                }
            }

            foreach (var item in tmpYellowList)
            {
                if (item.Number == i)
                {
                    Color3 = true;
                }
            }

            foreach (var item in tmpGreenList)
            {
                if (item.Number == i)
                {
                    Color4 = true;
                }
            }

            #endregion

            // adding the set to setlist

            AddSet(i, Color1, Color2, Color3, Color4, 0);

        }

        tmpRedList.Clear();
        tmpBlueList.Clear();
        tmpYellowList.Clear();
        tmpGreenList.Clear();



    }

    public void FindSetsWithOneOkey()
    {

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
                bool Color1 = false;
                bool Color2 = false;
                bool Color3 = false;
                bool Color4 = false;

                if (colorOfOkey1 == 1)
                {
                    tmpRedList.Add(okeyList[0]);
                    okeyList[0].Number = i;
                    okeyList[0].Color = "Red";


                    #region // set the color if exist

                    foreach (var item in tmpRedList)
                    {
                        if (item.Number == i)
                        {
                            Color1 = true;
                        }
                    }

                    foreach (var item in tmpBlueList)
                    {
                        if (item.Number == i)
                        {
                            Color2 = true;
                        }
                    }

                    foreach (var item in tmpYellowList)
                    {
                        if (item.Number == i)
                        {
                            Color3 = true;
                        }
                    }

                    foreach (var item in tmpGreenList)
                    {
                        if (item.Number == i)
                        {
                            Color4 = true;
                        }
                    }

                    #endregion

                    // adding the set to setlist

                    AddSet(i, Color1, Color2, Color3, Color4, 1);
                    tmpRedList.Remove(okeyList[0]);


                }

                if (colorOfOkey1 == 2)
                {
                    tmpBlueList.Add(okeyList[0]);
                    okeyList[0].Number = i;
                    okeyList[0].Color = "Blue";


                    #region // set the color if exist

                    foreach (var item in tmpRedList)
                    {
                        if (item.Number == i)
                        {
                            Color1 = true;
                        }
                    }

                    foreach (var item in tmpBlueList)
                    {
                        if (item.Number == i)
                        {
                            Color2 = true;
                        }
                    }

                    foreach (var item in tmpYellowList)
                    {
                        if (item.Number == i)
                        {
                            Color3 = true;
                        }
                    }

                    foreach (var item in tmpGreenList)
                    {
                        if (item.Number == i)
                        {
                            Color4 = true;
                        }
                    }

                    #endregion

                    // adding the set to setlist

                    AddSet(i, Color1, Color2, Color3, Color4, 1);
                    tmpBlueList.Remove(okeyList[0]);


                }

                if (colorOfOkey1 == 3)
                {
                    tmpYellowList.Add(okeyList[0]);
                    okeyList[0].Number = i;
                    okeyList[0].Color = "Yellow";


                    #region // set the color if exist

                    foreach (var item in tmpRedList)
                    {
                        if (item.Number == i)
                        {
                            Color1 = true;
                        }
                    }

                    foreach (var item in tmpBlueList)
                    {
                        if (item.Number == i)
                        {
                            Color2 = true;
                        }
                    }

                    foreach (var item in tmpYellowList)
                    {
                        if (item.Number == i)
                        {
                            Color3 = true;
                        }
                    }

                    foreach (var item in tmpGreenList)
                    {
                        if (item.Number == i)
                        {
                            Color4 = true;
                        }
                    }

                    #endregion

                    // adding the set to setlist

                    AddSet(i, Color1, Color2, Color3, Color4, 1);
                    tmpYellowList.Remove(okeyList[0]);


                }

                if (colorOfOkey1 == 4)
                {
                    tmpGreenList.Add(okeyList[0]);
                    okeyList[0].Number = i;
                    okeyList[0].Color = "Green";


                    #region // set the color if exist

                    foreach (var item in tmpRedList)
                    {
                        if (item.Number == i)
                        {
                            Color1 = true;
                        }
                    }

                    foreach (var item in tmpBlueList)
                    {
                        if (item.Number == i)
                        {
                            Color2 = true;
                        }
                    }

                    foreach (var item in tmpYellowList)
                    {
                        if (item.Number == i)
                        {
                            Color3 = true;
                        }
                    }

                    foreach (var item in tmpGreenList)
                    {
                        if (item.Number == i)
                        {
                            Color4 = true;
                        }
                    }

                    #endregion

                    // adding the set to setlist

                    AddSet(i, Color1, Color2, Color3, Color4, 1);
                    tmpGreenList.Remove(okeyList[0]);


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

                    tmpRedList.Add(okeyList[1]);
                    okeyList[1].Number = i;
                    okeyList[1].Color = "Red";


                    for (int colorOfOkey1 = 1; colorOfOkey1 <= 4; colorOfOkey1++)
                    {
                        bool Color1 = false;
                        bool Color2 = false;
                        bool Color3 = false;
                        bool Color4 = false;

                        if (colorOfOkey1 == 1)
                        {
                            tmpRedList.Add(okeyList[0]);
                            okeyList[0].Number = i;
                            okeyList[0].Color = "Red";

                            #region // set the color if exist

                            foreach (var item in tmpRedList)
                            {
                                if (item.Number == i)
                                {
                                    Color1 = true;
                                }
                            }

                            foreach (var item in tmpBlueList)
                            {
                                if (item.Number == i)
                                {
                                    Color2 = true;
                                }
                            }

                            foreach (var item in tmpYellowList)
                            {
                                if (item.Number == i)
                                {
                                    Color3 = true;
                                }
                            }

                            foreach (var item in tmpGreenList)
                            {
                                if (item.Number == i)
                                {
                                    Color4 = true;
                                }
                            }

                            #endregion

                            // adding the set to setlist


                            AddSet(i, Color1, Color2, Color3, Color4, 2);


                            tmpRedList.Remove(okeyList[0]);

                        }

                        if (colorOfOkey1 == 2)
                        {
                            tmpBlueList.Add(okeyList[0]);
                            okeyList[0].Number = i;
                            okeyList[0].Color = "Blue";


                            #region // set the color if exist

                            foreach (var item in tmpRedList)
                            {
                                if (item.Number == i)
                                {
                                    Color1 = true;
                                }
                            }

                            foreach (var item in tmpBlueList)
                            {
                                if (item.Number == i)
                                {
                                    Color2 = true;
                                }
                            }

                            foreach (var item in tmpYellowList)
                            {
                                if (item.Number == i)
                                {
                                    Color3 = true;
                                }
                            }

                            foreach (var item in tmpGreenList)
                            {
                                if (item.Number == i)
                                {
                                    Color4 = true;
                                }
                            }

                            #endregion

                            // adding the set to setlist

                            AddSet(i, Color1, Color2, Color3, Color4, 2);
                            tmpBlueList.Remove(okeyList[0]);


                        }

                        if (colorOfOkey1 == 3)
                        {
                            tmpYellowList.Add(okeyList[0]);
                            okeyList[0].Number = i;
                            okeyList[0].Color = "Yellow";


                            #region // set the color if exist

                            foreach (var item in tmpRedList)
                            {
                                if (item.Number == i)
                                {
                                    Color1 = true;
                                }
                            }

                            foreach (var item in tmpBlueList)
                            {
                                if (item.Number == i)
                                {
                                    Color2 = true;
                                }
                            }

                            foreach (var item in tmpYellowList)
                            {
                                if (item.Number == i)
                                {
                                    Color3 = true;
                                }
                            }

                            foreach (var item in tmpGreenList)
                            {
                                if (item.Number == i)
                                {
                                    Color4 = true;
                                }
                            }

                            #endregion

                            // adding the set to setlist

                            AddSet(i, Color1, Color2, Color3, Color4, 2);
                            tmpYellowList.Remove(okeyList[0]);


                        }

                        if (colorOfOkey1 == 4)
                        {
                            tmpGreenList.Add(okeyList[0]);
                            okeyList[0].Number = i;
                            okeyList[0].Color = "Green";


                            #region // set the color if exist

                            foreach (var item in tmpRedList)
                            {
                                if (item.Number == i)
                                {
                                    Color1 = true;
                                }
                            }

                            foreach (var item in tmpBlueList)
                            {
                                if (item.Number == i)
                                {
                                    Color2 = true;
                                }
                            }

                            foreach (var item in tmpYellowList)
                            {
                                if (item.Number == i)
                                {
                                    Color3 = true;
                                }
                            }

                            foreach (var item in tmpGreenList)
                            {
                                if (item.Number == i)
                                {
                                    Color4 = true;
                                }
                            }

                            #endregion

                            // adding the set to setlist

                            AddSet(i, Color1, Color2, Color3, Color4, 2);
                            tmpGreenList.Remove(okeyList[0]);


                        }

                    }

                    tmpRedList.Remove(okeyList[1]);

                }

                if (colorOfOkey2 == 2)
                {

                    tmpBlueList.Add(okeyList[1]);
                    okeyList[1].Number = i;
                    okeyList[1].Color = "Blue";


                    for (int colorOfOkey1 = 1; colorOfOkey1 <= 4; colorOfOkey1++)
                    {
                        bool Color1 = false;
                        bool Color2 = false;
                        bool Color3 = false;
                        bool Color4 = false;

                        if (colorOfOkey1 == 1)
                        {
                            tmpRedList.Add(okeyList[0]);
                            okeyList[0].Number = i;
                            okeyList[0].Color = "Red";

                            #region // set the color if exist

                            foreach (var item in tmpRedList)
                            {
                                if (item.Number == i)
                                {
                                    Color1 = true;
                                }
                            }

                            foreach (var item in tmpBlueList)
                            {
                                if (item.Number == i)
                                {
                                    Color2 = true;
                                }
                            }

                            foreach (var item in tmpYellowList)
                            {
                                if (item.Number == i)
                                {
                                    Color3 = true;
                                }
                            }

                            foreach (var item in tmpGreenList)
                            {
                                if (item.Number == i)
                                {
                                    Color4 = true;
                                }
                            }

                            #endregion

                            // adding the set to setlist


                            AddSet(i, Color1, Color2, Color3, Color4, 2);


                            tmpRedList.Remove(okeyList[0]);

                        }

                        if (colorOfOkey1 == 2)
                        {
                            tmpBlueList.Add(okeyList[0]);
                            okeyList[0].Number = i;
                            okeyList[0].Color = "Blue";


                            #region // set the color if exist

                            foreach (var item in tmpRedList)
                            {
                                if (item.Number == i)
                                {
                                    Color1 = true;
                                }
                            }

                            foreach (var item in tmpBlueList)
                            {
                                if (item.Number == i)
                                {
                                    Color2 = true;
                                }
                            }

                            foreach (var item in tmpYellowList)
                            {
                                if (item.Number == i)
                                {
                                    Color3 = true;
                                }
                            }

                            foreach (var item in tmpGreenList)
                            {
                                if (item.Number == i)
                                {
                                    Color4 = true;
                                }
                            }

                            #endregion

                            // adding the set to setlist

                            AddSet(i, Color1, Color2, Color3, Color4, 2);
                            tmpBlueList.Remove(okeyList[0]);


                        }

                        if (colorOfOkey1 == 3)
                        {
                            tmpYellowList.Add(okeyList[0]);
                            okeyList[0].Number = i;
                            okeyList[0].Color = "Yellow";


                            #region // set the color if exist

                            foreach (var item in tmpRedList)
                            {
                                if (item.Number == i)
                                {
                                    Color1 = true;
                                }
                            }

                            foreach (var item in tmpBlueList)
                            {
                                if (item.Number == i)
                                {
                                    Color2 = true;
                                }
                            }

                            foreach (var item in tmpYellowList)
                            {
                                if (item.Number == i)
                                {
                                    Color3 = true;
                                }
                            }

                            foreach (var item in tmpGreenList)
                            {
                                if (item.Number == i)
                                {
                                    Color4 = true;
                                }
                            }

                            #endregion

                            // adding the set to setlist

                            AddSet(i, Color1, Color2, Color3, Color4, 2);
                            tmpYellowList.Remove(okeyList[0]);


                        }

                        if (colorOfOkey1 == 4)
                        {
                            tmpGreenList.Add(okeyList[0]);
                            okeyList[0].Number = i;
                            okeyList[0].Color = "Green";


                            #region // set the color if exist

                            foreach (var item in tmpRedList)
                            {
                                if (item.Number == i)
                                {
                                    Color1 = true;
                                }
                            }

                            foreach (var item in tmpBlueList)
                            {
                                if (item.Number == i)
                                {
                                    Color2 = true;
                                }
                            }

                            foreach (var item in tmpYellowList)
                            {
                                if (item.Number == i)
                                {
                                    Color3 = true;
                                }
                            }

                            foreach (var item in tmpGreenList)
                            {
                                if (item.Number == i)
                                {
                                    Color4 = true;
                                }
                            }

                            #endregion

                            // adding the set to setlist

                            AddSet(i, Color1, Color2, Color3, Color4, 2);
                            tmpGreenList.Remove(okeyList[0]);


                        }

                    }

                    tmpBlueList.Remove(okeyList[1]);

                }

                if (colorOfOkey2 == 3)
                {

                    tmpYellowList.Add(okeyList[1]);
                    okeyList[1].Number = i;
                    okeyList[1].Color = "Yellow";


                    for (int colorOfOkey1 = 1; colorOfOkey1 <= 4; colorOfOkey1++)
                    {
                        bool Color1 = false;
                        bool Color2 = false;
                        bool Color3 = false;
                        bool Color4 = false;

                        if (colorOfOkey1 == 1)
                        {
                            tmpRedList.Add(okeyList[0]);
                            okeyList[0].Number = i;
                            okeyList[0].Color = "Red";

                            #region // set the color if exist

                            foreach (var item in tmpRedList)
                            {
                                if (item.Number == i)
                                {
                                    Color1 = true;
                                }
                            }

                            foreach (var item in tmpBlueList)
                            {
                                if (item.Number == i)
                                {
                                    Color2 = true;
                                }
                            }

                            foreach (var item in tmpYellowList)
                            {
                                if (item.Number == i)
                                {
                                    Color3 = true;
                                }
                            }

                            foreach (var item in tmpGreenList)
                            {
                                if (item.Number == i)
                                {
                                    Color4 = true;
                                }
                            }

                            #endregion

                            // adding the set to setlist


                            AddSet(i, Color1, Color2, Color3, Color4, 2);


                            tmpRedList.Remove(okeyList[0]);

                        }

                        if (colorOfOkey1 == 2)
                        {
                            tmpBlueList.Add(okeyList[0]);
                            okeyList[0].Number = i;
                            okeyList[0].Color = "Blue";


                            #region // set the color if exist

                            foreach (var item in tmpRedList)
                            {
                                if (item.Number == i)
                                {
                                    Color1 = true;
                                }
                            }

                            foreach (var item in tmpBlueList)
                            {
                                if (item.Number == i)
                                {
                                    Color2 = true;
                                }
                            }

                            foreach (var item in tmpYellowList)
                            {
                                if (item.Number == i)
                                {
                                    Color3 = true;
                                }
                            }

                            foreach (var item in tmpGreenList)
                            {
                                if (item.Number == i)
                                {
                                    Color4 = true;
                                }
                            }

                            #endregion

                            // adding the set to setlist

                            AddSet(i, Color1, Color2, Color3, Color4, 2);
                            tmpBlueList.Remove(okeyList[0]);


                        }

                        if (colorOfOkey1 == 3)
                        {
                            tmpYellowList.Add(okeyList[0]);
                            okeyList[0].Number = i;
                            okeyList[0].Color = "Yellow";


                            #region // set the color if exist

                            foreach (var item in tmpRedList)
                            {
                                if (item.Number == i)
                                {
                                    Color1 = true;
                                }
                            }

                            foreach (var item in tmpBlueList)
                            {
                                if (item.Number == i)
                                {
                                    Color2 = true;
                                }
                            }

                            foreach (var item in tmpYellowList)
                            {
                                if (item.Number == i)
                                {
                                    Color3 = true;
                                }
                            }

                            foreach (var item in tmpGreenList)
                            {
                                if (item.Number == i)
                                {
                                    Color4 = true;
                                }
                            }

                            #endregion

                            // adding the set to setlist

                            AddSet(i, Color1, Color2, Color3, Color4, 2);
                            tmpYellowList.Remove(okeyList[0]);


                        }

                        if (colorOfOkey1 == 4)
                        {
                            tmpGreenList.Add(okeyList[0]);
                            okeyList[0].Number = i;
                            okeyList[0].Color = "Green";


                            #region // set the color if exist

                            foreach (var item in tmpRedList)
                            {
                                if (item.Number == i)
                                {
                                    Color1 = true;
                                }
                            }

                            foreach (var item in tmpBlueList)
                            {
                                if (item.Number == i)
                                {
                                    Color2 = true;
                                }
                            }

                            foreach (var item in tmpYellowList)
                            {
                                if (item.Number == i)
                                {
                                    Color3 = true;
                                }
                            }

                            foreach (var item in tmpGreenList)
                            {
                                if (item.Number == i)
                                {
                                    Color4 = true;
                                }
                            }

                            #endregion

                            // adding the set to setlist

                            AddSet(i, Color1, Color2, Color3, Color4, 2);
                            tmpGreenList.Remove(okeyList[0]);


                        }

                    }

                    tmpYellowList.Remove(okeyList[1]);

                }

                if (colorOfOkey2 == 4)
                {

                    tmpGreenList.Add(okeyList[1]);
                    okeyList[1].Number = i;
                    okeyList[1].Color = "Green";


                    for (int colorOfOkey1 = 1; colorOfOkey1 <= 4; colorOfOkey1++)
                    {
                        bool Color1 = false;
                        bool Color2 = false;
                        bool Color3 = false;
                        bool Color4 = false;

                        if (colorOfOkey1 == 1)
                        {
                            tmpRedList.Add(okeyList[0]);
                            okeyList[0].Number = i;
                            okeyList[0].Color = "Red";

                            #region // set the color if exist

                            foreach (var item in tmpRedList)
                            {
                                if (item.Number == i)
                                {
                                    Color1 = true;
                                }
                            }

                            foreach (var item in tmpBlueList)
                            {
                                if (item.Number == i)
                                {
                                    Color2 = true;
                                }
                            }

                            foreach (var item in tmpYellowList)
                            {
                                if (item.Number == i)
                                {
                                    Color3 = true;
                                }
                            }

                            foreach (var item in tmpGreenList)
                            {
                                if (item.Number == i)
                                {
                                    Color4 = true;
                                }
                            }

                            #endregion

                            // adding the set to setlist


                            AddSet(i, Color1, Color2, Color3, Color4, 2);


                            tmpRedList.Remove(okeyList[0]);

                        }

                        if (colorOfOkey1 == 2)
                        {
                            tmpBlueList.Add(okeyList[0]);
                            okeyList[0].Number = i;
                            okeyList[0].Color = "Blue";


                            #region // set the color if exist

                            foreach (var item in tmpRedList)
                            {
                                if (item.Number == i)
                                {
                                    Color1 = true;
                                }
                            }

                            foreach (var item in tmpBlueList)
                            {
                                if (item.Number == i)
                                {
                                    Color2 = true;
                                }
                            }

                            foreach (var item in tmpYellowList)
                            {
                                if (item.Number == i)
                                {
                                    Color3 = true;
                                }
                            }

                            foreach (var item in tmpGreenList)
                            {
                                if (item.Number == i)
                                {
                                    Color4 = true;
                                }
                            }

                            #endregion

                            // adding the set to setlist

                            AddSet(i, Color1, Color2, Color3, Color4, 2);
                            tmpBlueList.Remove(okeyList[0]);


                        }

                        if (colorOfOkey1 == 3)
                        {
                            tmpYellowList.Add(okeyList[0]);
                            okeyList[0].Number = i;
                            okeyList[0].Color = "Yellow";


                            #region // set the color if exist

                            foreach (var item in tmpRedList)
                            {
                                if (item.Number == i)
                                {
                                    Color1 = true;
                                }
                            }

                            foreach (var item in tmpBlueList)
                            {
                                if (item.Number == i)
                                {
                                    Color2 = true;
                                }
                            }

                            foreach (var item in tmpYellowList)
                            {
                                if (item.Number == i)
                                {
                                    Color3 = true;
                                }
                            }

                            foreach (var item in tmpGreenList)
                            {
                                if (item.Number == i)
                                {
                                    Color4 = true;
                                }
                            }

                            #endregion

                            // adding the set to setlist

                            AddSet(i, Color1, Color2, Color3, Color4, 2);
                            tmpYellowList.Remove(okeyList[0]);


                        }

                        if (colorOfOkey1 == 4)
                        {
                            tmpGreenList.Add(okeyList[0]);
                            okeyList[0].Number = i;
                            okeyList[0].Color = "Green";


                            #region // set the color if exist

                            foreach (var item in tmpRedList)
                            {
                                if (item.Number == i)
                                {
                                    Color1 = true;
                                }
                            }

                            foreach (var item in tmpBlueList)
                            {
                                if (item.Number == i)
                                {
                                    Color2 = true;
                                }
                            }

                            foreach (var item in tmpYellowList)
                            {
                                if (item.Number == i)
                                {
                                    Color3 = true;
                                }
                            }

                            foreach (var item in tmpGreenList)
                            {
                                if (item.Number == i)
                                {
                                    Color4 = true;
                                }
                            }

                            #endregion

                            // adding the set to setlist

                            AddSet(i, Color1, Color2, Color3, Color4, 2);
                            tmpGreenList.Remove(okeyList[0]);


                        }

                    }

                    tmpGreenList.Remove(okeyList[1]);

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
        //Console.WriteLine("Calculating Sets...");

        SetList.Clear();

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
            for (int y = i + 1; y < SetList.Count; y++)
            {

                if (i != y &&
                   SetList[i].Number == SetList[y].Number &&
                   SetList[i].Color1 == SetList[y].Color1 &&
                   SetList[i].Color2 == SetList[y].Color2 &&
                   SetList[i].Color3 == SetList[y].Color3 &&
                   SetList[i].Color4 == SetList[y].Color4 &&
                   SetList[i].OkeyCount != SetList[y].OkeyCount)
                {

                    if (SetList[i].OkeyCount < SetList[y].OkeyCount)
                    {
                        SetList.Remove(SetList[y]);
                    }
                    else
                    {
                        SetList.Remove(SetList[i]);
                    }



                }
                else if (i != y &&
                        SetList[i].Number == SetList[y].Number &&
                        SetList[i].Color1 == SetList[y].Color1 &&
                        SetList[i].Color2 == SetList[y].Color2 &&
                        SetList[i].Color3 == SetList[y].Color3 &&
                        SetList[i].Color4 == SetList[y].Color4 &&
                        SetList[i].OkeyCount == SetList[y].OkeyCount)
                {

                    SetList.Remove(SetList[y]);
                }


            }

        }


    }

    public void WriteSets(List<Set> tmpSetList)
    {
        Console.WriteLine("");
        Console.WriteLine("");

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Kütler");

        Console.WriteLine("");

        foreach (var item in tmpSetList)
        {
            Console.WriteLine("");
            Console.Write("[");

            if (item.Color1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($" {item.Number} ");
            }

            if (item.Color2)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($" {item.Number} ");
            }

            if (item.Color3)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($" {item.Number} ");
            }

            if (item.Color4)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($" {item.Number} ");
            }



            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("]");

            switch (item.OkeyCount)
            {
                case 1:
                    Console.Write($"\t\tOkey: ");
                    if (item.OkeyUsedAs[0].Color == "Red") Console.ForegroundColor = ConsoleColor.Red;
                    if (item.OkeyUsedAs[0].Color == "Blue") Console.ForegroundColor = ConsoleColor.Cyan;
                    if (item.OkeyUsedAs[0].Color == "Yellow") Console.ForegroundColor = ConsoleColor.Yellow;
                    if (item.OkeyUsedAs[0].Color == "Green") Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{item.OkeyUsedAs[0].Number}");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;

                case 2:
                    Console.Write($"\t\tOkeys: ");
                    if (item.OkeyUsedAs[0].Color == "Red") Console.ForegroundColor = ConsoleColor.Red;
                    if (item.OkeyUsedAs[0].Color == "Blue") Console.ForegroundColor = ConsoleColor.Cyan;
                    if (item.OkeyUsedAs[0].Color == "Yellow") Console.ForegroundColor = ConsoleColor.Yellow;
                    if (item.OkeyUsedAs[0].Color == "Green") Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{item.OkeyUsedAs[0].Number}");
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.Write(", ");
                    if (item.OkeyUsedAs[1].Color == "Red") Console.ForegroundColor = ConsoleColor.Red;
                    if (item.OkeyUsedAs[1].Color == "Blue") Console.ForegroundColor = ConsoleColor.Cyan;
                    if (item.OkeyUsedAs[1].Color == "Yellow") Console.ForegroundColor = ConsoleColor.Yellow;
                    if (item.OkeyUsedAs[1].Color == "Green") Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{item.OkeyUsedAs[1].Number}");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;


            }


            Console.ForegroundColor = ConsoleColor.White;


        }

        Console.WriteLine("");
        Console.WriteLine("");



    }

    public void PickAndPlace()
    {
        string lastAdded = "";

        FindOkeyCount();
        FindRuns();
        FindSets();

        do
        {

            //Console.WriteLine("Run Count: " + RunList.Count);
            //Console.WriteLine("Set Count: " + SetList.Count);
            ShowPlayersPiecesInRows();

            if (RunList.Count != 0 && SetList.Count != 0)
            {
                RunList = RunList.OrderByDescending(x => x.SumOfRun).ToList();
                SetList = SetList.OrderByDescending(x => x.SumOfSet).ToList();


                if (RunList[0].SumOfRun == SetList[0].SumOfSet)
                {
                    SelectedRunList.Add(RunList[0]);
                    lastAdded = "Run";
                    total += RunList[0].SumOfRun;
                }
                else if (RunList[0].SumOfRun > SetList[0].SumOfSet)
                {
                    SelectedRunList.Add(RunList[0]);
                    lastAdded = "Run";
                    total += RunList[0].SumOfRun;
                }
                else if (RunList[0].SumOfRun < SetList[0].SumOfSet)
                {
                    SelectedSetList.Add(SetList[0]);
                    lastAdded = "Set";
                    total += SetList[0].SumOfSet;
                }

            }
            else if (RunList.Count != 0)
            {
                RunList = RunList.OrderByDescending(x => x.SumOfRun).ToList();
                SelectedRunList.Add(RunList[0]);
                lastAdded = "Run";
                total += RunList[0].SumOfRun;
            }
            else if (SetList.Count != 0)
            {
                SetList = SetList.OrderByDescending(x => x.SumOfSet).ToList();
                SelectedSetList.Add(SetList[0]);
                lastAdded = "Set";
                total += SetList[0].SumOfSet;
            }
            else
            {
                lastAdded = "";
            }


            if (lastAdded == "Run")
            {
                RemoveItemsFromPlayerPieces(RunList[0], null);
            }
            else if (lastAdded == "Set")
            {
                RemoveItemsFromPlayerPieces(null, SetList[0]);
            }

            ArrangePlayerPieces();
            SeperateColorsOfPlayersPieces();
            FindOkeyCount();
            FindRuns();
            FindSets();
        }
        while (RunList.Count != 0 || SetList.Count != 0);



        //yazdır


        WriteRuns(SelectedRunList);
        WriteSets(SelectedSetList);

        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine($"Elin toplamı: {total}");

    }

    public void RemoveItemsFromPlayerPieces(Run tmpRun, Set tmpSet)
    {
        if (tmpRun != null)
        {
            #region //remove okey if it used

            if (tmpRun.OkeyCount == 1)
            {
                playersPieces.Remove(playersPieces.Find(x => x.IsOkey));
            }
            else if (tmpRun.OkeyCount == 2)
            {
                foreach (var item in playersPieces)
                {
                    if (item.IsOkey)
                    {
                        playersPieces.Remove(item);
                    }
                }

            }

            #endregion

            foreach (var item in tmpRun.PiecesList)
            {
                playersPieces.Remove(playersPieces.Find(x => x.Number == item.Number && x.Color == item.Color));
            }

        }

        else if (tmpSet != null)
        {
            #region //remove okey if it used

            if (tmpSet.OkeyCount == 1)
            {
                playersPieces.Remove(playersPieces.Find(x => x.IsOkey = true));
                FindOkeyCount();
            }
            else if (tmpSet.OkeyCount == 2)
            {
                foreach (var item in playersPieces)
                {
                    if (item.IsOkey)
                    {
                        playersPieces.Remove(item);
                    }
                    FindOkeyCount();
                }

            }

            #endregion

            foreach (var item in tmpSet.PiecesList)
            {
                playersPieces.Remove(playersPieces.Find(x => x.Number == item.Number && x.Color == item.Color));
            }

        }

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

        //a.ShowPlayersPiecesInRows();

        //a.FindOkeyCount();

        //a.FindRuns();

        //a.WriteRuns(a.RunList);

        //a.FindSets();

        //a.WriteSets(a.SetList);

        a.PickAndPlace();




        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(". . .");













        Console.ReadKey();

    }

}