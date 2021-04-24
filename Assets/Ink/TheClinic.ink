VAR FlashbackCounter = 0
VAR IsGameOver = false

-> start

=== start ===
Welcome to the psychotherapy clinic.
Let's try an EMDR session.
Press the tapper on the left and the tapper on the right in quick succession to get through the flashback.
If you succeed, you'll be able to go on to the next flashback. #emdr
->DONE

=== success ===
Congratulations! You're getting the hang of it.
The rest of the game will go here when it's ready.
-> END

=== failure ===
You don't quite have the hang of it, sorry.
Let's try that again. Remember to hit the tappers in alternating succession to get through the flashback.
Let's give it one more go. #emdr
-> DONE

