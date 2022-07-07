# SpongeBasketBall
## Installation
You can install SpongeBasketBall game from [Releases Page](https://github.com/eli1809/SpongeBasketBall/releases/tag/v1.0).
 - **SpongeBasketBall.rar** - Extract it and launch *SpongeBasketBall.exe*.
 
You could download the source Code and open it in Unity and run
 - **Assets->Scenes->'00 Splash'**

## About game
Game was made with Unity2D & SQLite , the game is programed in HIT course of "Young Linguistics" 
where we needed to build a game for children at age of 9 that where asked to give an idea
for game that could teach english , they give an idea and we make it come true.
the main player is spongebob that was painted by agirl in class.
the sounds was made by 4 adurable girls that was recorded to play as the sound effects in the game.
and thanks to niva keshet,student that tooked a very importent roll as designer.

there are 3 main target of this game:
- *Reading Comprehension*
- *listening comprehension*
- *Identification of verbs and nouns*

### Features
- Several players can play this game and try to beat each other high scores.
- Parameters of sounds are customizable: 
  - *sound effects*
  - *back ground music*
- There is a calculation of statistics for each player.(right/wrong answers and time to play)
- The ability to save and load the high score table.
- Very beautiful and **modern user interface**
- Vocabulary.
- Sound effects.


### Developing Class&Script Logic
- Colliders 2D - Set on ball,basket,ground,baskets,sidescreen(in case the ball went out)
- Animation - On level change , fades , destruction of ball
- Sound effects - On clicks, collisions , winning , lossing , background
- GameSession - Controll of Life,Health,Score,Point Per hit,Timer
- Dialog Manager - Dialogs event driven system , that controll of content that displayed on the top
				   of the basket, on spongebob cloud ,and working basket net.
- Voice Dialog - Using in combination with dialog manager where the dialog is by Sound (LVL3)				   
- Level Changer - Responsible for the changing of Scenes in case we end all the dialog 
- level Manager - Switching between scenes
- Player Prefs - Responsible for music prefs by saving the last preferens
- shoot script - Responsible for all the logics of shooting the ball , in case of aiming: moving the dots in right direction


## Game guide
### Strting the game
You will meet the splash screen before the menu: 

![splash screen](https://live.staticflickr.com/65535/48519697561_8420a88a2c_m.jpg)

In the `Main Menu` you can see the Tutorial button

![SpongeBasketBall Menu](https://live.staticflickr.com/65535/48519834166_54ded3b11f_m.jpg)

After the click you need to watch the tutorial video.

![SpongeBasketBall Tutorial](https://live.staticflickr.com/65535/48519865182_c374be21cc_m.jpg)


Summary : You need to go throught spongebob story and answer his questions by dragging the ball 
and instatiate him to the right basket , after you getting the right answers you gethering higher score,
play throught the levels and try to get as much higher score as you can get.

Example Of levels:

![SpongeBasketBall lvl3](https://live.staticflickr.com/65535/48519697701_199c9b8378_m.jpg)
![SpongeBasketBall lvl1](https://live.staticflickr.com/65535/48519968831_dd9eae51a0_m.jpg)

If the words are hard or you dont know them there is a vacubalary in the left side of the screen.

![SpongeBasketBall vacabulary](https://live.staticflickr.com/65535/48519697341_4c79cb6a6f_m.jpg)


Play till you reach the highest level you can , i you lose all you 5 lifes you will meet 
the gameover screen:

![SpongeBasketBall gameover](https://live.staticflickr.com/65535/48519865582_3f0e6805b1_m.jpg)

When the game ends : either win or lose you will prompt to highScore Screen:

![SpongeBasketBall highscore](https://live.staticflickr.com/65535/48519865532_975834b351_m.jpg)


### Video

https://www.youtube.com/watch?v=2PJSdlbXP1M&t

---

## My Contacts
- [Facebook - Eli Leman](https://www.facebook.com/eli.leman)
- [LinkedIn - Eli Leman](https://www.linkedin.com/in/liel-leman/)
