using Platformer.Models;

public class Game
{
    private int Points = 500;
    private Platform? ActivePlatform;
    private readonly List<Platform> platforms;

    private bool run = true;
    private int jumps = 0; //Count jumps

    public Game(string gameFile)
    {
        platforms = ReadPlatforms(gameFile);
    }

    public void Run()
    {
        //Setup starting position
        ActivePlatform = platforms[0];
        ActivePlatform.Locked = false;
        ActivePlatform.CurrentlyAccesible = true;

        //Check for impossible to win game
        if(platforms[1].Cost > Points)
        {
            Console.WriteLine("The game is impossible to complete");
            run = false;
        }


        while (run)
        {
            //Set Platform.CurrentlyAccesible = true for platforms that are accesible without jumping back
            foreach (var platform in platforms.Where(x => x.Index > ActivePlatform.Index))
            {
                if(Points >= platforms
                    .Where(x => x.Index <= platform.Index && x.Index > ActivePlatform.Index)
                    .Select(x =>
                    {
                        if(x.Locked)
                        {
                            return x.Cost;
                        }
                        return x.Cost * -1;
                    })
                    .Sum())
                {
                    platform.CurrentlyAccesible = true;
                }
            }

            //Find the best place to jump to
            int bestJumpTo;
            //If final platform can be reached without jumping back, go there immediately.
            if (platforms[^1].CurrentlyAccesible == true)
            {
                bestJumpTo = platforms[^1].Index;
            }
            //Else find the best spot to earn points,
            //select platform that is currently accesible to you without going back
            //and its cost + previous platform's cost is highest.
            else
            {
                bestJumpTo = platforms
                    .Where(x => x.CurrentlyAccesible == true && x.Index > 0)
                    .OrderByDescending(x => { return x.Cost + platforms[x.Index - 1].Cost; })
                    .Select(x => x.Index)
                    .First();
            }

            //If you are already in the best spot available jump back
            if (ActivePlatform.Index == bestJumpTo)
            {
                Jump(platforms[ActivePlatform.Index - 1]);
            }
            else //Jump to the best spot available
            {
                for(int i = 0; i < (bestJumpTo - ActivePlatform.Index); i++)
                {
                    Jump(platforms[ActivePlatform.Index + 1]);
                }
            }
        }

        Console.WriteLine($"Game finished in {jumps} jumps");
    }

    /// <summary>
    /// Performs actual jump and calls mandatory JumpTo method
    /// </summary>
    /// <param name="platform">Platform that you are going to jump to.</param>
    private void Jump (Platform platform)
    {
        JumpTo(platform);
        jumps++;
        if (platform.Locked)
        {
            Points -= platform.Cost;
            platform.Locked = false;
        }
        else
        {
            Points += platform.Cost;
        }
        if (platform.Index == platforms[^1].Index)
        {
            run = false;
        }
        Console.WriteLine($"Index {platform.Index} Points {Points}");
    }

    /// <summary>
    /// Reads platforms from csv file and returns them as list.
    /// </summary>
    /// <param name="path">Path to CSV file.</param>
    /// <returns>Platforms as list</returns>
    private List<Platform> ReadPlatforms(string path)
    {
        var result = new List<Platform>();
        var rows = System.IO.File.ReadAllLines(path).ToList();

        foreach (var row in rows.Skip(1))
        {
            var columns = row.Split(',');
            result.Add(new Platform
            {
                Index = int.Parse(columns[0]),
                Cost = int.Parse(columns[1]),
                Locked = true,
                CurrentlyAccesible = false,
            });
        }

        return result;
    }

    /// <summary>
    /// Invoke this function to jump to next platform.
    /// </summary>
    /// <param name="platform">Platform that you are going to jump to.</param>
    public void JumpTo(Platform platform)
    {
        ActivePlatform = platform;
    }
}