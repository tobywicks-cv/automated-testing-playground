namespace AutomatedTestingFramework;

public class Board
{
    public CellType[][] Cells{ get; } = { new CellType[3], new CellType[3], new CellType[3] };
    
    public CellType Get(int x, int y)
    {
        return Cells[x][y]; 
    }
    
    public void Set(int x, int y, CellType type)
    {
        Cells[x][y] = type; 
    }
    
    public void Run()
    {
       // TODO(jwwishart) only looking at centre one
       var c1 = Get(0, 0);
       var c2 = Get(0, 1);
       var c3 = Get(0, 2);
       
       var c4 = Get(1, 0);
       var c5 = Get(1, 2);
       var c6 = Get(1, 1);
       
       var c7 = Get(2, 0);
       var c8 = Get(2, 2);
       var c9 = Get(2, 1);
       
       var count = 0;
      
       if (c1 == CellType.Alive)
       {
           count++;
       }
       if (c2 == CellType.Alive)
       {
           count++;
       }
       if (c3 == CellType.Alive)
       {
           count++;
       }
       
       if (c4 == CellType.Alive)
       {
           count++;
       }
     /*  if (c5 == CellType.Alive)
       {
           count++;
       }*/
       if (c6 == CellType.Alive)
       {
           count++;
       }
       
       if (c7 == CellType.Alive)
       {
           count++;
       }
       if (c8 == CellType.Alive)
       {
           count++;
       }
       if (c9 == CellType.Alive)
       {
           count++;
       }
      
       if (count == 2 || count == 3)
       {
           Set(1,1, CellType.Alive);
       } 
       else
       {
           Set(1,1, CellType.Dead);
       }
    }
}

public enum CellType
{
    None,
    Dead,
    Alive,
    Question
}

public class KataTest
{
    [Fact]
    public void BoardSetup()
    {
        var board = new Board();
        Assert.Equal(3, board.Cells.Length);
        Assert.Equal(3, board.Cells[0].Length);
        Assert.Equal(3, board.Cells[1].Length);
        Assert.Equal(3, board.Cells[2].Length);
    }

    // [Fact]
    // public void GenerateEntries()
    // {
    //     var board = new Board();
    //    
    //     var value = board.Get(0,0); // dead
    //     Assert.Equal(CellType.Dead, value);
    //     value = board.Get(0,1); // question
    //     Assert.Equal(CellType.Question, value);
    //     value = board.Get(1,1); // alive
    //     Assert.Equal(CellType.Alive, value);
    // }
    
    [Fact]
    public void GottaHaveAtLeastOneOrTwoNeighbours()
    {
        var board = new Board();
        board.Set(0,0, CellType.Dead);
        board.Set(0,1, CellType.Question);
        board.Set(0,2, CellType.Dead);
        
        board.Set(1,0, CellType.Dead);
        board.Set(1,1, CellType.Alive);
        board.Set(1,2, CellType.Dead);
        
        board.Set(2,0, CellType.Dead);
        board.Set(2,1, CellType.Dead);
        board.Set(2,2, CellType.Dead);
        
        board.Run();
        Assert.Equal(CellType.Dead, board.Get(1,1));
    }
    
    [Fact]
    public void TwoOrThreeNeighboursIsOk()
    {
        var board = new Board();
        board.Set(0,0, CellType.Dead);
        board.Set(0,1, CellType.Question);
        board.Set(0,2, CellType.Alive);
        
        board.Set(1,0, CellType.Dead);
        board.Set(1,1, CellType.Alive);
        board.Set(1,2, CellType.Alive);
        
        board.Set(2,0, CellType.Dead);
        board.Set(2,1, CellType.Dead);
        board.Set(2,2, CellType.Dead);
        
        board.Run();
        Assert.Equal(CellType.Alive, board.Get(1,1));
    }
    
       
    [Fact]
    public void ToManyNeighboursAreDeadly()
    {
        var board = new Board();
        board.Set(0,0, CellType.Question);
        board.Set(0,1, CellType.Question);
        board.Set(0,2, CellType.Question);
        
        board.Set(1,0, CellType.Alive);
        board.Set(1,1, CellType.Alive);
        board.Set(1,2, CellType.Alive);
        
        board.Set(2,0, CellType.Alive);
        board.Set(2,1, CellType.Alive);
        board.Set(2,2, CellType.Alive);
        
        board.Run();
        Assert.Equal(CellType.Dead, board.Get(1,1));
    } 
    
    [Fact]
    public void DeadCellLivesWith3()
    {
        var board = new Board();
        board.Set(0,0, CellType.Dead);
        board.Set(0,1, CellType.Dead);
        board.Set(0,2, CellType.Alive);
        
        board.Set(1,0, CellType.Dead);
        board.Set(1,1, CellType.Dead);
        board.Set(1,2, CellType.Alive);
        
        board.Set(2,0, CellType.Dead);
        board.Set(2,1, CellType.Dead);
        board.Set(2,2, CellType.Alive);
        
        board.Run();
        Assert.Equal(CellType.Alive, board.Get(1,1));
    } 
}