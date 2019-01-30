% MATLAB script for Assessment Item-1
% Task-2
clear; 
close all; 
clc;

%Load image
I = imread('Noisy.png');
figure;
imshow(I);
title('Step 1 - Load image...');

% Convert image to grayscale
grayImg = rgb2gray(I);

% Define the global mask size
mask = 5;

% Workout padding for the image
edge = floor(mask/2);

% Get size of original image
[r, c] = size(grayImg);

% Median Filter

% Pad the image with 0s
paddedImg = zeros(r, c + edge*2); 

% Copy original image to the new image with padding
for x=1:r
    for y=1:c
        paddedImg(x+edge,y+edge) = grayImg(x,y);
    end
end

% Set the output image buffer to size of the original image with zero values
medianImg = uint8(zeros(r, c));

% Workout middle value of the mask
middleValue = round((mask * mask)/2);

% Itereate through the padded image 
for x = 1 : size(paddedImg, 1) - (mask - 1)
    for y = 1 : size(paddedImg, 2) - (mask - 1)
        % Place the mask over the padded image
        window = paddedImg(x:x+(mask-1), y:y+(mask-1));
        % Sort the matrix, Convert the 2-d matrix to 1-D to remove all noise
        sortWindow = sort(window(:));
        % Set the pixel in the output image as the middle value in the mask
        medianImg(x, y) = sortWindow(middleValue);
    end
end
figure;
imshow(medianImg);
title('Image after median filtering');

% Average Filter

% Create a new image with 0 padding
paddedImg1 = zeros(size(grayImg) + edge*2); 

% Copy original image to the new image with padding
for x=1:size(grayImg,1)
    for y=1:size(grayImg,2)
        paddedImg1(x+edge,y+edge) = grayImg(x,y);
    end
end

% Create an empty image buffer
meanImg = uint8(zeros(size(grayImg)));

% Iterate through the original image
for i=1:size(grayImg,1)
    for j=1:size(grayImg,2)
        % Set total to 0 
        total=0;
        % Iterate through the mask
        for l=1:mask
            for m=1:mask 
                % Add the current pixel value to the total
                total = total + paddedImg1(i+l-1,j+m-1);
            end
        end    
        % Work out the avarage - Index the sum to the current pixel in the empty image buffer
        meanImg(i,j) = total/(mask*mask);
    end
end
figure;
imshow(meanImg);
title('Image after averaging filter');

















