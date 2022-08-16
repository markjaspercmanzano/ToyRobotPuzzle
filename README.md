# ToyRobotPuzzle

Create a toy robot that can move in a 5x5 grid!

### Movement Grid 
```
y
4 ☐ ☐ ☐ ☐ ☐
3 ☐ ☐ ☐ ☐ ☐
2 ☐ ☐ ☐ ☐ ☐
1 ☐ ☐ ☐ ☐ ☐
0 ☐ ☐ ☐ ☐ ☐
  0 1 2 3 4 x
```

## Robot Commands
### PLACE X,Y,F

This command allows you to place the robot in the grid, given that the input values are valid. 

When initially running the program, PLACE needs the complete X,Y,F parameters. After that, PLACE X,Y works.

Example scenario: 

PLACE 2,3,NORTH

 ```
y
4 ☐ ☐ ☐ ☐ ☐
3 ☐ ☐ ^ ☐ ☐
2 ☐ ☐ ☐ ☐ ☐
1 ☐ ☐ ☐ ☐ ☐
0 ☐ ☐ ☐ ☐ ☐
  0 1 2 3 4 x
```

PLACE 4,0

 ```
y
4 ☐ ☐ ☐ ☐ ☐
3 ☐ ☐ ☐ ☐ ☐
2 ☐ ☐ ☐ ☐ ☐
1 ☐ ☐ ☐ ☐ ☐
0 ☐ ☐ ☐ ☐ ^
  0 1 2 3 4 x
```
### RIGHT

This command rotates the robot's direction 90 degrees clockwise. 

Example scenario:

PLACE 4,0,NORTH

RIGHT
 ```
y
4 ☐ ☐ ☐ ☐ ☐
3 ☐ ☐ ☐ ☐ ☐
2 ☐ ☐ ☐ ☐ ☐
1 ☐ ☐ ☐ ☐ ☐
0 ☐ ☐ ☐ ☐ >
  0 1 2 3 4 x
```

### LEFT

This command rotates the robot's direction 90 degrees counter-clockwise. 

Example scenario:

PLACE 4,0,NORTH

LEFT
 ```
y
4 ☐ ☐ ☐ ☐ ☐
3 ☐ ☐ ☐ ☐ ☐
2 ☐ ☐ ☐ ☐ ☐
1 ☐ ☐ ☐ ☐ ☐
0 ☐ ☐ ☐ ☐ <
  0 1 2 3 4 x
```

### MOVE

This command moves the robot 1 unit forward in whatever direction it is facing. Movement will not register if it will fall off the grid.

Example scenario:

PLACE 4,0,WEST

MOVE
 ```
y
4 ☐ ☐ ☐ ☐ ☐
3 ☐ ☐ ☐ ☐ ☐
2 ☐ ☐ ☐ ☐ ☐
1 ☐ ☐ ☐ ☐ ☐
0 ☐ ☐ ☐ < ☐
  0 1 2 3 4 x
```


### REPORT

This command gives the current coordinates, as well as the direction.

```
PLACE 4,0,WEST
REPORT
4,0,WEST
```

