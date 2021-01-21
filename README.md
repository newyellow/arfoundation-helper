# ARFoundation Helper

AR Foundation is free and powerful. However, its editor user experience is not that good as other commercial SDKs like Vuforia oe EasyAR. (especially for Image Tracking) So I develop this tool to improve the editor experience.

## Main Features

### WYSIWYG experience with *NY Image Tracker*

### On / Off tracking event handle

### Manage Image Tracker Library through a single button


## How to use

### Basic Setup
1. Add *AR Session* and *AR Session Origin* object into the scene. (these are AR Foundation component)
1. Add *AR Tracked Image Manager* component on *AR Sesson Origin* object.

### Add Image Trackers
1. To add an image tracker, create an empty object, add *NY Image Tracker* component, and pick the image you like.
1. Add as many targets as you like.

### Generate Image Library
1. Create an empty object and add *NY Image Tracker Manager*
1. Click the *Update Library* button in the inspector, and an Image Library will be generated according to the *NY Image Trackers* in your scene.

### Other Settings
* There are some options you could set in Assets/ARFoundationHelper/Resources/HelperSetting.asset
