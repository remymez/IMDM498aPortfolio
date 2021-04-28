using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SturgeonController : MonoBehaviour, IFish
{
    public string infoName => "SturgeonInfographic";

    public Sprite pic;

    public string Info => "Sturgeons, aka paddlefish, aka dinosaur fish, are some of the oldest fish species, appearing in the fossil record about 200 million years ago. There are 26 species of sturgeon, and all are considered endangered. Living in North America, Europe, and Asia, these ancient fish are often harvested for food, along with their eggs which are eaten as caviar. Although the sturgeon population has been reduced by harvesting, at one time these fish saved early American settlers when, in 1609 a large group ventured to their spawning ground in the James River, and the settlers were able to use their meat and eggs. A huge beast, the Atlantic Sturgeon can grow to 12-14 feet long and weigh up to 800 pounds. With their massive size, forked tails, bony amour, and dangling whiskers, they can’t be called a beautiful fish and are, in fact, downright scary ugly. Because sturgeon haven’t spawned naturally in Maryland Rivers in a long time (decades), recovery work is being conducted in other sections of the Chesapeake Bay watershed, namely in the James River in Virginia. Stan the Sturgeon will be happy to know that there are efforts to replenish the population and help them reproduce, but biologists note that because they don’t reach sexual maturity until they’re 10-15 years old (they can live 60 years!) and only spawn every 2-3 years, recovery will not be easy. Legal restraints also help, but fishermen are concerned that these will block them from their livelihood, as caviar is an expensive commodity. Still, so far the fisherfolk have not stopped recovery efforts.";

    public string SpeciesName => "Sturgeon";

    public Sprite Pic => pic;


}

