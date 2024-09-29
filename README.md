# Game Hub
Welcome to Game Hub, a collection of interactive and engaging games developed using the latest technologies in .NET and Blazor. This repository currently includes two games: **WordGame** and **ImageGame**.

## 📝 Project Overview
### 🎮 WordGame
WordGame is a challenging word-guessing game where players must deduce hidden words within a given time frame. The game features different difficulty levels and provides real-time updates to enhance the player experience.

#### Gameplay Mechanics:
**Starting the Game:**
- Select a level and category to begin.
- Depending on the difficulty level, certain characters in the word will be hidden.

**Guessing the Word:**
- Choose letters to guess the hidden word.
- Correct guesses allow you to proceed to the next level.
- Incorrect guesses or running out of time will prompt a retry or a return to the main menu.

**Health and Hints:**
- Players have a limited number of health points.
- Guide can be used to colorize correct letters.
- Health regenerates over time, allowing players to return after a break.

**Winning the Game:**
- Players advance through levels by correctly guessing the words.
- Completing all levels in a category results in a win.

### 🖼️ ImageGame
ImageGame is a competitive, turn-based image-guessing game where two players face off to identify images. The game emphasizes real-time interaction and strategy, providing an exciting experience for both players.

#### Gameplay Mechanics
**Starting the Game:**
- Players join a room and take turns selecting images to guess.

**Guessing the Images:**
- Each player has a limited time to guess the hidden images.
- Correct guesses reveal the image.
- The game continues until all images are revealed or time runs out.

**Winning the Game:**
- The player with the higher score at the end of the game is declared the winner.
- The game also allows for draws if both players have equal scores.

**Real-Time Interaction:**
- The game uses SignalR to manage real-time interactions between players.
- Players receive instant feedback on their guesses and are updated on their opponent's moves.

### ⌨️ Type Speed Test
The Type Speed Test is an interactive game that challenges the player's typing speed and accuracy. The player is required to type a predefined passage of text, and the game tracks both correct and incorrect   keystrokes in real time.

#### Gameplay Mechanics:
**Starting the Game:**
- The game begins when the player starts typing the displayed text.
- A timer starts on the first keystroke, and the player must type each character correctly.
  
**Game End:**
-The game ends when the player completes typing the entire text.
-A modal will appear, showing the player's performance, including the number of mistakes (wrong peaks) and the total time taken to complete the text.
  
**Technologies Used:**
- .NET 8 Blazor
- SignalR
- Clean Architecture
- CQRS
- MediatR

**🚀 How to Access the Games**
- Both games are accessible through the Game Hub

💡 Contributing
We welcome contributions! If you find any issues or have suggestions for improvements, please feel free to create an issue or submit a pull request. Don't forget to give the project a star if you find it helpful ⭐.
