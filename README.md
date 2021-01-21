# ARFoundation Helper

AR Foundation 的辨識功能雖然強大，但是編輯的介面非常陽春，幾乎都使能透過 coding 來做設定。但 Unity 這類引擎之所以強大，不正是因為有 3D 的視覺編輯介面嗎？所以這個工具便是希望能優化 AR Foundation 的編輯功能

AR Foundation is free and powerful. However, its editor user experience is not that good as other commercial SDKs like Vuforia oe EasyAR. (especially for Image Tracking) So I develop this tool to improve the editor experience.

## Main Features

### WYSIWYG experience with *NY Image Tracker*

![image](https://github.com/newyellow/arfoundation-helper/blob/main/docs/images/scene-editing.gif)
* 在空物件上加入 *NY Image Tracker*，並選擇圖片，即完成辨識圖設定
* 辨識圖的子物件會跟著辨識圖一起移動
* 如果不想要把物件綁在辨識圖底下的話，可以設成 referenceGrouper 讓物件跟著辨識圖

* Simply add *NY Image Tracker* component on empty object, then you can setup the target image and size.
* Children objects will move with the tracker
* If you don't want to group objects under any tracker, but still want them to move with tracker, you can set with the referenceGrouper attribute.

### On / Off tracking event handle 

![image](https://github.com/newyellow/arfoundation-helper/blob/main/docs/images/on-off-tracking.gif)
* 繼承 *NYImageTrackerEventHandler* 腳本並 override OnTrackingFound / OnTrackingLost，並且跟 *NYImageTracker* 腳本掛在一起，就可以觸發事件

* Just extend *NYImageTrackerEventHandler*, overriding OnTrackingFound and OnTrackingOff function, and then put with *NYImageTracker*

### Manage Image Tracker Library through a single button

![image](https://github.com/newyellow/arfoundation-helper/blob/main/docs/images/update-library.gif)
* 在設定完所有辨識圖之後，按一下 *NYImageTrackerManager* 的 Update Library 按鈕，就會根據場景上的內容產生 Image Library

* After finish all *NYImageTracker* setup, press the Update Library button on *NYImageTrackerManager*, and the Image Library will be generated and auto assign to AR Foundation in runtime.

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
