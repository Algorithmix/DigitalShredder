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

currently a work in progress.  The program as it is will create a bitmap called sliceMap that marks the regions to be 
segmented.  The segmentation itself is the next thing to be done.  Then the addition of tapered transparency and the
layout of the pieces on top of the tiled pink background taken from the real data.