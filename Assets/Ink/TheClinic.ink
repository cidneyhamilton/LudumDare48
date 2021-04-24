VAR FlashbackCounter = 0
VAR IsGameOver = false

-> start

=== start ===
Eliza: My chamber, lord, to thee I beg a chance / To wit amend thy crag-swept countenance
Eliza: The glimpse of madness I've seen in thy face / Can physician with tapper chase away.
Eliza: If thou sit'st here with me and close thine eyes, / And fold thy hands across thy breast like so,
Eliza: My art that Freud and Jung taught down from high, / That flourishes in clinic and in school,
Eliza: Can drive the demons from within thy mind, / And bring thee to a state of better health.
Regan: Speak plainly, woman. What wilt thou of me?
Eliza: Sit, sit, lord. And speak of thy memories.
Regan: My memories are mine. I dare not share.
Eliza: Then merely think of them. I dare not pry.
Regan: But thou canst help me?
Eliza: Yea, sir. Tap left then right then left again. / While visting the trauma of thy past.
Regan: I'll play thy game, doctor. When do I start?
Eliza: Now. Think of a memory of the past. / If thou succeedst, we'll try the next flashback.
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
Eliza: My lord, remember what I bid thee do / Tap left, then right, as quickly as thou canst.
#emdr
-> DONE

=== after_first_flashback
Eliza: Well done, my lord. Thou hast accessed a glimpse, / Of what thy mind will do whence processed this.
Regan: I saw a woman's face--
Eliza: That's thy late wife. / Thy greatest partner in thy enterprise.
Eliza: She led thy rise from partner to exec. / When cowardice unmanned thee she was there.
Regan: She should have died hereafter.
Eliza: Thou thinkst thou can anticipate hereafter?
Regan: Aye; three witches did for me last winter.
Eliza: Perhaps that should be our next memory?
Regan: Perhaps.
Eliza: Prepare thy tappers; we'll begin again.
# emdr
-> DONE

== after_second_flashback
Regan: I start to see why it was wise of me. / To block these wisps of mem'ry from my mind.
Eliza: Shall we move on? Thou wouldst be wise to end / This quest for self-discovery thou hast embarked.
Regan: Begin again, good doctor. Make it quick.
# emdr
-> DONE

== after_third_flashback
Regan: My friend. Thy ghost will haunt me to the grave. / What could have possessed me to hurt thee so?
Eliza: Dost thou really want to know the answer? / Deeper still must we dive into the matter.
# emdr
-> DONE

== after_fourth_flashback
Regan: The witches were the first to see the truth. / They galled me into murder and I flew.
Regan: Once this might have seemed the right thing to do, / But now I have an empire in uproar.
Regan: I doubt I will survive beyond the year.
Eliza: Just like the man thou killed to cometh here?
Regan: I don't remember.
Eliza: Soon, my lord, we will.
# emdr
-> DONE

== after_fifth_flashback
Regan: What is this? Does thou seek to drive me mad?
Eliza: Nay, my lord, thy downfall would lack sweetness. / Should thouh forget what ledst thee to this place.
Eliza: Now come and lead thine army to its ruin. / Led by a man not yet of woman born.
~ IsGameOver = true
Eliza: Now, at least, our chase can be brought to end.
-> END