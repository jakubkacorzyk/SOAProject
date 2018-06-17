# SOAProject 
SOAProject was made for university assignment. U need microphone to fully use application.

## Running 
You can run our application via Visual Studio but first you have to check if all setting are correct.

* Right click on Solution 'VoiceClient' -> Properties -> Common Properties -> Startup Project

* Build -> Configuration Manager

* Tools -> Options -> Projects and Solutions -> Web Projects

After that you can simply build it and run.

## About VoiceClient
VoiceClient application records user speech and tries to recognize it via Azure voice recognition services and transform it to text format. Then text format is send to DialogFlow API where response is beeing created and given back to user in string format, printed on console.
