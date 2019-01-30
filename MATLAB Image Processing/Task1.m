% MATLAB script for Assessment Item-1
% Task-1
clear; 
close all; 
clc;

% Step-1: Load input image
I = imread('Zebra.jpg');
figure;
imshow(I);
title('Step-1: Load input image');
axis on

% Step-2:Conversion of input image to grey-scale image
Igray = rgb2gray(I);
figure;
imshow(Igray);
title('Step-2: Grayscale image');
axis on
% Step-3: Nearest Neighbour Interpolation

% Get the size of original image in an array
[r, c] = size(Igray);

% Set the scale factor
zoom = 3;

% Work out new rows and colums - original rows and columns * scale factor
newRows = r * zoom;
newCol = c * zoom;

% Set the output image as an empty buffer
outputImg = uint8(zeros(newRows, newCol));

% Iterate through the new rows and columns
for x = 1 : newRows - 1
    for y = 1 : newCol - 1
        
        %Get the position of the current pixel, round the value down to the nearest integer
        posX = floor(x/zoom);
        posY = floor(y/zoom);
        
        %Index the original image position to the new image
        outputImg(x+1, y+1) = Igray(posX+1, posY+1);
    end
end
% Show the image
figure;
imshow(outputImg);
title('Step-3: Nearest Neighbour Interpolation');
axis on

% Step-4: Bilinear Interpolation

% Create a 2d array to store the size of the image
[row, column] = size(Igray);

% Get new image rows, colums  size of original rows and columns * scale factor
zRow = zoom * row;
zCol = zoom * column;

%Set output image as empty buffer
bilinearImg = uint8(zeros(zRow, zCol));

% Iterate over the new image rows
for i=1:zRow
    % Get the nearest x positions
    x1 = floor(i/zoom);
    x2 = ceil(i/zoom);
    if x1 == 0
        x1 = 1;
    end
    % Work out the x coordinate
    x = rem(i/zoom, 1);
    
    % Iterate over new image columns
    for j=1:zCol
        % Get nearest y positions
        y1=floor(j/zoom);
        y2=ceil(j/zoom);
        if y1==0
            y1=1;
        end
        
        % Work out the y coordinate 
        y = rem(j/ zoom, 1);
        
        % Neighbouring constants
        q11 = Igray(x1, y1);
        q12 = Igray(x2, y1);
        q21 = Igray(x1, y2);
        q22 = Igray(x2, y2);
        
        % Bilinear interpolation
        R1 = (q21 * y) + (q11 * (1-y));%Weighted average of q21 and q11
        R2 = (q22 * y) + (q12 * (1-y));%Weighted average of q22 and q12
        
        % Bilinear Equation applied to the image buffer
        bilinearImg(i, j) = (R2 * x) +(R1 * (1-x));%Weighted average of R1 and R2 
    end
end
figure;
imshow(bilinearImg);
title('Step-4: Bilinear Interpolation');
axis on


        


