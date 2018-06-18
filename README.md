# SOAProject 
SOAProject was made for university assignment. U need microphone to fully use application.

## About VoiceClient
VoiceClient application records user speech and tries to recognize it via Azure voice recognition services and transform it to text format. Then text format is send to DialogFlow API where response is beeing created and given back to user in string format, printed on console.

## Running 
You can run our application via Visual Studio but first you have to check if all setting are correct.

* Right click on Solution _VoiceClient_ -> _Properties_ -> _Common Properties_ -> _Startup Project_
<img src="https://github.com/kubalo09/SOAProject/blob/screenshots/sshots/startupProject.png" height="400">

* _Build_ -> _Configuration Manager_
<img src="https://github.com/kubalo09/SOAProject/blob/screenshots/sshots/confManager.png" height="400">


* _Tools -> Options -> Projects and Solutions -> Web Projects_
<img src="https://github.com/kubalo09/SOAProject/blob/screenshots/sshots/webProjects.png" height="400">

After that you can simply build it and run.
