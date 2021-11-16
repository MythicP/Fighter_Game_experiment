# Fighter_Game_experiment
This game is a personal project using critical role charactes.  
It uses the GGPO rollback netcode to sync up 2 players over a local network, or 2 players on the same machine

Note: Currently there is a bugg that casus it to stutter. 

Currently the player can move their chatacter and perform one attack with animation either local or over a netowrk.  
To Run, download the CritFighter folder and run the exe inside of it.  
  
There are 2 ways to start a game,  
Either press local to start a 2 player game on 1 pc (note p2 controls arnt fully implemented)
Or write as follows 
  
P1, 127.0.0.1, 7000  
P2, p2 local ip, 7001  
  
Then click P1  

Then the second player on their pc writes   

P1, p1 local ip , 7000  
P2, 127.0.0.1, 7001  
  
Then click P2  

controles are 
a: left
s: crouch/down
d: right
w: jump
numbad 
  7: light attack (not implemented)
  8: medium (not implemented)
  9: Heavy  (not implemented)
  4: Power (not implemented)
  5: Uniqe (not implemented)
  6: Grab (not implemented)
