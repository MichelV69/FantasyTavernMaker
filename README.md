# Fantasy Tavern Maker
***For Fantasy Worlds Settings such as Dungeons & Dragons 5th Edition***

## Current Version
1.3.0

## Purpose 
Most Games Masters or Authors are aware that they need to unique and 
interesting Pubs, Taverns, Inns, Wayhouses and the like as part of the 
adventure-travel narrative. However, it can be awkward to do so easily 
on-the-fly without complex table rolling that interrupts the flow of the story.

Based on a few ideas I had  I decided to put together a simple DOT-Net / 
C-Sharp application that would quickly handle this job.

### Notable Changes for 1.3.x
NPC Staff / Patron generation has been improved!  It's still pretty rough, but 
it does get a lot of the heavy lifting done.  The larger the Inn or Pub, the
more staff will be randomly rolled, as well as possible "regular patrons".

An new "NPC only" mode is available now.  If you need to generate a crowd of 
NPCs, you can do so easily.  It's also handy to keep a pre-generated list of
folks the characters can talk to at other points in the story.

As always, some intentional editing / curating is required by the DM/GM 
for use; don't just blindly copy-paste.

## Sample Output

```
   -----                        Player Blurb                        -----
  The local Pub and Bed House for travellers is the the Saucy Ice. The
Modest-quality establishment would be considered massive, with 29 tables. It has
18 tent-beds in the common room and 17 private rooms. Rooms are 5sp per day, and
meals are 3sp per day.

  As you enter, you smell strong drink and baking sweets. It seems to be a dour
place, clearly lit by candles. A sign just outside the door says 'No Spell
Casting!'.

  The menu has the usual standard fare posted. The House Specialty Drink is the
House's own Hoppy, pale Ale, for 16 copper, while the House Specialty Meal is
ground-pit charcoaled sausage, served with mushrooms, for 16 copper.

    -----                  Notable Staff & Patrons                  -----
Staff : (Character) is the Owner. They are a male human; average height (3%) and
stout (+13%). They are hazel-eyed, with their white hair kept in long curls.
[GM Notes: They consider themselves hetro.  (Quirks:  They have a slight scar on
their right shoulder.  They are often distrustful of adventurers. ) Particularly
Good At: [(Int) Arcana: +2] Particularly Bad At: [(Wis) Animal Handling: -3]]

 Staff : (Character) is the Cook. They are a female dwarf; tall-ish (+7%) and
medium build (2%). They are hazel-eyed, with their dark hair kept in a long
braid.
[GM Notes: They consider themselves hetro.  (Quirks:  They have a
substantial wine-stain on their right leg.  )  ]

 Staff : (Character) is the Head Server. They are a male half-elf; average height
(0%) and slightly angular (-2%). They are hazel-eyed, with their blonde hair
kept in a long ponytail.
[GM Notes: They consider themselves hetro.  (Quirks:
They have a noticeable scarification on their right collar-bone.  They are often
grumpy. ) Particularly Good At: [(Chr) Intimidation: +2][(Var) Trade Skill: +1]
]

 Staff : (Character) is the Bouncer. They are a female human; short (-19%) and
slightly husky (+9%). They are brown-eyed, with their dark hair kept in a few
short braids.

                                                                                 
 Regular Patron (visiting: 5 in 8) : (Character) is a Craftsperson. They are a   
male dragonborn; average height (1%) and medium build (0%). They are green-eyed, 
with their dark hair kept in a short ponytail.                                   
[GM Notes: They consider                                                         
themselves hetro.  (Quirks:   They tend to be playful. ) Particularly Good At:   
[(Var) Trade Skill: +1] ]                                                        
                                                                                 
 Regular Patron (visiting: 1 in 8) : (Character) is a Bounty-Hunter accompanied  
by 2 thugs. They are a female half-elf; short-ish (-8%) and slightly angular     
(-9%). They are brown-eyed, with their blue hair kept shaved clean.              
[GM Notes:                                                                       
They consider themselves hetro.  (Quirks:  They have a noticeable wine-stain on  
their right cheek.  ) Particularly Good At: [(Str) Athletics: +2] Particularly   
Bad At: [(Int) Arcana: -3]]                                                      
                                                                                 
 Regular Patron (visiting: 7 in 8) : (Character) is a Bounty-Hunter accompanied  
by 1 thugs. They are a male halfling; average height (1%) and medium build (1%). 
They are hazel-eyed, with their dark hair kept long and loose.                   
[GM Notes: They                                                                  
are flirtatiously hetro.    ]                                                    
                                                                                 
   -----                          DM Notes                          -----        
Establishment History: The establishment is recently established, within the     
past 4 months. The establishment and its grounds look to be nearly brand new.    
Traveling merchants know the place well.                                         
Red Light Services:  (Brothel Services (DC11)) (Smuggling (DC16)) 
(Thief / Assassin Guild (ADV w/Thieves Cant) (DC27))
                                                                                 
   -----                  ------   ------   ------                  -----        

Press [ESC] to exit, or [SPACE] to generate 1 more.
```

## How To Use

+ Download the installer
+ Install to where-ever makes the most sense for you
+ Run the installed EXE.
    + the size of the batch of either Pubs & Inns, or NPCs, that you want to create
    + enter if you only want NPCs to be generated (True or False)
+ Review the batch of generated Pubs & Inns;  mix and match as you like to get one or two
that suit your setting.  Copy-Paste results to your favorite text editor.
+ To generate another batch of Inns & Taverns, press the [SPACE] bar
+ To finish up, press your [ESC] ("Escape") key
