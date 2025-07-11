function updateClock() {

//creating a Date oject called now so we can access universal time
    const now = new Date();
/* these are the placeholder elements were going to use to input the time
 and date in the way we want it structured by the jacascript function */
    const dateElement = document.getElementById("date");
    const timeZoneElement = document.getElementById("time");
//now we are accessing the timeZone string from the weatheAPI from a div inside of layout.cshtml 
    const timeZoneData = document.getElementById("timeZone");
    const timeZoneString = timeZoneData.textContent;

//updating the time to the correct time zone based on what the API returned
    const time = now.toLocaleTimeString('en-US', {timeZone: timeZoneString});
    const date = now.toLocaleDateString('en-US', {timeZone: timeZoneString});

    dateElement.textContent = `${date}`;
    timeZoneElement.textContent = `Local Time: ${time} - ${timeZoneString}`;

    console.log("Timezone from HTML:", timeZoneString);
}
setInterval(updateClock, 1000);
