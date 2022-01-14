# author: Cidney Hamilton
# title: The Clinic

VAR FlashbackCounter = 0
VAR IsGameOver = false

-> start

=== start ===
Eliza: My chamber, lord, to thee I beg a chance / To wit amend thy crag-swept countenance. # Eliza001.ogg
Eliza: The glimpse of madness I've seen in thy face / Can physician with tapper chase away. # Eliza002.ogg
Eliza: If thou sit'st here with me and close thine eyes, / And fold thy hands across thy breast like so, # Eliza003.ogg
Eliza: My art that Freud and Jung taught down from high, / That flourishes in clinic and in school, # Eliza004.ogg
Eliza: Can drive the demons from within thy mind, / And bring thee to a state of better health. # Eliza005.ogg
Regan: Speak plainly, woman. What wilt thou of me? # Regan001.ogg
Eliza: Sit, sit, lord. And speak of thy memories. # Eliza006.ogg
Regan: My memories are mine. I dare not share. # Regan002.ogg
Eliza: Then merely think of them. I dare not pry. # Eliza007.ogg
Regan: But thou canst help me? # Regan003.ogg
Eliza: Yea, sir. Tap left then right then left again. / While visting the trauma of thy past. # Eliza008.ogg
Regan: I'll play thy game, doctor. When do I start? # Regan004.ogg
Eliza: Now. Think of a memory of the past. / If thou succeedst, we'll try the next flashback. # Eliza009.ogg
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
}

=== failure ===
Eliza: My lord, remember what I bid thee do / Tap left, then right, as quickly as thou canst. # Eliza010.ogg
#emdr
-> DONE

=== after_first_flashback
Eliza: Well done, my lord. Thou hast accessed a glimpse, / Of what thy mind will do whence processed this. # Eliza011.ogg
Regan: I saw a woman's face-- # Regan005.ogg
Eliza: That's thy late wife. / Thy greatest partner in thy enterprise. # Eliza012.ogg
Eliza: She led thy rise from partner to exec. / When cowardice unmanned thee she was there. # Eliza013.ogg
Regan: She should have died hereafter. # Regan006.ogg
Eliza: Thou thinkst thou can anticipate hereafter? # Eliza014.ogg
Regan: Aye; three witches did for me last winter. # Regan007.ogg
Eliza: Perhaps that should be our next memory? # Eliza015.ogg
Regan: Perhaps. # Regan008.ogg
Eliza: Prepare thy tappers; we'll begin again. # Eliza016.ogg
# emdr
-> DONE

== after_second_flashback
Regan: The witches were the first to see the truth. / They galled me into murder and I flew. # Regan009.ogg
Regan: Once this might have seemed the right thing to do, / But now I have an empire in uproar. # Regan010.ogg
Regan: I start to see why it was wise of me. / To block these wisps of mem'ry from my mind. # Regan011.ogg
Eliza: Shall we move on? Thou wouldst be wise to end / This quest for self-discovery thou hast embarked. # Eliza017.ogg
Regan: Begin again, good doctor. Make it quick. # Regan012.ogg
Eliza: Dost thou really want to know the answer? / Deeper still must we dive into the matter. # Eliza018.ogg
# emdr
-> DONE

== after_third_flashback
Regan: What is this? Does thou seek to drive me mad? # Regan013.ogg
Eliza: Nay, my lord, thy downfall would lack sweetness. / Should thou forget what ledst thee to this place. # Eliza019.ogg
Eliza: Now come and lead thine army to its ruin. / Led by a man not yet of woman born. # Eliza020.ogg
~ IsGameOver = true
Eliza: Now, at least, our chase can be brought to end. # Eliza021.ogg
-> END
