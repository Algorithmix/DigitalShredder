DigitalShredder
===============

A digital "document shredder" for testing algorithms


jagged line generator

The "jagged line generator" project contains an implementation of the 
midpoint displacement algorithm found here... 
http://www.bugfree.dk/blog/2009/02/23/generating-2d-random-fractal-terrains-with-c/

This line is used in the shredder to create jagged lines that resemble real life shredding.

Before modifying the shred slicing it is best to test out the line function in the jagged line generator.

Change Line 43 of "jagged line generator" to change where the result of the program is saved.


Shredder Simulator

This is a C# program with a windows forms gui to accept input file, file destination, and slice parameters.
As of now, the only slice parameters are just number of horizontal and vertical slices.

The shred simulater uses the code from the jagged line generator to generate jagged lines that correspond to slices.
The input image is then segmented based on these jagged lines.  These segmented 'shreds' are then overlayed on top of a
genuine pink background.  This pink background is made of a tiled sample from real scanned pink paper.