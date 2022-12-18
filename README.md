# ConsistencyCounter

## TLDR
This is my first mod. Its a Counters+ extension that shows you how consistent your accuracy is. 

## What is consistency
* 0 is very bad, its so bad that its good again if you manage to hit a 0 😂. 
* 100 is perfect and happens if your accuracy is perfectly consistent. That can happen if you hit a 115 on every note in the map. 
* Your actual accuracy doesn't need to be good to get high consistency (but it helps a lot). You can for example hit a 0 on everything and still get 100% consistency. You then managed to hit a 0 consistently, congratulations.

## Tips
* **Swing calmer and concentrate to get higher consistency. Consistency is a very important part of improving accuracy.**
* Checkout `Beat Saber\UserData\ConsistencyCounter.json` for more configuration, I'll try and put the important settings in-game soon (tm).

## How does it work
* It calculates the standard deviation of all note accuracies you hit
* And then maps it from 0 to 100 with
  * 0 being the highest possible spread of accuracies (ex. 0 and 115) 
  * 100 being the lowest possible spread of accuracies (ex. 115 and 115)
