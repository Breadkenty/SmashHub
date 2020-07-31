<img src="./ClientApp/src/graphics/logo/logo-on-white.png" width="150"/>

### Version 1.0 [Beta]

## Introduction

Live site: https://smash-combos.herokuapp.com/

A webapp where Super Smash Brothers Ultimate players can upload combos for any characters to share. Takes learning a new character to a whole new level!

## Features

This project is a working progress with more features to come. Here are some to name a few:

### Build your combo:

Create a customized set of combo inputs labeled with Graphics of Gamecube Controller buttons.

<img src="./ClientApp/src/graphics/demo/combo.gif" width="400"/>

### Attach a responsive video:

This feature allows you to highlight sections on videos that are uploaded on Youtube and play them on repeat. Smash Combos will only allow you to attach videos that are relevant to Smash Bros content or your character selected.

<img src="./ClientApp/src/graphics/demo/video.gif" width="400"/>

### Explore combos of every character:

Share all sorts of character combos with other players and join the discussion.

<img src="./ClientApp/src/graphics/demo/interface.gif" width="400"/>

## How to build a combo:

**Conditionals** are used to write these combos like a sentence, they are defined as the following:

<hr/>
<img src="./ClientApp/src/graphics/demo/and-conditional.png" width="75"/>

**And**: Combines two inputs as one input

**Examples**:

_Full hop forward_

<img src="./ClientApp/src/graphics/inputs/png/hop/full-hop.png" width="40"/>
<img src="./ClientApp/src/graphics/demo/and-conditional.png" width="40"/>
<img src="./ClientApp/src/graphics/inputs/png/move/forward-move.png" width="40"/>

_Up smash forward DI_

<img src="./ClientApp/src/graphics/inputs/png/smash/up-smash.png" width="40"/>
<img src="./ClientApp/src/graphics/demo/and-conditional.png" width="40"/>
<img src="./ClientApp/src/graphics/inputs/png/move/forward-move.png" width="40"/>

_Smash forward special_

<img src="./ClientApp/src/graphics/inputs/png/special/forward-special.png" width="40"/>
<img src="./ClientApp/src/graphics/demo/and-conditional.png" width="40"/>
<img src="./ClientApp/src/graphics/inputs/png/flick/forward-flick.png" width="40"/>

<hr/>
<img src="./ClientApp/src/graphics/demo/then-conditional.png" width="75"/>

**Then**: Proceeds to the next set of inputs

**Examples**:

_Jab > jab > jab_

<img src="./ClientApp/src/graphics/inputs/png/basic/jab-basic.png" width="40"/>
<img src="./ClientApp/src/graphics/demo/then-conditional.png" width="40"/>
<img src="./ClientApp/src/graphics/inputs/png/basic/jab-basic.png" width="40"/><img src="./ClientApp/src/graphics/demo/then-conditional.png" width="40"/>
<img src="./ClientApp/src/graphics/inputs/png/basic/jab-basic.png" width="40"/>

_Down tilt > up smash_

<img src="./ClientApp/src/graphics/inputs/png/tilt/down-tilt.png" width="40"/>
<img src="./ClientApp/src/graphics/demo/then-conditional.png" width="40"/>
<img src="./ClientApp/src/graphics/inputs/png/smash/up-smash.png" width="40"/>

_Down throw bair_

<img src="./ClientApp/src/graphics/inputs/png/throw/down-throw.png" width="40"/>
<img src="./ClientApp/src/graphics/demo/then-conditional.png" width="40"/>
<img src="./ClientApp/src/graphics/inputs/png/hop/short-hop.png" width="40"/>
<img src="./ClientApp/src/graphics/demo/then-conditional.png" width="40"/>
<img src="./ClientApp/src/graphics/inputs/png/aerial/back-aerial.png" width="40"/>

<hr/>
<img src="./ClientApp/src/graphics/demo/hold-conditional.png" width="75"/>

**Hold**: Indicates the following input to be held

<img src="./ClientApp/src/graphics/demo/release-conditional.png" width="75"/>

**Release**: Indicates the held button to be released

**Examples**:

_Dash forward_

<img src="./ClientApp/src/graphics/demo/hold-conditional.png" width="40"/>
<img src="./ClientApp/src/graphics/inputs/png/move/forward-move.png" width="40"/>

_Crouch_

<img src="./ClientApp/src/graphics/demo/hold-conditional.png" width="40"/>
<img src="./ClientApp/src/graphics/inputs/png/move/down-move.png" width="40"/>

_Up B out of shield_

<img src="./ClientApp/src/graphics/demo/hold-conditional.png" width="40"/>
<img src="./ClientApp/src/graphics/inputs/png/basic/shield-basic.png" width="40"/>
<img src="./ClientApp/src/graphics/demo/then-conditional.png" width="40"/>
<img src="./ClientApp/src/graphics/inputs/png/special/up-special.png" width="40"/>

_Ground float nair_

<img src="./ClientApp/src/graphics/inputs/png/move/down-move.png" width="40"/>
<img src="./ClientApp/src/graphics/demo/and-conditional.png" width="40"/>
<img src="./ClientApp/src/graphics/demo/hold-conditional.png" width="40"/>
<img src="./ClientApp/src/graphics/inputs/png/hop/full-hop.png" width="40"/>
<img src="./ClientApp/src/graphics/demo/then-conditional.png" width="40"/>
<img src="./ClientApp/src/graphics/inputs/png/move/forward-move.png" width="40"/>
<img src="./ClientApp/src/graphics/demo/then-conditional.png" width="40"/>
<img src="./ClientApp/src/graphics/inputs/png/aerial/neutral-aerial.png" width="40"/>
<img src="./ClientApp/src/graphics/demo/release-conditional.png" width="40"/>

_Charged forward smash_

<img src="./ClientApp/src/graphics/demo/hold-conditional.png" width="40"/>
<img src="./ClientApp/src/graphics/inputs/png/smash/forward-smash.png" width="40"/>
<img src="./ClientApp/src/graphics/demo/then-conditional.png" width="40"/>
<img src="./ClientApp/src/graphics/demo/release-conditional.png" width="40"/>

_Charged forward special_

<img src="./ClientApp/src/graphics/demo/hold-conditional.png" width="40"/>
<img src="./ClientApp/src/graphics/inputs/png/special/forward-special.png" width="40"/>
<img src="./ClientApp/src/graphics/demo/then-conditional.png" width="40"/>
<img src="./ClientApp/src/graphics/demo/release-conditional.png" width="40"/>

<hr/>
<img src="./ClientApp/src/graphics/demo/startRepeat-conditional.png" width="75"/>

**Start Repeat**: Sets the beginning of the set of inputs that will be repeated

<img src="./ClientApp/src/graphics/demo/endRepeat-conditional.png" width="75"/>

**End Repeat**: Indicates the end of the repeat; can be used to tell the amount of repeat times

**Examples**:

_Up tilt_

<img src="./ClientApp/src/graphics/demo/startRepeat-conditional.png" width="40"/>
<img src="./ClientApp/src/graphics/inputs/png/tilt/up-tilt.png" width="40"/>
<img src="./ClientApp/src/graphics/demo/endRepeat-conditional.png" width="40"/>
<img src="./ClientApp/src/graphics/demo/endRepeat-conditional.png" width="40"/>
<img src="./ClientApp/src/graphics/demo/endRepeat-conditional.png" width="40"/>

_Ground float nair x3_

<img src="./ClientApp/src/graphics/demo/startRepeat-conditional.png" width="40"/>
<img src="./ClientApp/src/graphics/inputs/png/move/down-move.png" width="40"/>
<img src="./ClientApp/src/graphics/demo/and-conditional.png" width="40"/>
<img src="./ClientApp/src/graphics/demo/hold-conditional.png" width="40"/>
<img src="./ClientApp/src/graphics/inputs/png/hop/full-hop.png" width="40"/>
<img src="./ClientApp/src/graphics/demo/then-conditional.png" width="40"/>
<img src="./ClientApp/src/graphics/inputs/png/move/forward-move.png" width="40"/>
<img src="./ClientApp/src/graphics/demo/then-conditional.png" width="40"/>
<img src="./ClientApp/src/graphics/demo/release-conditional.png" width="40"/>
<img src="./ClientApp/src/graphics/inputs/png/aerial/neutral-aerial.png" width="40"/>
<img src="./ClientApp/src/graphics/demo/then-conditional.png" width="40"/>
<img src="./ClientApp/src/graphics/inputs/png/move/forward-move.png" width="40"/>
<img src="./ClientApp/src/graphics/demo/endRepeat-conditional.png" width="40"/>
<img src="./ClientApp/src/graphics/demo/endRepeat-conditional.png" width="40"/>
<img src="./ClientApp/src/graphics/demo/endRepeat-conditional.png" width="40"/>

_Short hop fast fall nair x3_

<img src="./ClientApp/src/graphics/demo/startRepeat-conditional.png" width="40"/>
<img src="./ClientApp/src/graphics/inputs/png/hop/short-hop.png" width="40"/>
<img src="./ClientApp/src/graphics/demo/then-conditional.png" width="40"/>
<img src="./ClientApp/src/graphics/inputs/png/flick/down-flick.png" width="40"/>
<img src="./ClientApp/src/graphics/demo/then-conditional.png" width="40"/>
<img src="./ClientApp/src/graphics/inputs/png/aerial/neutral-aerial.png" width="40"/>
<img src="./ClientApp/src/graphics/demo/endRepeat-conditional.png" width="40"/>
<img src="./ClientApp/src/graphics/demo/endRepeat-conditional.png" width="40"/>
<img src="./ClientApp/src/graphics/demo/endRepeat-conditional.png" width="40"/>

<hr/>

## YouTube Video Implementation:

In order to attach a valid YouTube video, the video has to be related to Super Smash Bros **or** your selected character. This feature will prevent unrelated videos to be attached to your combos. To submit a valid video, please grab the YouTube video ID.

**Example:**
`https://www.youtube.com/watch?v=QyCmYdgo_Ik`

**ID:** `QyCmYdgo_Ik`

**Good video:**

<img src="./ClientApp/src/graphics/demo/good.png" width="400"/>

**Bad video:**

<img src="./ClientApp/src/graphics/demo/bad.png" width="400"/>

<hr/>

## Contribution

Coming soon...

## Credits

[Smash Wiki](https://www.ssbwiki.com/) : Controller buttons

[Spriters Respource](https://www.spriters-resource.com/) : Character images

[eu Samsora](https://twitter.com/Samsora_) : Videos for examples, and as a Peach main, he's my role model

[Suncoast Developers Guild](https://suncoast.io/) : Where I learned to make this app in 3 months from no experience whatsoever
