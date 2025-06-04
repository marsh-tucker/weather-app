# 🌤 WeatherApplicationRemastered

A simple weather web app that allows users to enter a ZIP code and retrieve real-time weather data using the OpenWeatherMap API. The app displays current temperature, weather conditions, and icons. Built with HTML, CSS, and JavaScript.

## 🚀 Features

- Fetches live weather data by ZIP code  
- Input validation for correct ZIP code format  
- Displays temperature, weather description, and an icon  
- Dropdown menu to choose temperature units: Fahrenheit, Celsius, or Kelvin  
- Error message display for invalid ZIP input

## 📁 Project Structure
WeatherApplicationRemastered/
│
├── index.html # Main HTML structure
├── style.css # Styling rules
├── script.js # JavaScript to fetch and display weather
└── README.md # Project overview


## 🔧 How to Run

1. Clone or download the repository.
2. type dotnet run in command terminal and go to localhost//:
3. Enter a valid 5-digit ZIP code.
4. Click **Get Weather** to fetch and view results.

## 📡 API Used

- [OpenWeatherMap API](https://openweathermap.org/api)

> ⚠️ Be sure to replace the placeholder API key in `weatherAPIService` with your actual OpenWeatherMap API key.

## 📌 TODO

- [1] Add history of previous searches  
- [2] Save ZIP codes in a backend database  
- [3] Add weather condition icons  
- [4] Make the layout mobile-responsive




