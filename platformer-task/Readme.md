# Exercise

## Brotherly Feud

Semi Nario set off on a quest to win the heart of princess Peach. He has already defeated four dragons, two quality assurance engineers, and bamboozled a dozen witches. The only obstacle that lays between him and princess Peach is an abyss deeper than your eighth-grade essays. The only safe way through the abyss is an array of platforms. Nario has decided to jump from one platform to another, to reach the other side of the abyss. Just before Nario is ready to jump on the first platform, he notices his older brother Super Mario. As their eyes lock, they both realize that they are after the very same woman. Contrary to popular belief Super Mario is a quite rude and obnoxious man. Decades of fame and mushrooms have poisoned Mario’s mind. Help Semi Nario to reach princess Peach before his annoying big brother Super Mario.

## Setup

It uses .Net 6 (It is verified with VS 2022).

## Assignment

Read game track from CSV files and complete the track with the least number of jumps possible.

## Game Rules
- The track consists of platforms stored in CSV files (see platformer/Platformer/Data/platforms.csv).
- The first line of the CSV file is always a header row. It does not contain actual platforms.
- Each line contains one platform. The first platform is always indexed as 0, and platform indexes grow by one each row.
- You start the game with 500 points.
- You start the game from the platform with an index of 0. This platform is unlocked by default.
- To jump to the next platform, you must unlock it first. Unlock cost is stored in CSV file in the cost column.
- You can unlock the platform by jumping to it while having sufficient points.
- Platform cost is in range [0, 20000]
- You can earn points by jumping back to previously unlocked platforms.
- The game ends when you reach the last platform.

## Example Game

Imagine the following CSV file:

``` csv
index, cost
0, 100
1, 200
2, 400
3, 100
```

You start the game from platform ‘0’ with 500 points.
- You jump to platform ‘1’. It is the first jump to that platform, so you’re going to have to pay the cost. Points: 500 - 200 = 300
- You cannot jump to platform ‘2’ because it costs 400 points, but you only have 300. It is time to go back. You jump to platform ‘0’. Points: 300 + 100 = 400.
- You jump to platform ‘1’. Points: 400 + 200 = 600
- After taking a detour, you finally have enough points to jump to platform '2', so you jump there. Points: 600 - 400 = 200
- You jump to platform ‘3’. Points: 200 - 100 = 100

Congratulations! It took five jumps to reach the last platform.

## Additional Important Instructions

TODOs have been left in the Game.cs file. Implementation is up to you, just **make sure that whenever you jump to the platform you also invoke JumpTo(Platform platform) method.** You don’t need to embed your program logic in that method. Our Nortal submission review heroes need that method to validate your solution.

## Do you have questions?

As the forum is open (https://nortal.com/careers/summeruniversity-lt-22/net-task-discussion-lt-2022/), read the previous answers and if you didn't find the answer, ask your own. Our specialists keep an eye on the forum daily and answer your questions as soon as possible.