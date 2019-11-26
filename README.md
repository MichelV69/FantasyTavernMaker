# Fantasy Tavern Maker
***For Fantasy Worlds Settings such as Dungeons & Dragons 5th Edition***

## Current Version

1.2.0

## Purpose 

Most Games Masters or Authors are aware that they need to unique and 
interesting Pubs, Taverns, Inns, Wayhouses and the like as part of the 
adventure-travel narrative. However, it can be awkward to do so easily 
on-the-fly without complex table rolling that interrupts the flow of the story.

Based on a few ideas I had  I decided to put together a simple DOT-Net / 
C-Sharp application that would quickly handle this job.

### Notable Changes for 1.2.x
NPC Staff / Patron generation!  It's still pretty rough, but it does get a lot
of the heavy lifting done.  As always, some intentional editing / curating is
required by the DM/GM for use;  don't just blindly copy-paste.

## Sample Output

```
Name:  the Saucy Hen
Establishment Quality: Wealthy;  Room 2gp & Board 8sp
Size: small, with 9 tables. It has 7 bunk-beds in the common room and 1 private rooms
Current Mood: seedy
Lighting Environment: dimly lit by candles
Smells of: wood smoke and hot spiced cider
Posted Sign: over the bar says 'We Don't Serve Adventurers'
Specialty Drink: the House's own Light Ale, for 7 silver
Specialty Food: honey braised sausage, served with leeks, onions and cat-tails, for 9 silver
Establishment History: The establishment is a permanent local fixture, and has
been in business for 6 years. The building is in good condition, and shows
evidence of regular care. A local milita band stops by here every 13 days as
part of their patrol route.
Red Light Services: <none>

 ------                           ------
Notable Staff & Patrons
Staff : (Character) is the Owner. They are a male half-elf; short-ish (-5%) and
medium build (3%). They are brown-eyed, with their dark hair kept in a top-knot.

 ------                           ------

  The local Pub and Bed House for travellers is the the Saucy Hen. The
Wealthy-quality establishment would be considered small, with 9 tables. It has 7
bunk-beds in the common room and 1 private rooms. Rooms are 2gp per day, and
meals are 8sp per day.

  As you enter, you smell wood smoke and hot spiced cider. It seems to be a
seedy place, dimly lit by candles. A sign over the bar says 'We Don't Serve
Adventurers'.

  The menu has the usual standard fare posted. The House Specialty Drink is the
House's own Light Ale, for 7 silver, while the House Specialty Meal is honey
braised sausage, served with leeks, onions and cat-tails, for 9 silver.


 ------
Press [ESC] to exit, or [SPACE] to generate 3 more.
```

## How To Use

+ Download the installer
+ Install to where-ever makes the most sense for you
+ Run the installed EXE
    + An optional command line parameter is how big the batch of Pub/Inns is.
    So `PBHouse_CLI.exe 1` will create one-at-a-time, where as `PBHouse_CLI.exe 7`
    will create 7 in a run.  By default, 3 are created.
+ No input is required;  output is automatically created.
+ Review the batch of generated Pubs & Inns;  mix and match as you like to get one or two
that suit your setting.  Copy-Paste results to your favorite text editor.
+ To generate another batch of Inns & Taverns, press the [SPACE] bar
+ To finish up, press your [ESC] ("Escape") key
