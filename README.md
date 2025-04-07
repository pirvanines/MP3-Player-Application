# Team-Based Software Engineering Project - MP3 Player

## Authors
- **Ines-Iuliana Pirvan** - Software Engineer
- **Roxana-Maria Apostol** - Software Developer
- **Raluca-Daniela Baciu** - Software Developer
- **Florina-Dumitrita Nistor** - Technical Writer

## Project Goal
### Functionality
- Playing .mp3 files
- Add, Delete Songs
- Creating, Deleting playlists
- Play, Pause, Stop, Next, Prev buttons
- Add Lyrics
- Help assistence 
- Reading, editing, and displaying information from ID3 tags (song metadata) - *not implemented*

### Requirements
- Use Case Diagram
- System specification document (a user tutorial - describes the functionality of each button and the purpose of each section added to the interface with very few implementation details; emphasis on the black box concept) - useful: page 53, course 3, Software Engineering 
- To use design patterns: Commander and Facade
- Add relevant comments
- To handle exceptions
- To implement and add our own DLLs
- The source code must include a header with information about the author and the functionality they have added for each file
- A list of what each person has implemented - *coding*

## Implementation Approach
### Initial State
- Add files to a playlist (saved statically - until the program is closed)
- Play a selected song

### Next Steps
- Define the design patterns to be used (possibly the Command and Facade patterns)
- Create a UML diagram to clarify task division and start the implementation process

### Main Tasks
- Document the application implementation approach, then create the UML diagram
- Implement the modules according to the UML diagram
- Create an attractive user interface
- Create a help menu using HelpNDoc
- Implement the test class and the test cases
- Add self implemented DLL modules
- Write the documentation

## Team member contributions
- **Ines-Iuliana Pirvan** - application architecture, team management, UI, **Play/Pause Song** functionality, DLLs, Unit Testing
- **Roxana-Maria Apostol** - **Next/Prev Song** functionality, **Add Lyrics** functionality and synchronization between the two using Command pattern, **Volume Controller**
- **Raluca-Daniela Baciu** - **Add/Delete Playlist** functionality, **Add/Delete Song** functionality, **Store Song and Playlist** classes, exceptions handling
- **Florina-Dumitrita Nistor** - Facade pattern between UI and core logic, **Help** menu with HelpNDoc, Use Case Diagram, Documentation

## Disclaimer
- No changes have been made to the source code since the last team meeting in May 2023
- The README.md has been translated from Romanian to English, and formated properly
