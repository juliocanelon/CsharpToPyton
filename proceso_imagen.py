# python libraries
import os
import sys
import time
import traceback
import argparse

# python data ecosystem libraries
#import numpy as np
#import cv2
#import pickle
#import config

if __name__ == '__main__':   
    arg_parse = argparse.ArgumentParser()
    arg_parse.add_argument("-image_name")
    arguments = arg_parse.parse_args()
    image_name = arguments.image_name    
    print(image_name)

## resto del codigo en https://medium.com/@ernest.bonat/using-c-to-run-python-scripts-with-machine-learning-models-a82cff74b027

