Lola MAGNARD  
Rebecca RUVALCABA  
Group 9  
HCI909: Advanced Programming of Interactive Systems

# Tiny Pocket Dungeon

This README will discuss how to play Tiny Pocket Dungeon and explanations of how to play the game, design decisions, and code architecture.

OVERVIEW
========

Tiny Pocket Dungeon is a mobile, roguelike, card game. The goal of the player is to fight enemies, collect loot, and make it to the end of each cavern before the lava reaches you.

![](https://lh5.googleusercontent.com/-dX0DSQRFWjkdLXmLE1dZNjVo3b6Vh-R3tvCOm0ByIQEA8RsjOSvJWdbFtS21lO6PWOoRSBlfHneLk3hVtEwdmYxoenbp3B_ErArLfRQUKm2TX2gw2OFOfBEsZ6GsMS9rKBj_bVMSn9N2tdN3rvzSO4QseWD5UWPH69icQa_LsiUfDLx6wAN_fl2iw)

Capture of start of game

GAMEPLAY
--------

-   The player is given a starting set of 3 cards.

-   There are two main types of cards: a movement card, and magic cards. 

-   Movement cards allow the player to move to one of the adjacent board cells.

-   There are 3 types of magic cards:

-   Sword magic cards  give the player extra attack power.

-   Pegasus Boots magic cards give the player an extra move for the following two turns.

-   Hourglass magic cards make the board go slower for the following 4 turns.

![](https://lh6.googleusercontent.com/3MahcLRTMP4PBrPoazUVtIORugucv4dusKagPsYQFp1y6Nlaj2OE9JCX5hi1llu-GBk3XbG7vGKoBZbHZ1eF5O1_151EbMvst5VrzBHErSh5uOwm3ztIlbOiGH4f0GsCHl0mz-dGp58y6_4bpXpjjohZkc9Vyq4r1gOgD3AYKuVyZIYvLoFYUm0S1Q)![](https://lh6.googleusercontent.com/W1pDVBoaFqrFjrWfiyOlilAJBxuYdtt6eo5lYn_KiSoxXogQrR-sRJ9m4wNXW8eA4AOQsrIDddu0a41iIMQjCbKN3KM6TZJHqOApvJiKKUjxxckvdtyTWVEochK-XGUtjAIEeO6EcDH9kuzZAPyAV8ZXjaaLd4MvlgiLNi0nXl9sqg1vmL3tkDYVdg)![](https://lh6.googleusercontent.com/uKnEI9YCNFiFYb4TzkTvxRvOeoGW_73Hi2wc2ty7zX6qGZW9c6tEmGZBhZ1LnnPP5PGyEwFzmp8jiy-3mokfoahS1aK1kgDnCWS5UPqkG1xaOmq69XllOe5tiNIiwWihqcsWQYEj9YuZdkr5eUj2IN6xQ3nHZ_DfmI0BjgCkLw-lSBWgRILFovn8mw)![](https://lh5.googleusercontent.com/BFGWZ7O5U7DifsOaJxw46kJqDwSRqieaWqrgrr_yTVJYFb-7CAkMUp7nTSNxOKghHLDRdY8Q3xLIE7nLlzxFDwchSQj1mDoGx-SKvtLIDL1ym_YBnmU6Ov6WC6mFRyEjdhxpixJ7JT4WP1eNc8RKVX7iXAl91ql7lMY8hqIhxH5zlnOZBNuhaghbKw)

Left to right: movement card, sword magic card, pegasus boots card, and hourglass magic card.

-   Each turn:

-   Select a card, and complete the turn to receive a dice to roll.

-   Complete a turn by selecting a movement card, a magic card, or both.

-   A player may choose to attack an enemy on a turn or not.

-   Attacking enemies and successfully killing them will give the player a loot reward.

-   Alternatively you can choose to skip your turn.

-   After each turn, the player rolls the dice to be randomly given another card from the deck.

-   Gameplay continues until the game is lost or won:

-   Win by reaching the end of the cavern.

-   Lose by perishing in the lava.

![](https://lh3.googleusercontent.com/pC6Q3h0Gq24K5Pl_B8CH0fF3yEWXMgl0aHL0eliUYXEWSQL0gzkRTaPhzxvmvCd6P8v5WLEUYdlelhrM4ZLIWO19PaBzPgQlkLFl2ZVcao97acwTbtwO-168HtRyM-7YkZnp2_3LWKrGOwbDwIgnSc8VApW3wKaBpm77FAmgXpymEP5zEt0O5DVmQQ)![](https://lh5.googleusercontent.com/g3rq-fN4vLg3AfyhZFG0qH6l95HdNpmWuAr_uF82dDEkEyPmx3xwjfEIIlsguAvqkSCoF_6A059gOTLANYgevEaPWTDrI7V_5Fs1jgkCPru52L2TAdYXA26GVddHc2PVBPnVdRU5PIItEBC2J5qg9WF2GzgAToQj0cT6T4ELN9u0QZ5f4-enhhU-KA)

Left: Player rolls dice for new card. Enemy has                              Right: Player plays to attack enemy.

2/3 health.                                                                                                                               Enemy now has 1/3 health.

![](https://lh6.googleusercontent.com/VGQXYl559OLIRnP-l_OAC0tmY-IH0Lo_4obrb-2Xxvrtumf9oVFZriXVxsIyKQ_uRaStEPTlyBRmg8jRjeatIqIXu3_QjWBGtoEeZa4yjoTdXR1WO_C2OjBMGTVpnCGgFoxvn0RfiJ3_ufgjCMl-2MAdgR9AP6ILQhWjkxsv2nW0jrWzmHvfFXb_Og)

Capture of attacking enemy and receiving loot of +5.

INTERACTIONS
============

1.  Click and drop card into the desired board cell.

![](https://lh4.googleusercontent.com/zoXdcytysB7M6UPAVYph3IZqySoOR5Msa1J1iL67SJEEtokLcRoDnEFH6fPs-zmq2MumXvO62pXDZVpmNaPAy2c0GKv9sbcxKEnpz5W8NqLgmEQowfO77mOoIAgnGbmY9F9avl2CbBOhWmPMmgbIQ6kSruHF-p0OMOgklLogIHkjODOqPbDI1fBAIA)

The available board cells for the card to be dropped onto will change color slightly when a card is selected, The available board cells will be either the cells adjacent to the player's current position or the player's current cell depending on the chosen card type. The card is highlighted when the player hovers over the card. The card moves up when the player clicks and selects the card. 

![](https://lh3.googleusercontent.com/_5Tdqd1L9EISp8LwCqlLeWcWjFTLIJyuV0OrEqk5cR5biXm2Ux6aZ2GV0Y3EysZkLRuE3mheNaX4mstZZLh0rAbCA5psUzDFdHoJ8cN1JV7QPVQzRG8PEloavbpTI9UY-T_zEHffedZNNev5uQnJ2g4EMT8TaTffqRDzf11ND2079c1PlVtZs1Pkzw)

The player can then select a highlighted cell to drop the card onto. The finger pointer demonstrates the board cell being selected.

![](https://lh5.googleusercontent.com/0ON2X9lmopo64ybXuRLC4aMDVl9qPVSJHjg6UFR9yhCSbg2bpFk5Hvu0NrLembhwfkMqaHRDBOyPreM4WO_otfYYD_sW1oFjhHa7fL8EdBWle2-Qwg76GyLlFfWgn04zDvHS6vo0UvEBJxI_p4waz2J3EcKOec_SVRxUJrnAaHiz3-pWBsLwRT91wg)

Once the player finishes a move, the player moves and the dice appears to roll for a new card to be chosen from the deck.

To improve in future iterations: it would be nice to get the drag and drop feature working to further resemble the grab and drop interaction in physical card games.

1.  Roll the dice

![](https://lh3.googleusercontent.com/nv1IoiAiEC9MOCEsnK2mqu0lTmes2HYQWYGBurtyel9KZ2Olk6XiHsFHh93Fshlr5yK1hJOKXeja7-cFCbvBZuIWJjTur53EwxfiIeEo4VSpdTuYOfLJFxtVCIUyvFqh_h8DwWGaNmz1wgfRTPBiLWh9B8n_CLwR59pGm_AWhGnCUBLDrd3hYWz4Zw)![](https://lh4.googleusercontent.com/u2lB-mtBoHy_bM9z-0g1mduDDCANmWpBkej04toSE7eE9k_B2vpCKjubK2uHoWzWJde_SED3euH-ISf_fKAqIEP5rti2QO7_8KkYZ3vo12NVVzrisNafmMSx0fYplMvi_b9N2-5B8vdVodhPA4H2S_nemvU7xvHtH8u9tHjyRwxH1Rgbuqc1huKSRg)

After the dice roll is prompted, the user must swipe the dice to "roll" it.  The swipe currently does not affect the direction or how the dice is rolled, but the simple mouse down will begin the dice roll animation.

![](https://lh4.googleusercontent.com/6-w_kYL9jvQsudQdkkcLPdgO5tnUOOkzqc1J3nD-51z2YhxeZVGu310r3QOy6ALvhx1qq5C7ca_W1dlK-bin9XxTLTDaeN62xwbSrNH1dkC3MO3HNBA7Pcbsa2BoApSe-1fHzohgR4u3y2j1r1MCuiMPXiH2-9q1kn5SOaBAjHygFi1KUrpQm6Or3Q)

After the dice roll animation is completed, a new card will be added to the player's hand to be used in game.

To improve in future iterations: in order for the player to feel their dice roll is actually themselves rolling and not just an algorithm running, it would be interesting to have the swipe direction of the player affect which direction the dice roll animates.

1.  Button Press

Of course, our game also utilizes traditional methods of interaction, such as button press. Button press is used for skipping a turn in game, selecting the menu, selecting a level, etc.

![](https://lh5.googleusercontent.com/mtfAPtddPFjX5OL0rdrFZUseMdLcKIunj09199gCUpJl1HeL4QWjePbh51mhFXex6NmEV0bRLm6MHhLFijZH0rmUPpZ0vaeztnuM-0ZuoX5hZcLAnrp0MKuMfJnBv4EH8lvwvncHbZCczq-bN04X_0BXniVqq8wKN93FjYkCwRH2Kyte3iSNXUYzRw)![](https://lh5.googleusercontent.com/4O3tKsneMGLi6UfsLzU_rgadfMSl7Ufezi4-Qv1TMB7kQnzudh_y3-MS3eB99My4y9W1IF8_aZMMS3joubb7nFzxJsuMZGbHQ8quqUl-T9Ii5WQf32JFBfcnG4LBK7DPDgJ5_1HIeeUCSFixQnkh2jL5r79VJZZ3dZkxCitFdscX2APM3Fx5ORCmMA)

The above images display the example of a player pressing the Skip Turn button in game.

UNITY-SPECIFIC MACRO
====================

-   When a private field is marked with [SerializedField] Unity will settle the field in the editor.

-   AudioClip is an audio file, for example lava.wav. 

-   Destroy() will destroy a game object, asset., or component.

-   Awake() is called when a script is initialized, while Start() is called when the script is enabled.

-   SetActive(bool) will activate or deactivate a game object, for example is used to activate the game over screen.

-   Coroutine in Unity is similar to an async method,a coroutine is an IEnumerator return type method with a yield  return statement.

-   PlayOneShot() will play an AudioClip once at the desired volume.

Architecture Pattern : PAC
==========================

We utilized a PAC (Presentation-Architecture-Controller) architecture pattern on top of Unity's already-implemented ECS paradigm.

![](https://lh6.googleusercontent.com/x0AKQSgN019C5nkG4oLp-CX5RHD4NkXpZj40hLUWDKEA6feuxH2kCo1rblmCVPwxOdOPNFFBYDkHa2hrZOiiuQEgzbFWW4QTqVu7eMI97km_1y0Ob0MO5x3lreO0gqFK_uNFRAJIwtkJ3sopm8XXBppHSZhobbAKAQGtLD8L87KG5lKSQr6x8p-RXg)

Overview schematic of scripts and their relations

Many PAC agents were layered to create the game. For example, each level is run by its own hierarchy of PAC agents. This includes, but is not limited to, a card PAC agent, board cells PAC agent, enemy PAC agent, etc. Each PAC agent works together with the level's game controller, UI manager, and game state to run each level of the game. Refer to the diagrams below for schematic examples of PAC agents in our game.

![](https://lh5.googleusercontent.com/lmbk8qZutNI3lbtij5L4l4dDmFMmteyjobg-JvMZ6BGpBtVIu-l-ne6EAxeoN9A09JH5fZaEKdnvRVgFPUONP0Dgfeb9txDuyArH6wIMLvGzcq7KqFHAwcyysXhVSde-HvZAzmTsKD1wih4gVPzEgdhwYeDLIVCHHmLvXuNzxaiLqQPHDKuAVkDelQ)

The high level PAC agent of each level is the level's game controller, UI manager, and game state.

![](https://lh6.googleusercontent.com/NLHJmb8I-sRy3_9QB1Z6YjHBNisx3LXAacNqdrPTqRBWe05vY287uh3A7C3I9U-KCFGIHiE9g-ScFSbPOIid1baBeIZtKvjppk6F54aQzGbeR9us_CzcBApgo8TC5i67DBAwKlWZvuG7UmcE4zHVbYVcIhyq2FaLsa0wnQs3V02ABu_TMVize15OMQ)

Card PAC agent

![](https://lh3.googleusercontent.com/r_aSBOGAVcyR6jwWG1pbHN-Eqguby_WhkJRzQAspp4ALe4odqE6HhiW-56MeeAfOP00uUKuoo6Zo4-ZpSybMdrhKJISxDjJ5k42_Vq7eZQCNq2iObb9DVs9mTNaOtXJ8THCrIRaquQicd6VxN_3-od2fE4B9zEoGG4PGVBzEzRkKykEX3WAWtzCTcw)

Enemy PAC agent
