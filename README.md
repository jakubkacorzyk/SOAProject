# SOAProject 
SOAProject was made for university assignment. U need microphone to fully use application.

## About VoiceClient
VoiceClient application records user speech and tries to recognize it via Azure voice recognition services and transform it to text format. Then text format is send to DialogFlow API where response is beeing created and given back to user in string format, printed on console.

## About WPF Application 
Our main application is based on WPF client which connects to 3 WCF services : BotService - transform voice message to text message via Azure voice recognition and then gets answer from DialogFlow, WeatherService - gets informations about weather in selected city, QuotesService - prints random quote, author and category.

Our application has login and register pages to authorize users.

# Login page : 
<img src="https://github.com/kubalo09/SOAProject/blob/master/VoiceClient/Screenshots/LoginPage.png" height="400">

# Register page :
<img src="https://github.com/kubalo09/SOAProject/blob/master/VoiceClient/Screenshots/RegisterPage.png" height="400">

# Bot page :
<img src="https://github.com/kubalo09/SOAProject/blob/master/VoiceClient/Screenshots/Bot.png" height="400">

# Weather page :
<img src="https://github.com/kubalo09/SOAProject/blob/master/VoiceClient/Screenshots/Weather.png" height="400">

# Quotes page :
<img src="https://github.com/kubalo09/SOAProject/blob/master/VoiceClient/Screenshots/Quotes.png" height="400">

## Running 
You can run our application via Visual Studio but first you have to check if all setting are correct.

* Right click on Solution _VoiceClient_ -> _Properties_ -> _Common Properties_ -> _Startup Project_
<img src="https://github.com/kubalo09/SOAProject/blob/screenshots/sshots/startupProject.png" height="400">

* _Build_ -> _Configuration Manager_
<img src="https://github.com/kubalo09/SOAProject/blob/screenshots/sshots/confManager.png" height="400">


* _Tools -> Options -> Projects and Solutions -> Web Projects_
<img src="https://github.com/kubalo09/SOAProject/blob/screenshots/sshots/webProjects.png" height="400">

After that you can simply build it and run.
