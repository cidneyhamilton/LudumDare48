VAR FlashbackCounter = 0
VAR IsGameOver = false

-> start

=== start ===
Welcome to the psychotherapy clinic.
Let's try an EMDR session.
Press the tapper on the left and the tapper on the right in quick succession to get through the flashback.
If you succeed, you'll be able to go on to the next flashback.
#emdr
->DONE

=== success ===
~ FlashbackCounter++
{
	- FlashbackCounter == 1:
	  -> after_first_flashback
	- FlashbackCounter == 2:
	  -> after_second_flashback
	- FlashbackCounter == 3:
	  -> after_third_flashback
	- FlashbackCounter == 4:
	  -> after_fourth_flashback
	- FlashbackCounter == 5:
	  -> after_fifth_flashback
}

=== failure ===
You don't quite have the hang of it, sorry.
Let's try that again. Remember to hit the tappers in alternating succession to get through the flashback.
Let's give it one more go.
#emdr
-> DONE

=== after_first_flashback
Congratulations! You're getting the hang of it.
Your wife's death must have been painful for you. Let's try this again.
# emdr
-> DONE

== after_second_flashback
Those psychics must have been disturbing. But we need to go deeper.
# emdr
-> DONE

== after_third_flashback
That party.... oh no. There's something buried here, something even worse than I can imagine.
# emdr
-> DONE

== after_fourth_flashback
Those psychics again!
# emdr
-> DONE

== after_fifth_flashback
You killed the king. This is why you're having these nightmares.
I cannot help you. I cannot...
~ IsGameOver = true
The game is over.
-> END