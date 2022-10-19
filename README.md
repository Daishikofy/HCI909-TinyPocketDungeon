Lola MAGNARD  
Rebecca RUVALCABA  
Group 9  
HCI909: Advanced Programming of Interactive Systems

# Tiny Pocket Dungeon

This README will discuss how to play Tiny Pocket Dungeon and explanations of how to play the game, design decisions, and code architecture.

INITIAL SETUP
=============

If you wish to run the code within the Unity editor you will need to download :

-   The Unity hub : <https://unity3d.com/get-unity/download>

-   Unity version 2021.3.4.f1

Once this is done you can clone the following repository in the folder of your choice. <https://github.com/Daishikofy/HCI909-TinyPocketDungeon>  

```
git clone  git@github.com:Daishikofy/HCI909-TinyPocketDungeon.git
```

Once cloned, you can access the project from unity hub by going in "Projects" and selecting "Add".

OVERVIEW
========

Tiny Pocket Dungeon is a mobile, roguelike, card game. The goal of the player is to fight enemies, collect loot, and make it to the end of each cavern before the lava reaches you.

![](https://lh4.googleusercontent.com/zt5dy7Bs6eqKsyWM6xKspThK-C5rOSsqDf0eeLGTX8TWY09ri1uJdqUvzGyEcvLzLpLaVgpFbrq0FvAGXnOjBKHCvBUD2J85cvRxlG7KMw0wWQobDZWwTJkjTAnkBDgq9_7Vp5UawnHWaXJy9N5auTHYbIXTml9m0G9N4hX38L0iHJBJSBwuJgQSIw)![](https://lh4.googleusercontent.com/1Itn12BFhFTNMdBEpq79KitS8okE78jFxmShpWmLu7kKGvQU82RVQxwGThoWyf3iHrLqB9IpbWbYUTFjFC86fyRkf3XZPReeN5O7sMloU_ARQUcfHn6PZDSS1Im5ArfeKIQk0WI5JIxmk01GGGc0PnGW0QeCTOvN7d4fIjFVR_vNHOzemq7ofhGXFg)

Capture of level screen and starting of Level 1: First Steps.

GAMEPLAY
--------

-   The player is given a starting set of 3 cards.

-   There are two main types of cards: a movement card, and magic cards. 

  -   Movement cards allow the player to move to one of the adjacent board cells.

  -   There are 3 types of magic cards:

    -   Sword magic cards  give the player extra attack power.

    -   Pegasus Boots magic cards give the player an extra move for the following two turns.

    -   Hourglass magic cards make the board go slower for the following 4 turns.

![](https://lh5.googleusercontent.com/Rlw_qdbouFqgDPBP-KQgrqgV_DdJKoOnytEljNcRnHzjzjh4agkceQuMm-2Ae9LypS3pMJ7ycrN0vhss8yjOrgr-EeBlLkX0F8nRiRthcsIiBz1mbCKRC8UiaNwieQBwSwTUQtLP1I2aWghcpcmQv2RsW9943EaGtUnUJD9rfB5qPyR-QkO6ZZZ5nA)![](https://lh6.googleusercontent.com/fda1E5-xs1467FNsahjP89lqr4finNCkaXXuBF07ljszO20YyZaOyYoCbl0NjSvuEmc4Vwav1H6wcBQ-zBXsspqv7hDTn81wImvtDc3W69IadsxQMe31Lmg37YenTHTP0nP1vtysAfie0ULEWpkBYilLALChEdgKZ9uEOiMVA8AYgFCaPAm5YJg3Ag)![](https://lh3.googleusercontent.com/d8l-bLGbVBN4hPJR_ABF6AFz8YXikjPXMm1wpkOyb6GzN6lQmVhveAUvGlMArGQ_L5BWEn3ToFN3zi0tG8YXLDaU_xrZ8OuWb38jQq0WtkLDq0QVAfGggIHpvZvX3DkNXbNpDlAgeitYBv6uEbXuSMg31YLwyQ5hUv06vvH6Owm1zSVcMWeMS45unQ)![](https://lh5.googleusercontent.com/B6-BWdORQXduNXz-KHTMIZHQtUHKpDQysRWsuYZ7onGk5m-iazrulf-cKapXgAY2tg_YyYwr2o_v8O70aadztVFknKM89w-qdx0F3K3KOueIkDH0UJ-2e4KW1RDZZkzAgw2JBjEiWK6VWYJ7u9m2CL3-Sa-GEWb8ZcrDR-vWIhOJXKie7oORC1ehzA)

Left to right: movement card, sword magic card, pegasus boots card, and hourglass magic card.

-   Each turn:

    -   Select a card and place the card on a board cell

        -   Complete a turn by selecting a movement card, a magic card, or both.

        -   A player may choose to move to an empty tile, an enemy occupied tile, or a chest occupied tile.

            -   Moving to an enemy occupied tile, attacking the enemy, and successfully killing the enemy will give the player a loot reward.

            -   Moving to a chest occupied tile will give the player a loot reward.
      
                -   Loot can either be a card or coins

    -   Alternatively you can choose to skip your turn.

-   After each turn, the player rolls the dice to be randomly given another card from the deck.

-   Gameplay continues until the game is lost or won:

    -   Win by reaching the end of the cavern.

    -   Lose by perishing in the lava.

![](https://lh4.googleusercontent.com/aPMZaIBHrXFGKz3-gL8n9Lt3NX1PIFb9HRJZopHUDHI1J3J-UvO4FKWoOpfx_8-6QvALNf7jZS3IUhmIjj-nzdQnNSin_uBXIuiRZ0G5i05nNf2yn1tzBW-UZYBp2u2ADqsdtMRevNfo6_rteVvEZsJ9V6Hc1-uKeIC5pKRK9LMbKz59B9LuQ78Aug)![](https://lh3.googleusercontent.com/CtuqGc5t0cQlN8DrCe5LHlI98NHGjPNyt7AeWSZJtYZqfh-vnYuexgBi9tIBRbwou2qv5ITLBcXkMtd7Jgzx0j7jq9M04IbgJDOvUk_zIkbAayVRTO_pTNh4NRw7bEjiZs_hfAsujQnr0i9t6UHXBUwMG8VNZD68z_FPhhWc7dlGghsPFS1O5M0ewg)

Top: Player rolls dice for new card. Enemy has 2/3 health.
Right: Player plays to attack enemy. Enemy now has 1/3 health.                                                                                                         

![](https://lh3.googleusercontent.com/fLWsCl76XjKYVju7VhtxcbjMIzuIAj2VO5bLvO4UXIxIwEsKckslSg9qMk8SDl7QgARNFBIFgG5p-ANhw7XF4TXxdZTVA1jqCvCd4Q5aHO61zr15thi709koiUlCvUHQCMtLF3u4kdp2HqJZY6JPy6N27AlSlD1ULTclUbQGJ8rVfm2LN0iglHQwQw)

Capture of attacking enemy and receiving loot of +5.

INTERACTIONS
============

1.  Click and drop card into the desired board cell.

![](https://lh3.googleusercontent.com/sPM2EJ6_-6bu1-G3KRYq8rJl8dJgefWmVgGpxl2kAI5wP8DhtatPNlmEvokcI5Xh5UJ93OfV3PTMhjWuyQ8wH3dR2IV70qDyKd3MLZcxUKrTlaVk4vFTRWk4mN81k-8SiDnEnB2RgCF0A3VN-9-61KTD2pWkFA8eacZd1FTnjn36HIygSbg2hF7nEg)

The available board cells for the card to be dropped onto will change color slightly when a card is selected, The available board cells will be either the cells adjacent to the player's current position or the player's current cell depending on the chosen card type. The card is highlighted when the player hovers over the card. The card moves up when the player clicks and selects the card. 

![](https://lh5.googleusercontent.com/oFiDaqWwencTgKhJ-LMXF6st55PGmT0YQOMApSSeHkKBap0LTufC4QKn-YUiw50WfM0IcGTX_T5MhatNDJp46DmFKyY-1VKRzKPXNKkcy20Tjp_vvB-mpbf6A6kZNyFw2rNteS6x4a65ctscpgZFNsD71CrkYy06tFJv8uqw8jO-RAuTp7cxJjQd1g)

The player can then select a highlighted cell to drop the card onto. The finger pointer demonstrates the board cell being selected.

![](https://lh5.googleusercontent.com/qPBn2n83rkZHhXkmF1wSsWXrfzGiAjDMRXPEEZSFqey0yTf4Bd2l5J4j9f1xUytdZpyjbd4z8tHiXW86YqbFdX-1_UOaWd68T7cSWf0aXuWeIRFOW2RLVltPhETrhshrxphnnOj5ma0iI49eCyRSIcxBbuBSK8WQMMto1CJyt8CVGozM_bnzqoxuEQ)

Once the player finishes a move, the player moves and the dice appears to roll for a new card to be chosen from the deck.

To improve in future iterations: it would be nice to get the drag and drop feature working to further resemble the grab and drop interaction in physical card games.

1.  Roll the dice

![](https://lh4.googleusercontent.com/Msd7ZiA0L_0T6uo_F8HT_gOurHGzESBbCSaPuazorvg8ppIUj8ndniJLCEAlaZh9xrLCojESktzIzhHbvVQ-zX4R6OJD0XBhS5e7b2h0mQ-x8wuHA-QQLi9hkJJjXI0a_1GvDSuiZtcsfmFTEUW5-mXwtigsmKa5NNVNgzEVNk-bkM4hmfHZemmRPw)![](https://lh4.googleusercontent.com/VCTx57CGmywfg8kPgFjGXwZfXdBI27XWxZc0y45nVkAe9cnlwPJHUmIOSzVyEqxVMOlV4KgDQL1ZvktDsDdVXTS5P0NwMcdQrrnyG25c3WJaKFGGFkXrvzzsftIFkBxEfsxXhGboDzw4nX3ZBCuU3rBm6IISECXr0T7vtgF7e_3T0Tpca5LyZ5r0lw)

After the dice roll is prompted, the user must swipe the dice to "roll" it.  The swipe currently does not affect the direction or how the dice is rolled, but the simple mouse down will begin the dice roll animation.

![](https://lh5.googleusercontent.com/5Tmf3LBU3SMK2INqZuKTI0ceNbVxOYE20rEtAE7PnEARWGvvOYYInx5Rnc3dHN1qmTuvfIcRmddZBMnnA_ryF3BPz193fj8tCkEfI4JvJFjDyPgesnUdasxuLtesUBgmOGMj4c1izzCHqNZAEkfb3o8B7kJmy_v5XCiYMdlxKS570gvGL1mvC_PoMA)

After the dice roll animation is completed, a new card will be added to the player's hand to be used in game.

To improve in future iterations: in order for the player to feel their dice roll is actually themselves rolling and not just an algorithm running, it would be interesting to have the swipe direction of the player affect which direction the dice roll animates.

1.  Button Press

Of course, our game also utilizes traditional methods of interaction, such as button press. Button press is used for skipping a turn in game, selecting the menu, selecting a level, etc.

![](https://lh5.googleusercontent.com/s3IO5bt02-S4RQvRtRHo-0YIJpB_nPiafGxl1ORYDtw6AZmKNnHpdQSG3j_7qAQK1TZ-S0W4bfLOdwMZHeJ8Fy9Jo5Nwal6a4Li0S3Y3e7JcmIf__urt6rn0Lhg521RLNvZKH5L04tJIcThoMd9-YEjB7JMHC837VOMG400BKmyP0WCZydeXykw9qw)![](https://lh3.googleusercontent.com/ng_jVCQ5-67Tvn6OvJvoV04YQLzXf_Fes2LCaC8p1A9PiH834nbvj6j8x0uqE4I1hQ5MqqTuwWLtDZe1BgCpZtpeqx-3etx_X88TVS1qhdw_DYHYpvqub_OqnIIe_oYKu3gYvMTLQ0VBgW1wk-x7OUmFOeUp568qS8dEm0Tl2HriIfnvSwXdvzpakQ)

The above images display the example of a player pressing the Skip Turn button in game.

UNITY-SPECIFIC MACRO
====================

-   When a private field is marked with [SerializedField] Unity will settle the field in the editor. Therefore, the value of those fields is often set within the unity editor.

-   ``AudioClip`` is an audio file, for example ``lava.wav``. 

-   ``Destroy()`` will destroy a game object, asset, or component.

-   ``Awake()`` is called when a script is initialized, while ``Start()`` is called when the script is enabled.

-   ``SetActive(bool)`` will activate or deactivate a game object, for example is used to activate the game over screen.

-   ``Coroutine`` in Unity is similar to an async method, a coroutine is an ``IEnumerator`` return type method with a ``yield return`` statement.

-   ``PlayOneShot()`` will play an ``AudioClip`` once at the desired volume.

Architecture Pattern : PAC
==========================

We utilized a PAC (Presentation-Architecture-Controller) architecture pattern on top of Unity's already-implemented ECS paradigm.

![](https://lh4.googleusercontent.com/35NYKZLw4bDTxf6LiZ8EHa-bCUOKiZQfUa9QqlMBfNCKBAUdR76mDDXgJAzEPDEcSHtVEts8ZLSiJUZSDvPYVN-IXZA-sSB2JnXpIiE889NJTDC9lA-OaL-fmZcfmeQymOFmEb95FplPVnXQjuwFj-lLF-D6yROHIA9NKjAh3Kv3RGyy9v7PHzuqfA)

Overview schematic of scripts and their relations

Many PAC agents were layered to create the game. There are two main PAC agents running the game: the main menu/global PAC and each level/game PAC. Each level is run by its own hierarchy of PAC agents (and edge cases). This includes, but is not limited to, a card PAC agent, board cells PAC agent, enemy PAC agent, etc. Each PAC agent works together with the level’s game controller, UI manager, and game state to operate the level. Refer to the diagrams below for schematic examples of PAC encapsulation in our game’s levels.

![](https://lh6.googleusercontent.com/oECVjuIw036KPDhN9EsmdvTryNnQOaLaLu6AiYiIrhE58vzFrNTjzYTBRXmk-fGye69Ni9IOe3fb2VM2CTlKCYlD71xfR0LEmNbgljWlPhYCgLj7uiPsWqppc-vlIs-v2loPSkTGOUB3VbGZZYuj_Q01oODXlzj78Q2idnW8LZrjUoLMvL6FKkdDLg)

The high level PAC of each level is the level's game controller, UI manager, and game state.

![](https://lh4.googleusercontent.com/Dk7FAXjC12eG16St7FJU5XK6pqF1HNkhf4UAFwgr0xk5QySy9DU3s0XJbUcvOwvZ8f4raBn3rxcnawiZtZGzXDM952L3T0uWFmo42mKe18Pcp9OPcY2X72bLO8So9IjaSe47r_e5xPTQUfsrtJamABwEFYBO-5lLJRRtP0l_nZFZfmZO9BtuCeanaw)

Card PAC

![](https://lh5.googleusercontent.com/d-peB2G89O1Fqlo9Q1uq1COqw3nNe9e5dYMfbaXZ-RIKJy1JYyzm_sUdsICnsy4g0AKf5VGlh53bwlHDwMqjeIPWFgqFZ8_CXYl77ox_X2OC0nUKbkxW2uKIxF5wI6HxQs5dR2D2rP3PyiVQAXee5blwRbYqIQBEROelysLu3u3pGqkunEYwhKEe3w)

Enemy PAC
