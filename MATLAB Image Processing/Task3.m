% MATLAB script for Assessment Item-1
% Task-3
clear;
close all; 
clc;

% Load image
I = imread('Starfish.jpg');
figure;
imshow(I);
title('Step 1 - Load image...');

% Convert the image to grayscale
Igray = rgb2gray(I);
figure;
imshow(Igray);
title('Step 2 - Grayscale');

% Remove noise using median filter - medfilt2
I2 = medfilt2(Igray);
figure;
imshow(I2);
title('Step 3 - Noise Removal');

% Work out the threshold using Otsu's Method
threshold = graythresh(I2);
% Convert the image to binary using the threshold
bw = imbinarize(I2, threshold);
% Reverse the black and white objects
I3 = imcomplement(bw);
figure;
imshow(I3);
title('Step 4 - Binary Image');

% Dilate the image using a disk 'structuring element' of radius 4
se1 = strel('disk', 4);
I4 = imdilate(I3, se1);
figure;
imshow(I4);
title('Step 5 - Dilated Image');

% Fill the empty objects with holes
I5 = imfill(I4, 'holes');
figure;
imshow(I5);
title('Step 6 - Filled Image');

% Remove objects from the border with connectivity 8
I6 = imclearborder(I5, 8);
figure;
imshow(I6);
title('Step 7 - Remove borders Image');

% Smoothen the objects with a disk 'structuring element' of radius 1
se2 = strel('disk',1);
I7 = imerode(I6,se2);
I7 = imerode(I7,se2);
figure;
imshow(I7);
title('Step 8 - Smoothed Image');

% Only keep objects of area between 830 pixels and 1000 pixels - Starfishes  
FinalImg = xor(bwareaopen(I7,830),  bwareaopen(I7,1000));
figure;
imshow(FinalImg); 
title('5 star fishes recognised');




      







