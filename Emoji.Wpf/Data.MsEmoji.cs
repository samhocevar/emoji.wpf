
using System.Collections.Generic;

namespace Emoji.Wpf
{
    public static partial class Data
    {
        private static Dictionary<string, string> m_ms_emoji = new Dictionary<string, string>()
        {

            { "\U0001f48f\U0001f3fb", "Kiss, Type-1-2" }, // 1f48f-1f3fb
            { "\U0001f48f\U0001f3fc", "Kiss, Type-3" }, // 1f48f-1f3fc
            { "\U0001f48f\U0001f3fd", "Kiss, Type-4" }, // 1f48f-1f3fd
            { "\U0001f48f\U0001f3fe", "Kiss, Type-5" }, // 1f48f-1f3fe
            { "\U0001f48f\U0001f3ff", "Kiss, Type-6" }, // 1f48f-1f3ff
            { "\U0001f491\U0001f3fb", "Couple With Heart, Type-1-2" }, // 1f491-1f3fb
            { "\U0001f491\U0001f3fc", "Couple With Heart, Type-3" }, // 1f491-1f3fc
            { "\U0001f491\U0001f3fd", "Couple With Heart, Type-4" }, // 1f491-1f3fd
            { "\U0001f491\U0001f3fe", "Couple With Heart, Type-5" }, // 1f491-1f3fe
            { "\U0001f491\U0001f3ff", "Couple With Heart, Type-6" }, // 1f491-1f3ff
            { "\u26f7\U0001f3fb", "Skier, Type-1-2" }, // 26f7-1f3fb
            { "\u26f7\U0001f3fc", "Skier, Type-3" }, // 26f7-1f3fc
            { "\u26f7\U0001f3fd", "Skier, Type-4" }, // 26f7-1f3fd
            { "\u26f7\U0001f3fe", "Skier, Type-5" }, // 26f7-1f3fe
            { "\u26f7\U0001f3ff", "Skier, Type-6" }, // 26f7-1f3ff
            { "\U0001f600", "Grinning Face" }, // 1f600
            { "\U0001f601", "Grinning Face With Smiling Eyes" }, // 1f601
            { "\U0001f602", "Face With Tears of Joy" }, // 1f602
            { "\U0001f923", "Rolling on the Floor Laughing" }, // 1f923
            { "\U0001f603", "Smiling Face With Open Mouth" }, // 1f603
            { "\U0001f604", "Smiling Face With Open Mouth &amp; Smiling Eyes" }, // 1f604
            { "\U0001f605", "Smiling Face With Open Mouth &amp; Cold Sweat" }, // 1f605
            { "\U0001f606", "Smiling Face With Open Mouth &amp; Closed Eyes" }, // 1f606
            { "\U0001f609", "Winking Face" }, // 1f609
            { "\U0001f60a", "Smiling Face With Smiling Eyes" }, // 1f60a
            { "\U0001f60b", "Face Savouring Delicious Food" }, // 1f60b
            { "\U0001f60e", "Smiling Face With Sunglasses" }, // 1f60e
            { "\U0001f60d", "Smiling Face With Heart-Eyes" }, // 1f60d
            { "\U0001f618", "Face Blowing a Kiss" }, // 1f618
            { "\U0001f617", "Kissing Face" }, // 1f617
            { "\U0001f619", "Kissing Face With Smiling Eyes" }, // 1f619
            { "\U0001f61a", "Kissing Face With Closed Eyes" }, // 1f61a
            { "\u263a", "Smiling Face" }, // 263a
            { "\U0001f642", "Slightly Smiling Face" }, // 1f642
            { "\U0001f917", "Hugging Face" }, // 1f917
            { "\U0001f929", "Star-Struck" }, // 1f929
            { "\U0001f914", "Thinking Face" }, // 1f914
            { "\U0001f928", "Face With Raised Eyebrow" }, // 1f928
            { "\U0001f610", "Neutral Face" }, // 1f610
            { "\U0001f611", "Expressionless Face" }, // 1f611
            { "\U0001f636", "Face Without Mouth" }, // 1f636
            { "\U0001f644", "Face With Rolling Eyes" }, // 1f644
            { "\U0001f60f", "Smirking Face" }, // 1f60f
            { "\U0001f623", "Persevering Face" }, // 1f623
            { "\U0001f625", "Disappointed but Relieved Face" }, // 1f625
            { "\U0001f62e", "Face With Open Mouth" }, // 1f62e
            { "\U0001f910", "Zipper-Mouth Face" }, // 1f910
            { "\U0001f62f", "Hushed Face" }, // 1f62f
            { "\U0001f62a", "Sleepy Face" }, // 1f62a
            { "\U0001f62b", "Tired Face" }, // 1f62b
            { "\U0001f634", "Sleeping Face" }, // 1f634
            { "\U0001f60c", "Relieved Face" }, // 1f60c
            { "\U0001f61b", "Face With Stuck-Out Tongue" }, // 1f61b
            { "\U0001f61c", "Face With Stuck-Out Tongue &amp; Winking Eye" }, // 1f61c
            { "\U0001f61d", "Face With Stuck-Out Tongue &amp; Closed Eyes" }, // 1f61d
            { "\U0001f924", "Drooling Face" }, // 1f924
            { "\U0001f612", "Unamused Face" }, // 1f612
            { "\U0001f613", "Face With Cold Sweat" }, // 1f613
            { "\U0001f614", "Pensive Face" }, // 1f614
            { "\U0001f615", "Confused Face" }, // 1f615
            { "\U0001f643", "Upside-Down Face" }, // 1f643
            { "\U0001f911", "Money-Mouth Face" }, // 1f911
            { "\U0001f632", "Astonished Face" }, // 1f632
            { "\u2639", "Frowning Face" }, // 2639
            { "\U0001f641", "Slightly Frowning Face" }, // 1f641
            { "\U0001f616", "Confounded Face" }, // 1f616
            { "\U0001f61e", "Disappointed Face" }, // 1f61e
            { "\U0001f61f", "Worried Face" }, // 1f61f
            { "\U0001f624", "Face With Steam From Nose" }, // 1f624
            { "\U0001f622", "Crying Face" }, // 1f622
            { "\U0001f62d", "Loudly Crying Face" }, // 1f62d
            { "\U0001f626", "Frowning Face With Open Mouth" }, // 1f626
            { "\U0001f627", "Anguished Face" }, // 1f627
            { "\U0001f628", "Fearful Face" }, // 1f628
            { "\U0001f629", "Weary Face" }, // 1f629
            { "\U0001f92f", "Exploding Head" }, // 1f92f
            { "\U0001f62c", "Grimacing Face" }, // 1f62c
            { "\U0001f630", "Face With Open Mouth &amp; Cold Sweat" }, // 1f630
            { "\U0001f631", "Face Screaming in Fear" }, // 1f631
            { "\U0001f633", "Flushed Face" }, // 1f633
            { "\U0001f92a", "Crazy Face" }, // 1f92a
            { "\U0001f635", "Dizzy Face" }, // 1f635
            { "\U0001f621", "Pouting Face" }, // 1f621
            { "\U0001f620", "Angry Face" }, // 1f620
            { "\U0001f92c", "Face With Symbols Over Mouth" }, // 1f92c
            { "\U0001f637", "Face With Medical Mask" }, // 1f637
            { "\U0001f912", "Face With Thermometer" }, // 1f912
            { "\U0001f915", "Face With Head-Bandage" }, // 1f915
            { "\U0001f922", "Nauseated Face" }, // 1f922
            { "\U0001f92e", "Face Vomiting" }, // 1f92e
            { "\U0001f927", "Sneezing Face" }, // 1f927
            { "\U0001f607", "Smiling Face With Halo" }, // 1f607
            { "\U0001f920", "Cowboy Hat Face" }, // 1f920
            { "\U0001f921", "Clown Face" }, // 1f921
            { "\U0001f925", "Lying Face" }, // 1f925
            { "\U0001f92b", "Shushing Face" }, // 1f92b
            { "\U0001f92d", "Face With Hand Over Mouth" }, // 1f92d
            { "\U0001f9d0", "Face With Monocle" }, // 1f9d0
            { "\U0001f913", "Nerd Face" }, // 1f913
            { "\U0001f608", "Smiling Face With Horns" }, // 1f608
            { "\U0001f47f", "Angry Face With Horns" }, // 1f47f
            { "\U0001f479", "Ogre" }, // 1f479
            { "\U0001f47a", "Goblin" }, // 1f47a
            { "\U0001f480", "Skull" }, // 1f480
            { "\u2620", "Skull and Crossbones" }, // 2620
            { "\U0001f47b", "Ghost" }, // 1f47b
            { "\U0001f47d", "Alien" }, // 1f47d
            { "\U0001f47e", "Alien Monster" }, // 1f47e
            { "\U0001f916", "Robot Face" }, // 1f916
            { "\U0001f4a9", "Pile of Poo" }, // 1f4a9
            { "\U0001f63a", "Smiling Cat Face With Open Mouth" }, // 1f63a
            { "\U0001f638", "Grinning Cat Face With Smiling Eyes" }, // 1f638
            { "\U0001f639", "Cat Face With Tears of Joy" }, // 1f639
            { "\U0001f63b", "Smiling Cat Face With Heart-Eyes" }, // 1f63b
            { "\U0001f63c", "Cat Face With Wry Smile" }, // 1f63c
            { "\U0001f63d", "Kissing Cat Face With Closed Eyes" }, // 1f63d
            { "\U0001f640", "Weary Cat Face" }, // 1f640
            { "\U0001f63f", "Crying Cat Face" }, // 1f63f
            { "\U0001f63e", "Pouting Cat Face" }, // 1f63e
            { "\U0001f648", "See-No-Evil Monkey" }, // 1f648
            { "\U0001f649", "Hear-No-Evil Monkey" }, // 1f649
            { "\U0001f64a", "Speak-No-Evil Monkey" }, // 1f64a
            { "\U0001f476", "Baby" }, // 1f476
            { "\U0001f476\U0001f3fb", "Baby: Light Skin Tone" }, // 1f476-1f3fb
            { "\U0001f476\U0001f3fc", "Baby: Medium-Light Skin Tone" }, // 1f476-1f3fc
            { "\U0001f476\U0001f3fd", "Baby: Medium Skin Tone" }, // 1f476-1f3fd
            { "\U0001f476\U0001f3fe", "Baby: Medium-Dark Skin Tone" }, // 1f476-1f3fe
            { "\U0001f476\U0001f3ff", "Baby: Dark Skin Tone" }, // 1f476-1f3ff
            { "\U0001f9d2", "Child" }, // 1f9d2
            { "\U0001f9d2\U0001f3fb", "Child: Light Skin Tone" }, // 1f9d2-1f3fb
            { "\U0001f9d2\U0001f3fc", "Child: Medium-Light Skin Tone" }, // 1f9d2-1f3fc
            { "\U0001f9d2\U0001f3fd", "Child: Medium Skin Tone" }, // 1f9d2-1f3fd
            { "\U0001f9d2\U0001f3fe", "Child: Medium-Dark Skin Tone" }, // 1f9d2-1f3fe
            { "\U0001f9d2\U0001f3ff", "Child: Dark Skin Tone" }, // 1f9d2-1f3ff
            { "\U0001f466", "Boy" }, // 1f466
            { "\U0001f466\U0001f3fb", "Boy: Light Skin Tone" }, // 1f466-1f3fb
            { "\U0001f466\U0001f3fc", "Boy: Medium-Light Skin Tone" }, // 1f466-1f3fc
            { "\U0001f466\U0001f3fd", "Boy: Medium Skin Tone" }, // 1f466-1f3fd
            { "\U0001f466\U0001f3fe", "Boy: Medium-Dark Skin Tone" }, // 1f466-1f3fe
            { "\U0001f466\U0001f3ff", "Boy: Dark Skin Tone" }, // 1f466-1f3ff
            { "\U0001f467", "Girl" }, // 1f467
            { "\U0001f467\U0001f3fb", "Girl: Light Skin Tone" }, // 1f467-1f3fb
            { "\U0001f467\U0001f3fc", "Girl: Medium-Light Skin Tone" }, // 1f467-1f3fc
            { "\U0001f467\U0001f3fd", "Girl: Medium Skin Tone" }, // 1f467-1f3fd
            { "\U0001f467\U0001f3fe", "Girl: Medium-Dark Skin Tone" }, // 1f467-1f3fe
            { "\U0001f467\U0001f3ff", "Girl: Dark Skin Tone" }, // 1f467-1f3ff
            { "\U0001f9d1", "Adult" }, // 1f9d1
            { "\U0001f9d1\U0001f3fb", "Adult: Light Skin Tone" }, // 1f9d1-1f3fb
            { "\U0001f9d1\U0001f3fc", "Adult: Medium-Light Skin Tone" }, // 1f9d1-1f3fc
            { "\U0001f9d1\U0001f3fd", "Adult: Medium Skin Tone" }, // 1f9d1-1f3fd
            { "\U0001f9d1\U0001f3fe", "Adult: Medium-Dark Skin Tone" }, // 1f9d1-1f3fe
            { "\U0001f9d1\U0001f3ff", "Adult: Dark Skin Tone" }, // 1f9d1-1f3ff
            { "\U0001f468", "Man" }, // 1f468
            { "\U0001f468\U0001f3fb", "Man: Light Skin Tone" }, // 1f468-1f3fb
            { "\U0001f468\U0001f3fc", "Man: Medium-Light Skin Tone" }, // 1f468-1f3fc
            { "\U0001f468\U0001f3fd", "Man: Medium Skin Tone" }, // 1f468-1f3fd
            { "\U0001f468\U0001f3fe", "Man: Medium-Dark Skin Tone" }, // 1f468-1f3fe
            { "\U0001f468\U0001f3ff", "Man: Dark Skin Tone" }, // 1f468-1f3ff
            { "\U0001f469", "Woman" }, // 1f469
            { "\U0001f469\U0001f3fb", "Woman: Light Skin Tone" }, // 1f469-1f3fb
            { "\U0001f469\U0001f3fc", "Woman: Medium-Light Skin Tone" }, // 1f469-1f3fc
            { "\U0001f469\U0001f3fd", "Woman: Medium Skin Tone" }, // 1f469-1f3fd
            { "\U0001f469\U0001f3fe", "Woman: Medium-Dark Skin Tone" }, // 1f469-1f3fe
            { "\U0001f469\U0001f3ff", "Woman: Dark Skin Tone" }, // 1f469-1f3ff
            { "\U0001f9d3", "Older Adult" }, // 1f9d3
            { "\U0001f9d3\U0001f3fb", "Older Adult: Light Skin Tone" }, // 1f9d3-1f3fb
            { "\U0001f9d3\U0001f3fc", "Older Adult: Medium-Light Skin Tone" }, // 1f9d3-1f3fc
            { "\U0001f9d3\U0001f3fd", "Older Adult: Medium Skin Tone" }, // 1f9d3-1f3fd
            { "\U0001f9d3\U0001f3fe", "Older Adult: Medium-Dark Skin Tone" }, // 1f9d3-1f3fe
            { "\U0001f9d3\U0001f3ff", "Older Adult: Dark Skin Tone" }, // 1f9d3-1f3ff
            { "\U0001f474", "Old Man" }, // 1f474
            { "\U0001f474\U0001f3fb", "Old Man: Light Skin Tone" }, // 1f474-1f3fb
            { "\U0001f474\U0001f3fc", "Old Man: Medium-Light Skin Tone" }, // 1f474-1f3fc
            { "\U0001f474\U0001f3fd", "Old Man: Medium Skin Tone" }, // 1f474-1f3fd
            { "\U0001f474\U0001f3fe", "Old Man: Medium-Dark Skin Tone" }, // 1f474-1f3fe
            { "\U0001f474\U0001f3ff", "Old Man: Dark Skin Tone" }, // 1f474-1f3ff
            { "\U0001f475", "Old Woman" }, // 1f475
            { "\U0001f475\U0001f3fb", "Old Woman: Light Skin Tone" }, // 1f475-1f3fb
            { "\U0001f475\U0001f3fc", "Old Woman: Medium-Light Skin Tone" }, // 1f475-1f3fc
            { "\U0001f475\U0001f3fd", "Old Woman: Medium Skin Tone" }, // 1f475-1f3fd
            { "\U0001f475\U0001f3fe", "Old Woman: Medium-Dark Skin Tone" }, // 1f475-1f3fe
            { "\U0001f475\U0001f3ff", "Old Woman: Dark Skin Tone" }, // 1f475-1f3ff
            { "\U0001f468\u200d\u2695\ufe0f", "Man Health Worker" }, // 1f468-200d-2695-fe0f
            { "\U0001f468\U0001f3fb\u200d\u2695\ufe0f", "Man Health Worker: Light Skin Tone" }, // 1f468-1f3fb-200d-2695-fe0f
            { "\U0001f468\U0001f3fc\u200d\u2695\ufe0f", "Man Health Worker: Medium-Light Skin Tone" }, // 1f468-1f3fc-200d-2695-fe0f
            { "\U0001f468\U0001f3fd\u200d\u2695\ufe0f", "Man Health Worker: Medium Skin Tone" }, // 1f468-1f3fd-200d-2695-fe0f
            { "\U0001f468\U0001f3fe\u200d\u2695\ufe0f", "Man Health Worker: Medium-Dark Skin Tone" }, // 1f468-1f3fe-200d-2695-fe0f
            { "\U0001f468\U0001f3ff\u200d\u2695\ufe0f", "Man Health Worker: Dark Skin Tone" }, // 1f468-1f3ff-200d-2695-fe0f
            { "\U0001f469\u200d\u2695\ufe0f", "Woman Health Worker" }, // 1f469-200d-2695-fe0f
            { "\U0001f469\U0001f3fb\u200d\u2695\ufe0f", "Woman Health Worker: Light Skin Tone" }, // 1f469-1f3fb-200d-2695-fe0f
            { "\U0001f469\U0001f3fc\u200d\u2695\ufe0f", "Woman Health Worker: Medium-Light Skin Tone" }, // 1f469-1f3fc-200d-2695-fe0f
            { "\U0001f469\U0001f3fd\u200d\u2695\ufe0f", "Woman Health Worker: Medium Skin Tone" }, // 1f469-1f3fd-200d-2695-fe0f
            { "\U0001f469\U0001f3fe\u200d\u2695\ufe0f", "Woman Health Worker: Medium-Dark Skin Tone" }, // 1f469-1f3fe-200d-2695-fe0f
            { "\U0001f469\U0001f3ff\u200d\u2695\ufe0f", "Woman Health Worker: Dark Skin Tone" }, // 1f469-1f3ff-200d-2695-fe0f
            { "\U0001f468\u200d\U0001f393", "Man Student" }, // 1f468-200d-1f393
            { "\U0001f468\U0001f3fb\u200d\U0001f393", "Man Student: Light Skin Tone" }, // 1f468-1f3fb-200d-1f393
            { "\U0001f468\U0001f3fc\u200d\U0001f393", "Man Student: Medium-Light Skin Tone" }, // 1f468-1f3fc-200d-1f393
            { "\U0001f468\U0001f3fd\u200d\U0001f393", "Man Student: Medium Skin Tone" }, // 1f468-1f3fd-200d-1f393
            { "\U0001f468\U0001f3fe\u200d\U0001f393", "Man Student: Medium-Dark Skin Tone" }, // 1f468-1f3fe-200d-1f393
            { "\U0001f468\U0001f3ff\u200d\U0001f393", "Man Student: Dark Skin Tone" }, // 1f468-1f3ff-200d-1f393
            { "\U0001f469\u200d\U0001f393", "Woman Student" }, // 1f469-200d-1f393
            { "\U0001f469\U0001f3fb\u200d\U0001f393", "Woman Student: Light Skin Tone" }, // 1f469-1f3fb-200d-1f393
            { "\U0001f469\U0001f3fc\u200d\U0001f393", "Woman Student: Medium-Light Skin Tone" }, // 1f469-1f3fc-200d-1f393
            { "\U0001f469\U0001f3fd\u200d\U0001f393", "Woman Student: Medium Skin Tone" }, // 1f469-1f3fd-200d-1f393
            { "\U0001f469\U0001f3fe\u200d\U0001f393", "Woman Student: Medium-Dark Skin Tone" }, // 1f469-1f3fe-200d-1f393
            { "\U0001f469\U0001f3ff\u200d\U0001f393", "Woman Student: Dark Skin Tone" }, // 1f469-1f3ff-200d-1f393
            { "\U0001f468\u200d\U0001f3eb", "Man Teacher" }, // 1f468-200d-1f3eb
            { "\U0001f468\U0001f3fb\u200d\U0001f3eb", "Man Teacher: Light Skin Tone" }, // 1f468-1f3fb-200d-1f3eb
            { "\U0001f468\U0001f3fc\u200d\U0001f3eb", "Man Teacher: Medium-Light Skin Tone" }, // 1f468-1f3fc-200d-1f3eb
            { "\U0001f468\U0001f3fd\u200d\U0001f3eb", "Man Teacher: Medium Skin Tone" }, // 1f468-1f3fd-200d-1f3eb
            { "\U0001f468\U0001f3fe\u200d\U0001f3eb", "Man Teacher: Medium-Dark Skin Tone" }, // 1f468-1f3fe-200d-1f3eb
            { "\U0001f468\U0001f3ff\u200d\U0001f3eb", "Man Teacher: Dark Skin Tone" }, // 1f468-1f3ff-200d-1f3eb
            { "\U0001f469\u200d\U0001f3eb", "Woman Teacher" }, // 1f469-200d-1f3eb
            { "\U0001f469\U0001f3fb\u200d\U0001f3eb", "Woman Teacher: Light Skin Tone" }, // 1f469-1f3fb-200d-1f3eb
            { "\U0001f469\U0001f3fc\u200d\U0001f3eb", "Woman Teacher: Medium-Light Skin Tone" }, // 1f469-1f3fc-200d-1f3eb
            { "\U0001f469\U0001f3fd\u200d\U0001f3eb", "Woman Teacher: Medium Skin Tone" }, // 1f469-1f3fd-200d-1f3eb
            { "\U0001f469\U0001f3fe\u200d\U0001f3eb", "Woman Teacher: Medium-Dark Skin Tone" }, // 1f469-1f3fe-200d-1f3eb
            { "\U0001f469\U0001f3ff\u200d\U0001f3eb", "Woman Teacher: Dark Skin Tone" }, // 1f469-1f3ff-200d-1f3eb
            { "\U0001f468\u200d\u2696\ufe0f", "Man Judge" }, // 1f468-200d-2696-fe0f
            { "\U0001f468\U0001f3fb\u200d\u2696\ufe0f", "Man Judge: Light Skin Tone" }, // 1f468-1f3fb-200d-2696-fe0f
            { "\U0001f468\U0001f3fc\u200d\u2696\ufe0f", "Man Judge: Medium-Light Skin Tone" }, // 1f468-1f3fc-200d-2696-fe0f
            { "\U0001f468\U0001f3fd\u200d\u2696\ufe0f", "Man Judge: Medium Skin Tone" }, // 1f468-1f3fd-200d-2696-fe0f
            { "\U0001f468\U0001f3fe\u200d\u2696\ufe0f", "Man Judge: Medium-Dark Skin Tone" }, // 1f468-1f3fe-200d-2696-fe0f
            { "\U0001f468\U0001f3ff\u200d\u2696\ufe0f", "Man Judge: Dark Skin Tone" }, // 1f468-1f3ff-200d-2696-fe0f
            { "\U0001f469\u200d\u2696\ufe0f", "Woman Judge" }, // 1f469-200d-2696-fe0f
            { "\U0001f469\U0001f3fb\u200d\u2696\ufe0f", "Woman Judge: Light Skin Tone" }, // 1f469-1f3fb-200d-2696-fe0f
            { "\U0001f469\U0001f3fc\u200d\u2696\ufe0f", "Woman Judge: Medium-Light Skin Tone" }, // 1f469-1f3fc-200d-2696-fe0f
            { "\U0001f469\U0001f3fd\u200d\u2696\ufe0f", "Woman Judge: Medium Skin Tone" }, // 1f469-1f3fd-200d-2696-fe0f
            { "\U0001f469\U0001f3fe\u200d\u2696\ufe0f", "Woman Judge: Medium-Dark Skin Tone" }, // 1f469-1f3fe-200d-2696-fe0f
            { "\U0001f469\U0001f3ff\u200d\u2696\ufe0f", "Woman Judge: Dark Skin Tone" }, // 1f469-1f3ff-200d-2696-fe0f
            { "\U0001f468\u200d\U0001f33e", "Man Farmer" }, // 1f468-200d-1f33e
            { "\U0001f468\U0001f3fb\u200d\U0001f33e", "Man Farmer: Light Skin Tone" }, // 1f468-1f3fb-200d-1f33e
            { "\U0001f468\U0001f3fc\u200d\U0001f33e", "Man Farmer: Medium-Light Skin Tone" }, // 1f468-1f3fc-200d-1f33e
            { "\U0001f468\U0001f3fd\u200d\U0001f33e", "Man Farmer: Medium Skin Tone" }, // 1f468-1f3fd-200d-1f33e
            { "\U0001f468\U0001f3fe\u200d\U0001f33e", "Man Farmer: Medium-Dark Skin Tone" }, // 1f468-1f3fe-200d-1f33e
            { "\U0001f468\U0001f3ff\u200d\U0001f33e", "Man Farmer: Dark Skin Tone" }, // 1f468-1f3ff-200d-1f33e
            { "\U0001f469\u200d\U0001f33e", "Woman Farmer" }, // 1f469-200d-1f33e
            { "\U0001f469\U0001f3fb\u200d\U0001f33e", "Woman Farmer: Light Skin Tone" }, // 1f469-1f3fb-200d-1f33e
            { "\U0001f469\U0001f3fc\u200d\U0001f33e", "Woman Farmer: Medium-Light Skin Tone" }, // 1f469-1f3fc-200d-1f33e
            { "\U0001f469\U0001f3fd\u200d\U0001f33e", "Woman Farmer: Medium Skin Tone" }, // 1f469-1f3fd-200d-1f33e
            { "\U0001f469\U0001f3fe\u200d\U0001f33e", "Woman Farmer: Medium-Dark Skin Tone" }, // 1f469-1f3fe-200d-1f33e
            { "\U0001f469\U0001f3ff\u200d\U0001f33e", "Woman Farmer: Dark Skin Tone" }, // 1f469-1f3ff-200d-1f33e
            { "\U0001f468\u200d\U0001f373", "Man Cook" }, // 1f468-200d-1f373
            { "\U0001f468\U0001f3fb\u200d\U0001f373", "Man Cook: Light Skin Tone" }, // 1f468-1f3fb-200d-1f373
            { "\U0001f468\U0001f3fc\u200d\U0001f373", "Man Cook: Medium-Light Skin Tone" }, // 1f468-1f3fc-200d-1f373
            { "\U0001f468\U0001f3fd\u200d\U0001f373", "Man Cook: Medium Skin Tone" }, // 1f468-1f3fd-200d-1f373
            { "\U0001f468\U0001f3fe\u200d\U0001f373", "Man Cook: Medium-Dark Skin Tone" }, // 1f468-1f3fe-200d-1f373
            { "\U0001f468\U0001f3ff\u200d\U0001f373", "Man Cook: Dark Skin Tone" }, // 1f468-1f3ff-200d-1f373
            { "\U0001f469\u200d\U0001f373", "Woman Cook" }, // 1f469-200d-1f373
            { "\U0001f469\U0001f3fb\u200d\U0001f373", "Woman Cook: Light Skin Tone" }, // 1f469-1f3fb-200d-1f373
            { "\U0001f469\U0001f3fc\u200d\U0001f373", "Woman Cook: Medium-Light Skin Tone" }, // 1f469-1f3fc-200d-1f373
            { "\U0001f469\U0001f3fd\u200d\U0001f373", "Woman Cook: Medium Skin Tone" }, // 1f469-1f3fd-200d-1f373
            { "\U0001f469\U0001f3fe\u200d\U0001f373", "Woman Cook: Medium-Dark Skin Tone" }, // 1f469-1f3fe-200d-1f373
            { "\U0001f469\U0001f3ff\u200d\U0001f373", "Woman Cook: Dark Skin Tone" }, // 1f469-1f3ff-200d-1f373
            { "\U0001f468\u200d\U0001f527", "Man Mechanic" }, // 1f468-200d-1f527
            { "\U0001f468\U0001f3fb\u200d\U0001f527", "Man Mechanic: Light Skin Tone" }, // 1f468-1f3fb-200d-1f527
            { "\U0001f468\U0001f3fc\u200d\U0001f527", "Man Mechanic: Medium-Light Skin Tone" }, // 1f468-1f3fc-200d-1f527
            { "\U0001f468\U0001f3fd\u200d\U0001f527", "Man Mechanic: Medium Skin Tone" }, // 1f468-1f3fd-200d-1f527
            { "\U0001f468\U0001f3fe\u200d\U0001f527", "Man Mechanic: Medium-Dark Skin Tone" }, // 1f468-1f3fe-200d-1f527
            { "\U0001f468\U0001f3ff\u200d\U0001f527", "Man Mechanic: Dark Skin Tone" }, // 1f468-1f3ff-200d-1f527
            { "\U0001f469\u200d\U0001f527", "Woman Mechanic" }, // 1f469-200d-1f527
            { "\U0001f469\U0001f3fb\u200d\U0001f527", "Woman Mechanic: Light Skin Tone" }, // 1f469-1f3fb-200d-1f527
            { "\U0001f469\U0001f3fc\u200d\U0001f527", "Woman Mechanic: Medium-Light Skin Tone" }, // 1f469-1f3fc-200d-1f527
            { "\U0001f469\U0001f3fd\u200d\U0001f527", "Woman Mechanic: Medium Skin Tone" }, // 1f469-1f3fd-200d-1f527
            { "\U0001f469\U0001f3fe\u200d\U0001f527", "Woman Mechanic: Medium-Dark Skin Tone" }, // 1f469-1f3fe-200d-1f527
            { "\U0001f469\U0001f3ff\u200d\U0001f527", "Woman Mechanic: Dark Skin Tone" }, // 1f469-1f3ff-200d-1f527
            { "\U0001f468\u200d\U0001f3ed", "Man Factory Worker" }, // 1f468-200d-1f3ed
            { "\U0001f468\U0001f3fb\u200d\U0001f3ed", "Man Factory Worker: Light Skin Tone" }, // 1f468-1f3fb-200d-1f3ed
            { "\U0001f468\U0001f3fc\u200d\U0001f3ed", "Man Factory Worker: Medium-Light Skin Tone" }, // 1f468-1f3fc-200d-1f3ed
            { "\U0001f468\U0001f3fd\u200d\U0001f3ed", "Man Factory Worker: Medium Skin Tone" }, // 1f468-1f3fd-200d-1f3ed
            { "\U0001f468\U0001f3fe\u200d\U0001f3ed", "Man Factory Worker: Medium-Dark Skin Tone" }, // 1f468-1f3fe-200d-1f3ed
            { "\U0001f468\U0001f3ff\u200d\U0001f3ed", "Man Factory Worker: Dark Skin Tone" }, // 1f468-1f3ff-200d-1f3ed
            { "\U0001f469\u200d\U0001f3ed", "Woman Factory Worker" }, // 1f469-200d-1f3ed
            { "\U0001f469\U0001f3fb\u200d\U0001f3ed", "Woman Factory Worker: Light Skin Tone" }, // 1f469-1f3fb-200d-1f3ed
            { "\U0001f469\U0001f3fc\u200d\U0001f3ed", "Woman Factory Worker: Medium-Light Skin Tone" }, // 1f469-1f3fc-200d-1f3ed
            { "\U0001f469\U0001f3fd\u200d\U0001f3ed", "Woman Factory Worker: Medium Skin Tone" }, // 1f469-1f3fd-200d-1f3ed
            { "\U0001f469\U0001f3fe\u200d\U0001f3ed", "Woman Factory Worker: Medium-Dark Skin Tone" }, // 1f469-1f3fe-200d-1f3ed
            { "\U0001f469\U0001f3ff\u200d\U0001f3ed", "Woman Factory Worker: Dark Skin Tone" }, // 1f469-1f3ff-200d-1f3ed
            { "\U0001f468\u200d\U0001f4bc", "Man Office Worker" }, // 1f468-200d-1f4bc
            { "\U0001f468\U0001f3fb\u200d\U0001f4bc", "Man Office Worker: Light Skin Tone" }, // 1f468-1f3fb-200d-1f4bc
            { "\U0001f468\U0001f3fc\u200d\U0001f4bc", "Man Office Worker: Medium-Light Skin Tone" }, // 1f468-1f3fc-200d-1f4bc
            { "\U0001f468\U0001f3fd\u200d\U0001f4bc", "Man Office Worker: Medium Skin Tone" }, // 1f468-1f3fd-200d-1f4bc
            { "\U0001f468\U0001f3fe\u200d\U0001f4bc", "Man Office Worker: Medium-Dark Skin Tone" }, // 1f468-1f3fe-200d-1f4bc
            { "\U0001f468\U0001f3ff\u200d\U0001f4bc", "Man Office Worker: Dark Skin Tone" }, // 1f468-1f3ff-200d-1f4bc
            { "\U0001f469\u200d\U0001f4bc", "Woman Office Worker" }, // 1f469-200d-1f4bc
            { "\U0001f469\U0001f3fb\u200d\U0001f4bc", "Woman Office Worker: Light Skin Tone" }, // 1f469-1f3fb-200d-1f4bc
            { "\U0001f469\U0001f3fc\u200d\U0001f4bc", "Woman Office Worker: Medium-Light Skin Tone" }, // 1f469-1f3fc-200d-1f4bc
            { "\U0001f469\U0001f3fd\u200d\U0001f4bc", "Woman Office Worker: Medium Skin Tone" }, // 1f469-1f3fd-200d-1f4bc
            { "\U0001f469\U0001f3fe\u200d\U0001f4bc", "Woman Office Worker: Medium-Dark Skin Tone" }, // 1f469-1f3fe-200d-1f4bc
            { "\U0001f469\U0001f3ff\u200d\U0001f4bc", "Woman Office Worker: Dark Skin Tone" }, // 1f469-1f3ff-200d-1f4bc
            { "\U0001f468\u200d\U0001f52c", "Man Scientist" }, // 1f468-200d-1f52c
            { "\U0001f468\U0001f3fb\u200d\U0001f52c", "Man Scientist: Light Skin Tone" }, // 1f468-1f3fb-200d-1f52c
            { "\U0001f468\U0001f3fc\u200d\U0001f52c", "Man Scientist: Medium-Light Skin Tone" }, // 1f468-1f3fc-200d-1f52c
            { "\U0001f468\U0001f3fd\u200d\U0001f52c", "Man Scientist: Medium Skin Tone" }, // 1f468-1f3fd-200d-1f52c
            { "\U0001f468\U0001f3fe\u200d\U0001f52c", "Man Scientist: Medium-Dark Skin Tone" }, // 1f468-1f3fe-200d-1f52c
            { "\U0001f468\U0001f3ff\u200d\U0001f52c", "Man Scientist: Dark Skin Tone" }, // 1f468-1f3ff-200d-1f52c
            { "\U0001f469\u200d\U0001f52c", "Woman Scientist" }, // 1f469-200d-1f52c
            { "\U0001f469\U0001f3fb\u200d\U0001f52c", "Woman Scientist: Light Skin Tone" }, // 1f469-1f3fb-200d-1f52c
            { "\U0001f469\U0001f3fc\u200d\U0001f52c", "Woman Scientist: Medium-Light Skin Tone" }, // 1f469-1f3fc-200d-1f52c
            { "\U0001f469\U0001f3fd\u200d\U0001f52c", "Woman Scientist: Medium Skin Tone" }, // 1f469-1f3fd-200d-1f52c
            { "\U0001f469\U0001f3fe\u200d\U0001f52c", "Woman Scientist: Medium-Dark Skin Tone" }, // 1f469-1f3fe-200d-1f52c
            { "\U0001f469\U0001f3ff\u200d\U0001f52c", "Woman Scientist: Dark Skin Tone" }, // 1f469-1f3ff-200d-1f52c
            { "\U0001f468\u200d\U0001f4bb", "Man Technologist" }, // 1f468-200d-1f4bb
            { "\U0001f468\U0001f3fb\u200d\U0001f4bb", "Man Technologist: Light Skin Tone" }, // 1f468-1f3fb-200d-1f4bb
            { "\U0001f468\U0001f3fc\u200d\U0001f4bb", "Man Technologist: Medium-Light Skin Tone" }, // 1f468-1f3fc-200d-1f4bb
            { "\U0001f468\U0001f3fd\u200d\U0001f4bb", "Man Technologist: Medium Skin Tone" }, // 1f468-1f3fd-200d-1f4bb
            { "\U0001f468\U0001f3fe\u200d\U0001f4bb", "Man Technologist: Medium-Dark Skin Tone" }, // 1f468-1f3fe-200d-1f4bb
            { "\U0001f468\U0001f3ff\u200d\U0001f4bb", "Man Technologist: Dark Skin Tone" }, // 1f468-1f3ff-200d-1f4bb
            { "\U0001f469\u200d\U0001f4bb", "Woman Technologist" }, // 1f469-200d-1f4bb
            { "\U0001f469\U0001f3fb\u200d\U0001f4bb", "Woman Technologist: Light Skin Tone" }, // 1f469-1f3fb-200d-1f4bb
            { "\U0001f469\U0001f3fc\u200d\U0001f4bb", "Woman Technologist: Medium-Light Skin Tone" }, // 1f469-1f3fc-200d-1f4bb
            { "\U0001f469\U0001f3fd\u200d\U0001f4bb", "Woman Technologist: Medium Skin Tone" }, // 1f469-1f3fd-200d-1f4bb
            { "\U0001f469\U0001f3fe\u200d\U0001f4bb", "Woman Technologist: Medium-Dark Skin Tone" }, // 1f469-1f3fe-200d-1f4bb
            { "\U0001f469\U0001f3ff\u200d\U0001f4bb", "Woman Technologist: Dark Skin Tone" }, // 1f469-1f3ff-200d-1f4bb
            { "\U0001f468\u200d\U0001f3a4", "Man Singer" }, // 1f468-200d-1f3a4
            { "\U0001f468\U0001f3fb\u200d\U0001f3a4", "Man Singer: Light Skin Tone" }, // 1f468-1f3fb-200d-1f3a4
            { "\U0001f468\U0001f3fc\u200d\U0001f3a4", "Man Singer: Medium-Light Skin Tone" }, // 1f468-1f3fc-200d-1f3a4
            { "\U0001f468\U0001f3fd\u200d\U0001f3a4", "Man Singer: Medium Skin Tone" }, // 1f468-1f3fd-200d-1f3a4
            { "\U0001f468\U0001f3fe\u200d\U0001f3a4", "Man Singer: Medium-Dark Skin Tone" }, // 1f468-1f3fe-200d-1f3a4
            { "\U0001f468\U0001f3ff\u200d\U0001f3a4", "Man Singer: Dark Skin Tone" }, // 1f468-1f3ff-200d-1f3a4
            { "\U0001f469\u200d\U0001f3a4", "Woman Singer" }, // 1f469-200d-1f3a4
            { "\U0001f469\U0001f3fb\u200d\U0001f3a4", "Woman Singer: Light Skin Tone" }, // 1f469-1f3fb-200d-1f3a4
            { "\U0001f469\U0001f3fc\u200d\U0001f3a4", "Woman Singer: Medium-Light Skin Tone" }, // 1f469-1f3fc-200d-1f3a4
            { "\U0001f469\U0001f3fd\u200d\U0001f3a4", "Woman Singer: Medium Skin Tone" }, // 1f469-1f3fd-200d-1f3a4
            { "\U0001f469\U0001f3fe\u200d\U0001f3a4", "Woman Singer: Medium-Dark Skin Tone" }, // 1f469-1f3fe-200d-1f3a4
            { "\U0001f469\U0001f3ff\u200d\U0001f3a4", "Woman Singer: Dark Skin Tone" }, // 1f469-1f3ff-200d-1f3a4
            { "\U0001f468\u200d\U0001f3a8", "Man Artist" }, // 1f468-200d-1f3a8
            { "\U0001f468\U0001f3fb\u200d\U0001f3a8", "Man Artist: Light Skin Tone" }, // 1f468-1f3fb-200d-1f3a8
            { "\U0001f468\U0001f3fc\u200d\U0001f3a8", "Man Artist: Medium-Light Skin Tone" }, // 1f468-1f3fc-200d-1f3a8
            { "\U0001f468\U0001f3fd\u200d\U0001f3a8", "Man Artist: Medium Skin Tone" }, // 1f468-1f3fd-200d-1f3a8
            { "\U0001f468\U0001f3fe\u200d\U0001f3a8", "Man Artist: Medium-Dark Skin Tone" }, // 1f468-1f3fe-200d-1f3a8
            { "\U0001f468\U0001f3ff\u200d\U0001f3a8", "Man Artist: Dark Skin Tone" }, // 1f468-1f3ff-200d-1f3a8
            { "\U0001f469\u200d\U0001f3a8", "Woman Artist" }, // 1f469-200d-1f3a8
            { "\U0001f469\U0001f3fb\u200d\U0001f3a8", "Woman Artist: Light Skin Tone" }, // 1f469-1f3fb-200d-1f3a8
            { "\U0001f469\U0001f3fc\u200d\U0001f3a8", "Woman Artist: Medium-Light Skin Tone" }, // 1f469-1f3fc-200d-1f3a8
            { "\U0001f469\U0001f3fd\u200d\U0001f3a8", "Woman Artist: Medium Skin Tone" }, // 1f469-1f3fd-200d-1f3a8
            { "\U0001f469\U0001f3fe\u200d\U0001f3a8", "Woman Artist: Medium-Dark Skin Tone" }, // 1f469-1f3fe-200d-1f3a8
            { "\U0001f469\U0001f3ff\u200d\U0001f3a8", "Woman Artist: Dark Skin Tone" }, // 1f469-1f3ff-200d-1f3a8
            { "\U0001f468\u200d\u2708\ufe0f", "Man Pilot" }, // 1f468-200d-2708-fe0f
            { "\U0001f468\U0001f3fb\u200d\u2708\ufe0f", "Man Pilot: Light Skin Tone" }, // 1f468-1f3fb-200d-2708-fe0f
            { "\U0001f468\U0001f3fc\u200d\u2708\ufe0f", "Man Pilot: Medium-Light Skin Tone" }, // 1f468-1f3fc-200d-2708-fe0f
            { "\U0001f468\U0001f3fd\u200d\u2708\ufe0f", "Man Pilot: Medium Skin Tone" }, // 1f468-1f3fd-200d-2708-fe0f
            { "\U0001f468\U0001f3fe\u200d\u2708\ufe0f", "Man Pilot: Medium-Dark Skin Tone" }, // 1f468-1f3fe-200d-2708-fe0f
            { "\U0001f468\U0001f3ff\u200d\u2708\ufe0f", "Man Pilot: Dark Skin Tone" }, // 1f468-1f3ff-200d-2708-fe0f
            { "\U0001f469\u200d\u2708\ufe0f", "Woman Pilot" }, // 1f469-200d-2708-fe0f
            { "\U0001f469\U0001f3fb\u200d\u2708\ufe0f", "Woman Pilot: Light Skin Tone" }, // 1f469-1f3fb-200d-2708-fe0f
            { "\U0001f469\U0001f3fc\u200d\u2708\ufe0f", "Woman Pilot: Medium-Light Skin Tone" }, // 1f469-1f3fc-200d-2708-fe0f
            { "\U0001f469\U0001f3fd\u200d\u2708\ufe0f", "Woman Pilot: Medium Skin Tone" }, // 1f469-1f3fd-200d-2708-fe0f
            { "\U0001f469\U0001f3fe\u200d\u2708\ufe0f", "Woman Pilot: Medium-Dark Skin Tone" }, // 1f469-1f3fe-200d-2708-fe0f
            { "\U0001f469\U0001f3ff\u200d\u2708\ufe0f", "Woman Pilot: Dark Skin Tone" }, // 1f469-1f3ff-200d-2708-fe0f
            { "\U0001f468\u200d\U0001f680", "Man Astronaut" }, // 1f468-200d-1f680
            { "\U0001f468\U0001f3fb\u200d\U0001f680", "Man Astronaut: Light Skin Tone" }, // 1f468-1f3fb-200d-1f680
            { "\U0001f468\U0001f3fc\u200d\U0001f680", "Man Astronaut: Medium-Light Skin Tone" }, // 1f468-1f3fc-200d-1f680
            { "\U0001f468\U0001f3fd\u200d\U0001f680", "Man Astronaut: Medium Skin Tone" }, // 1f468-1f3fd-200d-1f680
            { "\U0001f468\U0001f3fe\u200d\U0001f680", "Man Astronaut: Medium-Dark Skin Tone" }, // 1f468-1f3fe-200d-1f680
            { "\U0001f468\U0001f3ff\u200d\U0001f680", "Man Astronaut: Dark Skin Tone" }, // 1f468-1f3ff-200d-1f680
            { "\U0001f469\u200d\U0001f680", "Woman Astronaut" }, // 1f469-200d-1f680
            { "\U0001f469\U0001f3fb\u200d\U0001f680", "Woman Astronaut: Light Skin Tone" }, // 1f469-1f3fb-200d-1f680
            { "\U0001f469\U0001f3fc\u200d\U0001f680", "Woman Astronaut: Medium-Light Skin Tone" }, // 1f469-1f3fc-200d-1f680
            { "\U0001f469\U0001f3fd\u200d\U0001f680", "Woman Astronaut: Medium Skin Tone" }, // 1f469-1f3fd-200d-1f680
            { "\U0001f469\U0001f3fe\u200d\U0001f680", "Woman Astronaut: Medium-Dark Skin Tone" }, // 1f469-1f3fe-200d-1f680
            { "\U0001f469\U0001f3ff\u200d\U0001f680", "Woman Astronaut: Dark Skin Tone" }, // 1f469-1f3ff-200d-1f680
            { "\U0001f468\u200d\U0001f692", "Man Firefighter" }, // 1f468-200d-1f692
            { "\U0001f468\U0001f3fb\u200d\U0001f692", "Man Firefighter: Light Skin Tone" }, // 1f468-1f3fb-200d-1f692
            { "\U0001f468\U0001f3fc\u200d\U0001f692", "Man Firefighter: Medium-Light Skin Tone" }, // 1f468-1f3fc-200d-1f692
            { "\U0001f468\U0001f3fd\u200d\U0001f692", "Man Firefighter: Medium Skin Tone" }, // 1f468-1f3fd-200d-1f692
            { "\U0001f468\U0001f3fe\u200d\U0001f692", "Man Firefighter: Medium-Dark Skin Tone" }, // 1f468-1f3fe-200d-1f692
            { "\U0001f468\U0001f3ff\u200d\U0001f692", "Man Firefighter: Dark Skin Tone" }, // 1f468-1f3ff-200d-1f692
            { "\U0001f469\u200d\U0001f692", "Woman Firefighter" }, // 1f469-200d-1f692
            { "\U0001f469\U0001f3fb\u200d\U0001f692", "Woman Firefighter: Light Skin Tone" }, // 1f469-1f3fb-200d-1f692
            { "\U0001f469\U0001f3fc\u200d\U0001f692", "Woman Firefighter: Medium-Light Skin Tone" }, // 1f469-1f3fc-200d-1f692
            { "\U0001f469\U0001f3fd\u200d\U0001f692", "Woman Firefighter: Medium Skin Tone" }, // 1f469-1f3fd-200d-1f692
            { "\U0001f469\U0001f3fe\u200d\U0001f692", "Woman Firefighter: Medium-Dark Skin Tone" }, // 1f469-1f3fe-200d-1f692
            { "\U0001f469\U0001f3ff\u200d\U0001f692", "Woman Firefighter: Dark Skin Tone" }, // 1f469-1f3ff-200d-1f692
            { "\U0001f46e", "Police Officer" }, // 1f46e
            { "\U0001f46e\U0001f3fb", "Police Officer: Light Skin Tone" }, // 1f46e-1f3fb
            { "\U0001f46e\U0001f3fc", "Police Officer: Medium-Light Skin Tone" }, // 1f46e-1f3fc
            { "\U0001f46e\U0001f3fd", "Police Officer: Medium Skin Tone" }, // 1f46e-1f3fd
            { "\U0001f46e\U0001f3fe", "Police Officer: Medium-Dark Skin Tone" }, // 1f46e-1f3fe
            { "\U0001f46e\U0001f3ff", "Police Officer: Dark Skin Tone" }, // 1f46e-1f3ff
            { "\U0001f46e\u200d\u2640\ufe0f", "Woman Police Officer" }, // 1f46e-200d-2640-fe0f
            { "\U0001f46e\U0001f3fb\u200d\u2640\ufe0f", "Woman Police Officer: Light Skin Tone" }, // 1f46e-1f3fb-200d-2640-fe0f
            { "\U0001f46e\U0001f3fc\u200d\u2640\ufe0f", "Woman Police Officer: Medium-Light Skin Tone" }, // 1f46e-1f3fc-200d-2640-fe0f
            { "\U0001f46e\U0001f3fd\u200d\u2640\ufe0f", "Woman Police Officer: Medium Skin Tone" }, // 1f46e-1f3fd-200d-2640-fe0f
            { "\U0001f46e\U0001f3fe\u200d\u2640\ufe0f", "Woman Police Officer: Medium-Dark Skin Tone" }, // 1f46e-1f3fe-200d-2640-fe0f
            { "\U0001f46e\U0001f3ff\u200d\u2640\ufe0f", "Woman Police Officer: Dark Skin Tone" }, // 1f46e-1f3ff-200d-2640-fe0f
            { "\U0001f575", "Detective" }, // 1f575
            { "\U0001f575\U0001f3fb", "Detective: Light Skin Tone" }, // 1f575-1f3fb
            { "\U0001f575\U0001f3fc", "Detective: Medium-Light Skin Tone" }, // 1f575-1f3fc
            { "\U0001f575\U0001f3fd", "Detective: Medium Skin Tone" }, // 1f575-1f3fd
            { "\U0001f575\U0001f3fe", "Detective: Medium-Dark Skin Tone" }, // 1f575-1f3fe
            { "\U0001f575\U0001f3ff", "Detective: Dark Skin Tone" }, // 1f575-1f3ff
            { "\U0001f575\ufe0f\u200d\u2640\ufe0f", "Woman Detective" }, // 1f575-fe0f-200d-2640-fe0f
            { "\U0001f575\U0001f3fb\u200d\u2640\ufe0f", "Woman Detective: Light Skin Tone" }, // 1f575-1f3fb-200d-2640-fe0f
            { "\U0001f575\U0001f3fc\u200d\u2640\ufe0f", "Woman Detective: Medium-Light Skin Tone" }, // 1f575-1f3fc-200d-2640-fe0f
            { "\U0001f575\U0001f3fd\u200d\u2640\ufe0f", "Woman Detective: Medium Skin Tone" }, // 1f575-1f3fd-200d-2640-fe0f
            { "\U0001f575\U0001f3fe\u200d\u2640\ufe0f", "Woman Detective: Medium-Dark Skin Tone" }, // 1f575-1f3fe-200d-2640-fe0f
            { "\U0001f575\U0001f3ff\u200d\u2640\ufe0f", "Woman Detective: Dark Skin Tone" }, // 1f575-1f3ff-200d-2640-fe0f
            { "\U0001f482", "Guard" }, // 1f482
            { "\U0001f482\U0001f3fb", "Guard: Light Skin Tone" }, // 1f482-1f3fb
            { "\U0001f482\U0001f3fc", "Guard: Medium-Light Skin Tone" }, // 1f482-1f3fc
            { "\U0001f482\U0001f3fd", "Guard: Medium Skin Tone" }, // 1f482-1f3fd
            { "\U0001f482\U0001f3fe", "Guard: Medium-Dark Skin Tone" }, // 1f482-1f3fe
            { "\U0001f482\U0001f3ff", "Guard: Dark Skin Tone" }, // 1f482-1f3ff
            { "\U0001f482\u200d\u2640\ufe0f", "Woman Guard" }, // 1f482-200d-2640-fe0f
            { "\U0001f482\U0001f3fb\u200d\u2640\ufe0f", "Woman Guard: Light Skin Tone" }, // 1f482-1f3fb-200d-2640-fe0f
            { "\U0001f482\U0001f3fc\u200d\u2640\ufe0f", "Woman Guard: Medium-Light Skin Tone" }, // 1f482-1f3fc-200d-2640-fe0f
            { "\U0001f482\U0001f3fd\u200d\u2640\ufe0f", "Woman Guard: Medium Skin Tone" }, // 1f482-1f3fd-200d-2640-fe0f
            { "\U0001f482\U0001f3fe\u200d\u2640\ufe0f", "Woman Guard: Medium-Dark Skin Tone" }, // 1f482-1f3fe-200d-2640-fe0f
            { "\U0001f482\U0001f3ff\u200d\u2640\ufe0f", "Woman Guard: Dark Skin Tone" }, // 1f482-1f3ff-200d-2640-fe0f
            { "\U0001f477", "Construction Worker" }, // 1f477
            { "\U0001f477\U0001f3fb", "Construction Worker: Light Skin Tone" }, // 1f477-1f3fb
            { "\U0001f477\U0001f3fc", "Construction Worker: Medium-Light Skin Tone" }, // 1f477-1f3fc
            { "\U0001f477\U0001f3fd", "Construction Worker: Medium Skin Tone" }, // 1f477-1f3fd
            { "\U0001f477\U0001f3fe", "Construction Worker: Medium-Dark Skin Tone" }, // 1f477-1f3fe
            { "\U0001f477\U0001f3ff", "Construction Worker: Dark Skin Tone" }, // 1f477-1f3ff
            { "\U0001f477\u200d\u2640\ufe0f", "Woman Construction Worker" }, // 1f477-200d-2640-fe0f
            { "\U0001f477\U0001f3fb\u200d\u2640\ufe0f", "Woman Construction Worker: Light Skin Tone" }, // 1f477-1f3fb-200d-2640-fe0f
            { "\U0001f477\U0001f3fc\u200d\u2640\ufe0f", "Woman Construction Worker: Medium-Light Skin Tone" }, // 1f477-1f3fc-200d-2640-fe0f
            { "\U0001f477\U0001f3fd\u200d\u2640\ufe0f", "Woman Construction Worker: Medium Skin Tone" }, // 1f477-1f3fd-200d-2640-fe0f
            { "\U0001f477\U0001f3fe\u200d\u2640\ufe0f", "Woman Construction Worker: Medium-Dark Skin Tone" }, // 1f477-1f3fe-200d-2640-fe0f
            { "\U0001f477\U0001f3ff\u200d\u2640\ufe0f", "Woman Construction Worker: Dark Skin Tone" }, // 1f477-1f3ff-200d-2640-fe0f
            { "\U0001f934", "Prince" }, // 1f934
            { "\U0001f934\U0001f3fb", "Prince: Light Skin Tone" }, // 1f934-1f3fb
            { "\U0001f934\U0001f3fc", "Prince: Medium-Light Skin Tone" }, // 1f934-1f3fc
            { "\U0001f934\U0001f3fd", "Prince: Medium Skin Tone" }, // 1f934-1f3fd
            { "\U0001f934\U0001f3fe", "Prince: Medium-Dark Skin Tone" }, // 1f934-1f3fe
            { "\U0001f934\U0001f3ff", "Prince: Dark Skin Tone" }, // 1f934-1f3ff
            { "\U0001f478", "Princess" }, // 1f478
            { "\U0001f478\U0001f3fb", "Princess: Light Skin Tone" }, // 1f478-1f3fb
            { "\U0001f478\U0001f3fc", "Princess: Medium-Light Skin Tone" }, // 1f478-1f3fc
            { "\U0001f478\U0001f3fd", "Princess: Medium Skin Tone" }, // 1f478-1f3fd
            { "\U0001f478\U0001f3fe", "Princess: Medium-Dark Skin Tone" }, // 1f478-1f3fe
            { "\U0001f478\U0001f3ff", "Princess: Dark Skin Tone" }, // 1f478-1f3ff
            { "\U0001f473", "Person Wearing Turban" }, // 1f473
            { "\U0001f473\U0001f3fb", "Person Wearing Turban: Light Skin Tone" }, // 1f473-1f3fb
            { "\U0001f473\U0001f3fc", "Person Wearing Turban: Medium-Light Skin Tone" }, // 1f473-1f3fc
            { "\U0001f473\U0001f3fd", "Person Wearing Turban: Medium Skin Tone" }, // 1f473-1f3fd
            { "\U0001f473\U0001f3fe", "Person Wearing Turban: Medium-Dark Skin Tone" }, // 1f473-1f3fe
            { "\U0001f473\U0001f3ff", "Person Wearing Turban: Dark Skin Tone" }, // 1f473-1f3ff
            { "\U0001f473\u200d\u2642\ufe0f", "Man Wearing Turban" }, // 1f473-200d-2642-fe0f
            { "\U0001f473\U0001f3fb\u200d\u2642\ufe0f", "Man Wearing Turban: Light Skin Tone" }, // 1f473-1f3fb-200d-2642-fe0f
            { "\U0001f473\U0001f3fc\u200d\u2642\ufe0f", "Man Wearing Turban: Medium-Light Skin Tone" }, // 1f473-1f3fc-200d-2642-fe0f
            { "\U0001f473\U0001f3fd\u200d\u2642\ufe0f", "Man Wearing Turban: Medium Skin Tone" }, // 1f473-1f3fd-200d-2642-fe0f
            { "\U0001f473\U0001f3fe\u200d\u2642\ufe0f", "Man Wearing Turban: Medium-Dark Skin Tone" }, // 1f473-1f3fe-200d-2642-fe0f
            { "\U0001f473\U0001f3ff\u200d\u2642\ufe0f", "Man Wearing Turban: Dark Skin Tone" }, // 1f473-1f3ff-200d-2642-fe0f
            { "\U0001f473\u200d\u2640\ufe0f", "Woman Wearing Turban" }, // 1f473-200d-2640-fe0f
            { "\U0001f473\U0001f3fb\u200d\u2640\ufe0f", "Woman Wearing Turban: Light Skin Tone" }, // 1f473-1f3fb-200d-2640-fe0f
            { "\U0001f473\U0001f3fc\u200d\u2640\ufe0f", "Woman Wearing Turban: Medium-Light Skin Tone" }, // 1f473-1f3fc-200d-2640-fe0f
            { "\U0001f473\U0001f3fd\u200d\u2640\ufe0f", "Woman Wearing Turban: Medium Skin Tone" }, // 1f473-1f3fd-200d-2640-fe0f
            { "\U0001f473\U0001f3fe\u200d\u2640\ufe0f", "Woman Wearing Turban: Medium-Dark Skin Tone" }, // 1f473-1f3fe-200d-2640-fe0f
            { "\U0001f473\U0001f3ff\u200d\u2640\ufe0f", "Woman Wearing Turban: Dark Skin Tone" }, // 1f473-1f3ff-200d-2640-fe0f
            { "\U0001f472", "Man With Chinese Cap" }, // 1f472
            { "\U0001f472\U0001f3fb", "Man With Chinese Cap: Light Skin Tone" }, // 1f472-1f3fb
            { "\U0001f472\U0001f3fc", "Man With Chinese Cap: Medium-Light Skin Tone" }, // 1f472-1f3fc
            { "\U0001f472\U0001f3fd", "Man With Chinese Cap: Medium Skin Tone" }, // 1f472-1f3fd
            { "\U0001f472\U0001f3fe", "Man With Chinese Cap: Medium-Dark Skin Tone" }, // 1f472-1f3fe
            { "\U0001f472\U0001f3ff", "Man With Chinese Cap: Dark Skin Tone" }, // 1f472-1f3ff
            { "\U0001f9d5", "Woman With Headscarf" }, // 1f9d5
            { "\U0001f9d5\U0001f3fb", "Person With Headscarf: Light Skin Tone" }, // 1f9d5-1f3fb
            { "\U0001f9d5\U0001f3fc", "Person With Headscarf: Medium-Light Skin Tone" }, // 1f9d5-1f3fc
            { "\U0001f9d5\U0001f3fd", "Person With Headscarf: Medium Skin Tone" }, // 1f9d5-1f3fd
            { "\U0001f9d5\U0001f3fe", "Person With Headscarf: Medium-Dark Skin Tone" }, // 1f9d5-1f3fe
            { "\U0001f9d5\U0001f3ff", "Person With Headscarf: Dark Skin Tone" }, // 1f9d5-1f3ff
            { "\U0001f9d4", "Bearded Person" }, // 1f9d4
            { "\U0001f9d4\U0001f3fb", "Bearded Person: Light Skin Tone" }, // 1f9d4-1f3fb
            { "\U0001f9d4\U0001f3fc", "Bearded Person: Medium-Light Skin Tone" }, // 1f9d4-1f3fc
            { "\U0001f9d4\U0001f3fd", "Bearded Person: Medium Skin Tone" }, // 1f9d4-1f3fd
            { "\U0001f9d4\U0001f3fe", "Bearded Person: Medium-Dark Skin Tone" }, // 1f9d4-1f3fe
            { "\U0001f9d4\U0001f3ff", "Bearded Person: Dark Skin Tone" }, // 1f9d4-1f3ff
            { "\U0001f471", "Blond-Haired Person" }, // 1f471
            { "\U0001f471\U0001f3fb", "Blond-Haired Person: Light Skin Tone" }, // 1f471-1f3fb
            { "\U0001f471\U0001f3fc", "Blond-Haired Person: Medium-Light Skin Tone" }, // 1f471-1f3fc
            { "\U0001f471\U0001f3fd", "Blond-Haired Person: Medium Skin Tone" }, // 1f471-1f3fd
            { "\U0001f471\U0001f3fe", "Blond-Haired Person: Medium-Dark Skin Tone" }, // 1f471-1f3fe
            { "\U0001f471\U0001f3ff", "Blond-Haired Person: Dark Skin Tone" }, // 1f471-1f3ff
            { "\U0001f471\u200d\u2640\ufe0f", "Blond-Haired Woman" }, // 1f471-200d-2640-fe0f
            { "\U0001f471\U0001f3fb\u200d\u2640\ufe0f", "Blond-Haired Woman: Light Skin Tone" }, // 1f471-1f3fb-200d-2640-fe0f
            { "\U0001f471\U0001f3fc\u200d\u2640\ufe0f", "Blond-Haired Woman: Medium-Light Skin Tone" }, // 1f471-1f3fc-200d-2640-fe0f
            { "\U0001f471\U0001f3fd\u200d\u2640\ufe0f", "Blond-Haired Woman: Medium Skin Tone" }, // 1f471-1f3fd-200d-2640-fe0f
            { "\U0001f471\U0001f3fe\u200d\u2640\ufe0f", "Blond-Haired Woman: Medium-Dark Skin Tone" }, // 1f471-1f3fe-200d-2640-fe0f
            { "\U0001f471\U0001f3ff\u200d\u2640\ufe0f", "Blond-Haired Woman: Dark Skin Tone" }, // 1f471-1f3ff-200d-2640-fe0f
            { "\U0001f935", "Man in Tuxedo" }, // 1f935
            { "\U0001f935\U0001f3fb", "Man in Tuxedo: Light Skin Tone" }, // 1f935-1f3fb
            { "\U0001f935\U0001f3fc", "Man in Tuxedo: Medium-Light Skin Tone" }, // 1f935-1f3fc
            { "\U0001f935\U0001f3fd", "Man in Tuxedo: Medium Skin Tone" }, // 1f935-1f3fd
            { "\U0001f935\U0001f3fe", "Man in Tuxedo: Medium-Dark Skin Tone" }, // 1f935-1f3fe
            { "\U0001f935\U0001f3ff", "Man in Tuxedo: Dark Skin Tone" }, // 1f935-1f3ff
            { "\U0001f470", "Bride With Veil" }, // 1f470
            { "\U0001f470\U0001f3fb", "Bride With Veil: Light Skin Tone" }, // 1f470-1f3fb
            { "\U0001f470\U0001f3fc", "Bride With Veil: Medium-Light Skin Tone" }, // 1f470-1f3fc
            { "\U0001f470\U0001f3fd", "Bride With Veil: Medium Skin Tone" }, // 1f470-1f3fd
            { "\U0001f470\U0001f3fe", "Bride With Veil: Medium-Dark Skin Tone" }, // 1f470-1f3fe
            { "\U0001f470\U0001f3ff", "Bride With Veil: Dark Skin Tone" }, // 1f470-1f3ff
            { "\U0001f930", "Pregnant Woman" }, // 1f930
            { "\U0001f930\U0001f3fb", "Pregnant Woman: Light Skin Tone" }, // 1f930-1f3fb
            { "\U0001f930\U0001f3fc", "Pregnant Woman: Medium-Light Skin Tone" }, // 1f930-1f3fc
            { "\U0001f930\U0001f3fd", "Pregnant Woman: Medium Skin Tone" }, // 1f930-1f3fd
            { "\U0001f930\U0001f3fe", "Pregnant Woman: Medium-Dark Skin Tone" }, // 1f930-1f3fe
            { "\U0001f930\U0001f3ff", "Pregnant Woman: Dark Skin Tone" }, // 1f930-1f3ff
            { "\U0001f931", "Breast-Feeding" }, // 1f931
            { "\U0001f931\U0001f3fb", "Breast-Feeding: Light Skin Tone" }, // 1f931-1f3fb
            { "\U0001f931\U0001f3fc", "Breast-Feeding: Medium-Light Skin Tone" }, // 1f931-1f3fc
            { "\U0001f931\U0001f3fd", "Breast-Feeding: Medium Skin Tone" }, // 1f931-1f3fd
            { "\U0001f931\U0001f3fe", "Breast-Feeding: Medium-Dark Skin Tone" }, // 1f931-1f3fe
            { "\U0001f931\U0001f3ff", "Breast-Feeding: Dark Skin Tone" }, // 1f931-1f3ff
            { "\U0001f47c", "Baby Angel" }, // 1f47c
            { "\U0001f47c\U0001f3fb", "Baby Angel: Light Skin Tone" }, // 1f47c-1f3fb
            { "\U0001f47c\U0001f3fc", "Baby Angel: Medium-Light Skin Tone" }, // 1f47c-1f3fc
            { "\U0001f47c\U0001f3fd", "Baby Angel: Medium Skin Tone" }, // 1f47c-1f3fd
            { "\U0001f47c\U0001f3fe", "Baby Angel: Medium-Dark Skin Tone" }, // 1f47c-1f3fe
            { "\U0001f47c\U0001f3ff", "Baby Angel: Dark Skin Tone" }, // 1f47c-1f3ff
            { "\U0001f385", "Santa Claus" }, // 1f385
            { "\U0001f385\U0001f3fb", "Santa Claus: Light Skin Tone" }, // 1f385-1f3fb
            { "\U0001f385\U0001f3fc", "Santa Claus: Medium-Light Skin Tone" }, // 1f385-1f3fc
            { "\U0001f385\U0001f3fd", "Santa Claus: Medium Skin Tone" }, // 1f385-1f3fd
            { "\U0001f385\U0001f3fe", "Santa Claus: Medium-Dark Skin Tone" }, // 1f385-1f3fe
            { "\U0001f385\U0001f3ff", "Santa Claus: Dark Skin Tone" }, // 1f385-1f3ff
            { "\U0001f936", "Mrs. Claus" }, // 1f936
            { "\U0001f936\U0001f3fb", "Mrs. Claus: Light Skin Tone" }, // 1f936-1f3fb
            { "\U0001f936\U0001f3fc", "Mrs. Claus: Medium-Light Skin Tone" }, // 1f936-1f3fc
            { "\U0001f936\U0001f3fd", "Mrs. Claus: Medium Skin Tone" }, // 1f936-1f3fd
            { "\U0001f936\U0001f3fe", "Mrs. Claus: Medium-Dark Skin Tone" }, // 1f936-1f3fe
            { "\U0001f936\U0001f3ff", "Mrs. Claus: Dark Skin Tone" }, // 1f936-1f3ff
            { "\U0001f9d9", "Mage" }, // 1f9d9
            { "\U0001f9d9\U0001f3fb", "Mage: Light Skin Tone" }, // 1f9d9-1f3fb
            { "\U0001f9d9\U0001f3fc", "Mage: Medium-Light Skin Tone" }, // 1f9d9-1f3fc
            { "\U0001f9d9\U0001f3fd", "Mage: Medium Skin Tone" }, // 1f9d9-1f3fd
            { "\U0001f9d9\U0001f3fe", "Mage: Medium-Dark Skin Tone" }, // 1f9d9-1f3fe
            { "\U0001f9d9\U0001f3ff", "Mage: Dark Skin Tone" }, // 1f9d9-1f3ff
            { "\U0001f9d9\u200d\u2640\ufe0f", "Woman Mage" }, // 1f9d9-200d-2640-fe0f
            { "\U0001f9d9\U0001f3fb\u200d\u2640\ufe0f", "Woman Mage: Light Skin Tone" }, // 1f9d9-1f3fb-200d-2640-fe0f
            { "\U0001f9d9\U0001f3fc\u200d\u2640\ufe0f", "Woman Mage: Medium-Light Skin Tone" }, // 1f9d9-1f3fc-200d-2640-fe0f
            { "\U0001f9d9\U0001f3fd\u200d\u2640\ufe0f", "Woman Mage: Medium Skin Tone" }, // 1f9d9-1f3fd-200d-2640-fe0f
            { "\U0001f9d9\U0001f3fe\u200d\u2640\ufe0f", "Woman Mage: Medium-Dark Skin Tone" }, // 1f9d9-1f3fe-200d-2640-fe0f
            { "\U0001f9d9\U0001f3ff\u200d\u2640\ufe0f", "Woman Mage: Dark Skin Tone" }, // 1f9d9-1f3ff-200d-2640-fe0f
            { "\U0001f9d9\u200d\u2642\ufe0f", "Man Mage" }, // 1f9d9-200d-2642-fe0f
            { "\U0001f9d9\U0001f3fb\u200d\u2642\ufe0f", "Man Mage: Light Skin Tone" }, // 1f9d9-1f3fb-200d-2642-fe0f
            { "\U0001f9d9\U0001f3fc\u200d\u2642\ufe0f", "Man Mage: Medium-Light Skin Tone" }, // 1f9d9-1f3fc-200d-2642-fe0f
            { "\U0001f9d9\U0001f3fd\u200d\u2642\ufe0f", "Man Mage: Medium Skin Tone" }, // 1f9d9-1f3fd-200d-2642-fe0f
            { "\U0001f9d9\U0001f3fe\u200d\u2642\ufe0f", "Man Mage: Medium-Dark Skin Tone" }, // 1f9d9-1f3fe-200d-2642-fe0f
            { "\U0001f9d9\U0001f3ff\u200d\u2642\ufe0f", "Man Mage: Dark Skin Tone" }, // 1f9d9-1f3ff-200d-2642-fe0f
            { "\U0001f9da", "Fairy" }, // 1f9da
            { "\U0001f9da\U0001f3fb", "Fairy: Light Skin Tone" }, // 1f9da-1f3fb
            { "\U0001f9da\U0001f3fc", "Fairy: Medium-Light Skin Tone" }, // 1f9da-1f3fc
            { "\U0001f9da\U0001f3fd", "Fairy: Medium Skin Tone" }, // 1f9da-1f3fd
            { "\U0001f9da\U0001f3fe", "Fairy: Medium-Dark Skin Tone" }, // 1f9da-1f3fe
            { "\U0001f9da\U0001f3ff", "Fairy: Dark Skin Tone" }, // 1f9da-1f3ff
            { "\U0001f9da\u200d\u2640\ufe0f", "Woman Fairy" }, // 1f9da-200d-2640-fe0f
            { "\U0001f9da\U0001f3fb\u200d\u2640\ufe0f", "Woman Fairy: Light Skin Tone" }, // 1f9da-1f3fb-200d-2640-fe0f
            { "\U0001f9da\U0001f3fc\u200d\u2640\ufe0f", "Woman Fairy: Medium-Light Skin Tone" }, // 1f9da-1f3fc-200d-2640-fe0f
            { "\U0001f9da\U0001f3fd\u200d\u2640\ufe0f", "Woman Fairy: Medium Skin Tone" }, // 1f9da-1f3fd-200d-2640-fe0f
            { "\U0001f9da\U0001f3fe\u200d\u2640\ufe0f", "Woman Fairy: Medium-Dark Skin Tone" }, // 1f9da-1f3fe-200d-2640-fe0f
            { "\U0001f9da\U0001f3ff\u200d\u2640\ufe0f", "Woman Fairy: Dark Skin Tone" }, // 1f9da-1f3ff-200d-2640-fe0f
            { "\U0001f9da\u200d\u2642\ufe0f", "Man Fairy" }, // 1f9da-200d-2642-fe0f
            { "\U0001f9da\U0001f3fb\u200d\u2642\ufe0f", "Man Fairy: Light Skin Tone" }, // 1f9da-1f3fb-200d-2642-fe0f
            { "\U0001f9da\U0001f3fc\u200d\u2642\ufe0f", "Man Fairy: Medium-Light Skin Tone" }, // 1f9da-1f3fc-200d-2642-fe0f
            { "\U0001f9da\U0001f3fd\u200d\u2642\ufe0f", "Man Fairy: Medium Skin Tone" }, // 1f9da-1f3fd-200d-2642-fe0f
            { "\U0001f9da\U0001f3fe\u200d\u2642\ufe0f", "Man Fairy: Medium-Dark Skin Tone" }, // 1f9da-1f3fe-200d-2642-fe0f
            { "\U0001f9da\U0001f3ff\u200d\u2642\ufe0f", "Man Fairy: Dark Skin Tone" }, // 1f9da-1f3ff-200d-2642-fe0f
            { "\U0001f9db", "Vampire" }, // 1f9db
            { "\U0001f9db\U0001f3fb", "Vampire: Light Skin Tone" }, // 1f9db-1f3fb
            { "\U0001f9db\U0001f3fc", "Vampire: Medium-Light Skin Tone" }, // 1f9db-1f3fc
            { "\U0001f9db\U0001f3fd", "Vampire: Medium Skin Tone" }, // 1f9db-1f3fd
            { "\U0001f9db\U0001f3fe", "Vampire: Medium-Dark Skin Tone" }, // 1f9db-1f3fe
            { "\U0001f9db\U0001f3ff", "Vampire: Dark Skin Tone" }, // 1f9db-1f3ff
            { "\U0001f9db\u200d\u2640\ufe0f", "Woman Vampire" }, // 1f9db-200d-2640-fe0f
            { "\U0001f9db\U0001f3fb\u200d\u2640\ufe0f", "Woman Vampire: Light Skin Tone" }, // 1f9db-1f3fb-200d-2640-fe0f
            { "\U0001f9db\U0001f3fc\u200d\u2640\ufe0f", "Woman Vampire: Medium-Light Skin Tone" }, // 1f9db-1f3fc-200d-2640-fe0f
            { "\U0001f9db\U0001f3fd\u200d\u2640\ufe0f", "Woman Vampire: Medium Skin Tone" }, // 1f9db-1f3fd-200d-2640-fe0f
            { "\U0001f9db\U0001f3fe\u200d\u2640\ufe0f", "Woman Vampire: Medium-Dark Skin Tone" }, // 1f9db-1f3fe-200d-2640-fe0f
            { "\U0001f9db\U0001f3ff\u200d\u2640\ufe0f", "Woman Vampire: Dark Skin Tone" }, // 1f9db-1f3ff-200d-2640-fe0f
            { "\U0001f9db\u200d\u2642\ufe0f", "Man Vampire" }, // 1f9db-200d-2642-fe0f
            { "\U0001f9db\U0001f3fb\u200d\u2642\ufe0f", "Man Vampire: Light Skin Tone" }, // 1f9db-1f3fb-200d-2642-fe0f
            { "\U0001f9db\U0001f3fc\u200d\u2642\ufe0f", "Man Vampire: Medium-Light Skin Tone" }, // 1f9db-1f3fc-200d-2642-fe0f
            { "\U0001f9db\U0001f3fd\u200d\u2642\ufe0f", "Man Vampire: Medium Skin Tone" }, // 1f9db-1f3fd-200d-2642-fe0f
            { "\U0001f9db\U0001f3fe\u200d\u2642\ufe0f", "Man Vampire: Medium-Dark Skin Tone" }, // 1f9db-1f3fe-200d-2642-fe0f
            { "\U0001f46f\U0001f3fb", "Woman With Bunny Ears, Type-1-2" }, // 1f46f-1f3fb
            { "\U0001f46f\U0001f3fc", "Woman With Bunny Ears, Type-3" }, // 1f46f-1f3fc
            { "\U0001f9db\U0001f3ff\u200d\u2642\ufe0f", "Man Vampire: Dark Skin Tone" }, // 1f9db-1f3ff-200d-2642-fe0f
            { "\U0001f46f\U0001f3fd", "Woman With Bunny Ears, Type-4" }, // 1f46f-1f3fd
            { "\U0001f46f\U0001f3fe", "Woman With Bunny Ears, Type-5" }, // 1f46f-1f3fe
            { "\U0001f9dc", "Merperson" }, // 1f9dc
            { "\U0001f46f\U0001f3ff", "Woman With Bunny Ears, Type-6" }, // 1f46f-1f3ff
            { "\U0001f9dc\U0001f3fb", "Merperson: Light Skin Tone" }, // 1f9dc-1f3fb
            { "\U0001f46f\U0001f3fb\u200d\u2642\ufe0f", "Men With Bunny Ears Partying, Type-1-2" }, // 1f46f-1f3fb-200d-2642-fe0f
            { "\U0001f9dc\U0001f3fc", "Merperson: Medium-Light Skin Tone" }, // 1f9dc-1f3fc
            { "\U0001f46f\U0001f3fc\u200d\u2642\ufe0f", "Men With Bunny Ears Partying, Type-3" }, // 1f46f-1f3fc-200d-2642-fe0f
            { "\U0001f9dc\U0001f3fd", "Merperson: Medium Skin Tone" }, // 1f9dc-1f3fd
            { "\U0001f46f\U0001f3fd\u200d\u2642\ufe0f", "Men With Bunny Ears Partying, Type-4" }, // 1f46f-1f3fd-200d-2642-fe0f
            { "\U0001f9dc\U0001f3fe", "Merperson: Medium-Dark Skin Tone" }, // 1f9dc-1f3fe
            { "\U0001f46f\U0001f3fe\u200d\u2642\ufe0f", "Men With Bunny Ears Partying, Type-5" }, // 1f46f-1f3fe-200d-2642-fe0f
            { "\U0001f9dc\U0001f3ff", "Merperson: Dark Skin Tone" }, // 1f9dc-1f3ff
            { "\U0001f46f\U0001f3ff\u200d\u2642\ufe0f", "Men With Bunny Ears Partying, Type-6" }, // 1f46f-1f3ff-200d-2642-fe0f
            { "\U0001f9dc\u200d\u2640\ufe0f", "Mermaid" }, // 1f9dc-200d-2640-fe0f
            { "\U0001f9dc\U0001f3fb\u200d\u2640\ufe0f", "Mermaid: Light Skin Tone" }, // 1f9dc-1f3fb-200d-2640-fe0f
            { "\U0001f46f\U0001f3fb\u200d\u2640\ufe0f", "Women With Bunny Ears Partying, Type-1-2" }, // 1f46f-1f3fb-200d-2640-fe0f
            { "\U0001f46f\U0001f3fc\u200d\u2640\ufe0f", "Women With Bunny Ears Partying, Type-3" }, // 1f46f-1f3fc-200d-2640-fe0f
            { "\U0001f9dc\U0001f3fc\u200d\u2640\ufe0f", "Mermaid: Medium-Light Skin Tone" }, // 1f9dc-1f3fc-200d-2640-fe0f
            { "\U0001f46f\U0001f3fd\u200d\u2640\ufe0f", "Women With Bunny Ears Partying, Type-4" }, // 1f46f-1f3fd-200d-2640-fe0f
            { "\U0001f46f\U0001f3fe\u200d\u2640\ufe0f", "Women With Bunny Ears Partying, Type-5" }, // 1f46f-1f3fe-200d-2640-fe0f
            { "\U0001f46f\U0001f3ff\u200d\u2640\ufe0f", "Women With Bunny Ears Partying, Type-6" }, // 1f46f-1f3ff-200d-2640-fe0f
            { "\U0001f9dc\U0001f3fd\u200d\u2640\ufe0f", "Mermaid: Medium Skin Tone" }, // 1f9dc-1f3fd-200d-2640-fe0f
            { "\U0001f9dc\U0001f3fe\u200d\u2640\ufe0f", "Mermaid: Medium-Dark Skin Tone" }, // 1f9dc-1f3fe-200d-2640-fe0f
            { "\U0001f9dc\U0001f3ff\u200d\u2640\ufe0f", "Mermaid: Dark Skin Tone" }, // 1f9dc-1f3ff-200d-2640-fe0f
            { "\U0001f9dc\u200d\u2642\ufe0f", "Merman" }, // 1f9dc-200d-2642-fe0f
            { "\U0001f9dc\U0001f3fb\u200d\u2642\ufe0f", "Merman: Light Skin Tone" }, // 1f9dc-1f3fb-200d-2642-fe0f
            { "\U0001f9dc\U0001f3fc\u200d\u2642\ufe0f", "Merman: Medium-Light Skin Tone" }, // 1f9dc-1f3fc-200d-2642-fe0f
            { "\U0001f46b\U0001f3fb", "Man and Woman Holding Hands, Type-1-2" }, // 1f46b-1f3fb
            { "\U0001f9dc\U0001f3fd\u200d\u2642\ufe0f", "Merman: Medium Skin Tone" }, // 1f9dc-1f3fd-200d-2642-fe0f
            { "\U0001f46b\U0001f3fc", "Man and Woman Holding Hands, Type-3" }, // 1f46b-1f3fc
            { "\U0001f46b\U0001f3fd", "Man and Woman Holding Hands, Type-4" }, // 1f46b-1f3fd
            { "\U0001f9dc\U0001f3fe\u200d\u2642\ufe0f", "Merman: Medium-Dark Skin Tone" }, // 1f9dc-1f3fe-200d-2642-fe0f
            { "\U0001f46b\U0001f3fe", "Man and Woman Holding Hands, Type-5" }, // 1f46b-1f3fe
            { "\U0001f46b\U0001f3ff", "Man and Woman Holding Hands, Type-6" }, // 1f46b-1f3ff
            { "\U0001f9dc\U0001f3ff\u200d\u2642\ufe0f", "Merman: Dark Skin Tone" }, // 1f9dc-1f3ff-200d-2642-fe0f
            { "\U0001f46c\U0001f3fb", "Two Men Holding Hands, Type-1-2" }, // 1f46c-1f3fb
            { "\U0001f9dd", "Elf" }, // 1f9dd
            { "\U0001f46c\U0001f3fc", "Two Men Holding Hands, Type-3" }, // 1f46c-1f3fc
            { "\U0001f46c\U0001f3fd", "Two Men Holding Hands, Type-4" }, // 1f46c-1f3fd
            { "\U0001f9dd\U0001f3fb", "Elf: Light Skin Tone" }, // 1f9dd-1f3fb
            { "\U0001f46c\U0001f3fe", "Two Men Holding Hands, Type-5" }, // 1f46c-1f3fe
            { "\U0001f9dd\U0001f3fc", "Elf: Medium-Light Skin Tone" }, // 1f9dd-1f3fc
            { "\U0001f46c\U0001f3ff", "Two Men Holding Hands, Type-6" }, // 1f46c-1f3ff
            { "\U0001f9dd\U0001f3fd", "Elf: Medium Skin Tone" }, // 1f9dd-1f3fd
            { "\U0001f9dd\U0001f3fe", "Elf: Medium-Dark Skin Tone" }, // 1f9dd-1f3fe
            { "\U0001f46d\U0001f3fb", "Two Women Holding Hands, Type-1-2" }, // 1f46d-1f3fb
            { "\U0001f9dd\U0001f3ff", "Elf: Dark Skin Tone" }, // 1f9dd-1f3ff
            { "\U0001f9dd\u200d\u2640\ufe0f", "Woman Elf" }, // 1f9dd-200d-2640-fe0f
            { "\U0001f46d\U0001f3fc", "Two Women Holding Hands, Type-3" }, // 1f46d-1f3fc
            { "\U0001f46d\U0001f3fd", "Two Women Holding Hands, Type-4" }, // 1f46d-1f3fd
            { "\U0001f9dd\U0001f3fb\u200d\u2640\ufe0f", "Woman Elf: Light Skin Tone" }, // 1f9dd-1f3fb-200d-2640-fe0f
            { "\U0001f46d\U0001f3fe", "Two Women Holding Hands, Type-5" }, // 1f46d-1f3fe
            { "\U0001f46d\U0001f3ff", "Two Women Holding Hands, Type-6" }, // 1f46d-1f3ff
            { "\U0001f9dd\U0001f3fc\u200d\u2640\ufe0f", "Woman Elf: Medium-Light Skin Tone" }, // 1f9dd-1f3fc-200d-2640-fe0f
            { "\U0001f9dd\U0001f3fd\u200d\u2640\ufe0f", "Woman Elf: Medium Skin Tone" }, // 1f9dd-1f3fd-200d-2640-fe0f
            { "\U0001f9dd\U0001f3fe\u200d\u2640\ufe0f", "Woman Elf: Medium-Dark Skin Tone" }, // 1f9dd-1f3fe-200d-2640-fe0f
            { "\U0001f9dd\U0001f3ff\u200d\u2640\ufe0f", "Woman Elf: Dark Skin Tone" }, // 1f9dd-1f3ff-200d-2640-fe0f
            { "\U0001f9dd\u200d\u2642\ufe0f", "Man Elf" }, // 1f9dd-200d-2642-fe0f
            { "\U0001f46a\U0001f3fb", "Family, Type-1-2" }, // 1f46a-1f3fb
            { "\U0001f9dd\U0001f3fb\u200d\u2642\ufe0f", "Man Elf: Light Skin Tone" }, // 1f9dd-1f3fb-200d-2642-fe0f
            { "\U0001f46a\U0001f3fc", "Family, Type-3" }, // 1f46a-1f3fc
            { "\U0001f46a\U0001f3fd", "Family, Type-4" }, // 1f46a-1f3fd
            { "\U0001f9dd\U0001f3fc\u200d\u2642\ufe0f", "Man Elf: Medium-Light Skin Tone" }, // 1f9dd-1f3fc-200d-2642-fe0f
            { "\U0001f46a\U0001f3fe", "Family, Type-5" }, // 1f46a-1f3fe
            { "\U0001f46a\U0001f3ff", "Family, Type-6" }, // 1f46a-1f3ff
            { "\U0001f9dd\U0001f3fd\u200d\u2642\ufe0f", "Man Elf: Medium Skin Tone" }, // 1f9dd-1f3fd-200d-2642-fe0f
            { "\U0001f9dd\U0001f3fe\u200d\u2642\ufe0f", "Man Elf: Medium-Dark Skin Tone" }, // 1f9dd-1f3fe-200d-2642-fe0f
            { "\U0001f9dd\U0001f3ff\u200d\u2642\ufe0f", "Man Elf: Dark Skin Tone" }, // 1f9dd-1f3ff-200d-2642-fe0f
            { "\U0001f9de", "Genie" }, // 1f9de
            { "\U0001f9de\u200d\u2640\ufe0f", "Woman Genie" }, // 1f9de-200d-2640-fe0f
            { "\U0001f9de\u200d\u2642\ufe0f", "Man Genie" }, // 1f9de-200d-2642-fe0f
            { "\U0001f9df", "Zombie" }, // 1f9df
            { "\U0001f9df\u200d\u2640\ufe0f", "Woman Zombie" }, // 1f9df-200d-2640-fe0f
            { "\U0001f9df\u200d\u2642\ufe0f", "Man Zombie" }, // 1f9df-200d-2642-fe0f
            { "\U0001f64d", "Person Frowning" }, // 1f64d
            { "\U0001f64d\U0001f3fb", "Person Frowning: Light Skin Tone" }, // 1f64d-1f3fb
            { "\U0001f64d\U0001f3fc", "Person Frowning: Medium-Light Skin Tone" }, // 1f64d-1f3fc
            { "\U0001f64d\U0001f3fd", "Person Frowning: Medium Skin Tone" }, // 1f64d-1f3fd
            { "\U0001f64d\U0001f3fe", "Person Frowning: Medium-Dark Skin Tone" }, // 1f64d-1f3fe
            { "\U0001f64d\U0001f3ff", "Person Frowning: Dark Skin Tone" }, // 1f64d-1f3ff
            { "\U0001f64d\u200d\u2642\ufe0f", "Man Frowning" }, // 1f64d-200d-2642-fe0f
            { "\U0001f64d\U0001f3fb\u200d\u2642\ufe0f", "Man Frowning: Light Skin Tone" }, // 1f64d-1f3fb-200d-2642-fe0f
            { "\U0001f3fb", "Light Skin Tone" }, // 1f3fb
            { "\U0001f64d\U0001f3fc\u200d\u2642\ufe0f", "Man Frowning: Medium-Light Skin Tone" }, // 1f64d-1f3fc-200d-2642-fe0f
            { "\U0001f3fc", "Medium-Light Skin Tone" }, // 1f3fc
            { "\U0001f3fd", "Medium Skin Tone" }, // 1f3fd
            { "\U0001f64d\U0001f3fd\u200d\u2642\ufe0f", "Man Frowning: Medium Skin Tone" }, // 1f64d-1f3fd-200d-2642-fe0f
            { "\U0001f3fe", "Medium-Dark Skin Tone" }, // 1f3fe
            { "\U0001f3ff", "Dark Skin Tone" }, // 1f3ff
            { "\U0001f64d\U0001f3fe\u200d\u2642\ufe0f", "Man Frowning: Medium-Dark Skin Tone" }, // 1f64d-1f3fe-200d-2642-fe0f
            { "\U0001f64d\U0001f3ff\u200d\u2642\ufe0f", "Man Frowning: Dark Skin Tone" }, // 1f64d-1f3ff-200d-2642-fe0f
            { "\U0001f64e", "Person Pouting" }, // 1f64e
            { "\U0001f64e\U0001f3fb", "Person Pouting: Light Skin Tone" }, // 1f64e-1f3fb
            { "\U0001f64e\U0001f3fc", "Person Pouting: Medium-Light Skin Tone" }, // 1f64e-1f3fc
            { "\U0001f64e\U0001f3fd", "Person Pouting: Medium Skin Tone" }, // 1f64e-1f3fd
            { "\U0001f64e\U0001f3fe", "Person Pouting: Medium-Dark Skin Tone" }, // 1f64e-1f3fe
            { "\U0001f64e\U0001f3ff", "Person Pouting: Dark Skin Tone" }, // 1f64e-1f3ff
            { "\U0001f64e\u200d\u2642\ufe0f", "Man Pouting" }, // 1f64e-200d-2642-fe0f
            { "\U0001f64e\U0001f3fb\u200d\u2642\ufe0f", "Man Pouting: Light Skin Tone" }, // 1f64e-1f3fb-200d-2642-fe0f
            { "\U0001f64e\U0001f3fc\u200d\u2642\ufe0f", "Man Pouting: Medium-Light Skin Tone" }, // 1f64e-1f3fc-200d-2642-fe0f
            { "\U0001f64e\U0001f3fd\u200d\u2642\ufe0f", "Man Pouting: Medium Skin Tone" }, // 1f64e-1f3fd-200d-2642-fe0f
            { "\U0001f64e\U0001f3fe\u200d\u2642\ufe0f", "Man Pouting: Medium-Dark Skin Tone" }, // 1f64e-1f3fe-200d-2642-fe0f
            { "\U0001f64e\U0001f3ff\u200d\u2642\ufe0f", "Man Pouting: Dark Skin Tone" }, // 1f64e-1f3ff-200d-2642-fe0f
            { "\U0001f645", "Person Gesturing No" }, // 1f645
            { "\U0001f645\U0001f3fb", "Person Gesturing No: Light Skin Tone" }, // 1f645-1f3fb
            { "\U0001f645\U0001f3fc", "Person Gesturing No: Medium-Light Skin Tone" }, // 1f645-1f3fc
            { "\U0001f645\U0001f3fd", "Person Gesturing No: Medium Skin Tone" }, // 1f645-1f3fd
            { "\U0001f645\U0001f3fe", "Person Gesturing No: Medium-Dark Skin Tone" }, // 1f645-1f3fe
            { "\U0001f645\U0001f3ff", "Person Gesturing No: Dark Skin Tone" }, // 1f645-1f3ff
            { "\U0001f645\u200d\u2642\ufe0f", "Man Gesturing No" }, // 1f645-200d-2642-fe0f
            { "\U0001f645\U0001f3fb\u200d\u2642\ufe0f", "Man Gesturing No: Light Skin Tone" }, // 1f645-1f3fb-200d-2642-fe0f
            { "\U0001f645\U0001f3fc\u200d\u2642\ufe0f", "Man Gesturing No: Medium-Light Skin Tone" }, // 1f645-1f3fc-200d-2642-fe0f
            { "\U0001f645\U0001f3fd\u200d\u2642\ufe0f", "Man Gesturing No: Medium Skin Tone" }, // 1f645-1f3fd-200d-2642-fe0f
            { "\U0001f645\U0001f3fe\u200d\u2642\ufe0f", "Man Gesturing No: Medium-Dark Skin Tone" }, // 1f645-1f3fe-200d-2642-fe0f
            { "\U0001f645\U0001f3ff\u200d\u2642\ufe0f", "Man Gesturing No: Dark Skin Tone" }, // 1f645-1f3ff-200d-2642-fe0f
            { "\U0001f646", "Person Gesturing OK" }, // 1f646
            { "\U0001f646\U0001f3fb", "Person Gesturing OK: Light Skin Tone" }, // 1f646-1f3fb
            { "\U0001f646\U0001f3fc", "Person Gesturing OK: Medium-Light Skin Tone" }, // 1f646-1f3fc
            { "\U0001f646\U0001f3fd", "Person Gesturing OK: Medium Skin Tone" }, // 1f646-1f3fd
            { "\U0001f646\U0001f3fe", "Person Gesturing OK: Medium-Dark Skin Tone" }, // 1f646-1f3fe
            { "\U0001f646\U0001f3ff", "Person Gesturing OK: Dark Skin Tone" }, // 1f646-1f3ff
            { "\U0001f646\u200d\u2642\ufe0f", "Man Gesturing OK" }, // 1f646-200d-2642-fe0f
            { "\U0001f646\U0001f3fb\u200d\u2642\ufe0f", "Man Gesturing OK: Light Skin Tone" }, // 1f646-1f3fb-200d-2642-fe0f
            { "\U0001f646\U0001f3fc\u200d\u2642\ufe0f", "Man Gesturing OK: Medium-Light Skin Tone" }, // 1f646-1f3fc-200d-2642-fe0f
            { "\U0001f646\U0001f3fd\u200d\u2642\ufe0f", "Man Gesturing OK: Medium Skin Tone" }, // 1f646-1f3fd-200d-2642-fe0f
            { "\U0001f646\U0001f3fe\u200d\u2642\ufe0f", "Man Gesturing OK: Medium-Dark Skin Tone" }, // 1f646-1f3fe-200d-2642-fe0f
            { "\U0001f646\U0001f3ff\u200d\u2642\ufe0f", "Man Gesturing OK: Dark Skin Tone" }, // 1f646-1f3ff-200d-2642-fe0f
            { "\U0001f481", "Person Tipping Hand" }, // 1f481
            { "\U0001f481\U0001f3fb", "Person Tipping Hand: Light Skin Tone" }, // 1f481-1f3fb
            { "\U0001f481\U0001f3fc", "Person Tipping Hand: Medium-Light Skin Tone" }, // 1f481-1f3fc
            { "\U0001f481\U0001f3fd", "Person Tipping Hand: Medium Skin Tone" }, // 1f481-1f3fd
            { "\U0001f481\U0001f3fe", "Person Tipping Hand: Medium-Dark Skin Tone" }, // 1f481-1f3fe
            { "\U0001f481\U0001f3ff", "Person Tipping Hand: Dark Skin Tone" }, // 1f481-1f3ff
            { "\U0001f481\u200d\u2642\ufe0f", "Man Tipping Hand" }, // 1f481-200d-2642-fe0f
            { "\U0001f481\U0001f3fb\u200d\u2642\ufe0f", "Man Tipping Hand: Light Skin Tone" }, // 1f481-1f3fb-200d-2642-fe0f
            { "\U0001f481\U0001f3fc\u200d\u2642\ufe0f", "Man Tipping Hand: Medium-Light Skin Tone" }, // 1f481-1f3fc-200d-2642-fe0f
            { "\U0001f481\U0001f3fd\u200d\u2642\ufe0f", "Man Tipping Hand: Medium Skin Tone" }, // 1f481-1f3fd-200d-2642-fe0f
            { "\U0001f481\U0001f3fe\u200d\u2642\ufe0f", "Man Tipping Hand: Medium-Dark Skin Tone" }, // 1f481-1f3fe-200d-2642-fe0f
            { "\U0001f481\U0001f3ff\u200d\u2642\ufe0f", "Man Tipping Hand: Dark Skin Tone" }, // 1f481-1f3ff-200d-2642-fe0f
            { "\U0001f64b", "Person Raising Hand" }, // 1f64b
            { "\U0001f64b\U0001f3fb", "Person Raising Hand: Light Skin Tone" }, // 1f64b-1f3fb
            { "\U0001f64b\U0001f3fc", "Person Raising Hand: Medium-Light Skin Tone" }, // 1f64b-1f3fc
            { "\U0001f64b\U0001f3fd", "Person Raising Hand: Medium Skin Tone" }, // 1f64b-1f3fd
            { "\U0001f64b\U0001f3fe", "Person Raising Hand: Medium-Dark Skin Tone" }, // 1f64b-1f3fe
            { "\U0001f64b\U0001f3ff", "Person Raising Hand: Dark Skin Tone" }, // 1f64b-1f3ff
            { "\U0001f64b\u200d\u2642\ufe0f", "Man Raising Hand" }, // 1f64b-200d-2642-fe0f
            { "\U0001f64b\U0001f3fb\u200d\u2642\ufe0f", "Man Raising Hand: Light Skin Tone" }, // 1f64b-1f3fb-200d-2642-fe0f
            { "\U0001f64b\U0001f3fc\u200d\u2642\ufe0f", "Man Raising Hand: Medium-Light Skin Tone" }, // 1f64b-1f3fc-200d-2642-fe0f
            { "\U0001f64b\U0001f3fd\u200d\u2642\ufe0f", "Man Raising Hand: Medium Skin Tone" }, // 1f64b-1f3fd-200d-2642-fe0f
            { "\U0001f64b\U0001f3fe\u200d\u2642\ufe0f", "Man Raising Hand: Medium-Dark Skin Tone" }, // 1f64b-1f3fe-200d-2642-fe0f
            { "\U0001f64b\U0001f3ff\u200d\u2642\ufe0f", "Man Raising Hand: Dark Skin Tone" }, // 1f64b-1f3ff-200d-2642-fe0f
            { "\U0001f647", "Person Bowing" }, // 1f647
            { "\U0001f647\U0001f3fb", "Person Bowing: Light Skin Tone" }, // 1f647-1f3fb
            { "\U0001f647\U0001f3fc", "Person Bowing: Medium-Light Skin Tone" }, // 1f647-1f3fc
            { "\U0001f647\U0001f3fd", "Person Bowing: Medium Skin Tone" }, // 1f647-1f3fd
            { "\U0001f647\U0001f3fe", "Person Bowing: Medium-Dark Skin Tone" }, // 1f647-1f3fe
            { "\U0001f647\U0001f3ff", "Person Bowing: Dark Skin Tone" }, // 1f647-1f3ff
            { "\U0001f91d\U0001f3fb", "Handshake, Type-1-2" }, // 1f91d-1f3fb
            { "\U0001f91d\U0001f3fc", "Handshake, Type-3" }, // 1f91d-1f3fc
            { "\U0001f91d\U0001f3fd", "Handshake, Type-4" }, // 1f91d-1f3fd
            { "\U0001f91d\U0001f3fe", "Handshake, Type-5" }, // 1f91d-1f3fe
            { "\U0001f91d\U0001f3ff", "Handshake, Type-6" }, // 1f91d-1f3ff
            { "\U0001f647\u200d\u2640\ufe0f", "Woman Bowing" }, // 1f647-200d-2640-fe0f
            { "\U0001f647\U0001f3fb\u200d\u2640\ufe0f", "Woman Bowing: Light Skin Tone" }, // 1f647-1f3fb-200d-2640-fe0f
            { "\U0001f647\U0001f3fc\u200d\u2640\ufe0f", "Woman Bowing: Medium-Light Skin Tone" }, // 1f647-1f3fc-200d-2640-fe0f
            { "\U0001f647\U0001f3fd\u200d\u2640\ufe0f", "Woman Bowing: Medium Skin Tone" }, // 1f647-1f3fd-200d-2640-fe0f
            { "\U0001f647\U0001f3fe\u200d\u2640\ufe0f", "Woman Bowing: Medium-Dark Skin Tone" }, // 1f647-1f3fe-200d-2640-fe0f
            { "\U0001f647\U0001f3ff\u200d\u2640\ufe0f", "Woman Bowing: Dark Skin Tone" }, // 1f647-1f3ff-200d-2640-fe0f
            { "\U0001f926", "Person Facepalming" }, // 1f926
            { "\U0001f926\U0001f3fb", "Person Facepalming: Light Skin Tone" }, // 1f926-1f3fb
            { "\U0001f926\U0001f3fc", "Person Facepalming: Medium-Light Skin Tone" }, // 1f926-1f3fc
            { "\U0001f926\U0001f3fd", "Person Facepalming: Medium Skin Tone" }, // 1f926-1f3fd
            { "\U0001f926\U0001f3fe", "Person Facepalming: Medium-Dark Skin Tone" }, // 1f926-1f3fe
            { "\U0001f926\U0001f3ff", "Person Facepalming: Dark Skin Tone" }, // 1f926-1f3ff
            { "\U0001f926\u200d\u2642\ufe0f", "Man Facepalming" }, // 1f926-200d-2642-fe0f
            { "\U0001f926\U0001f3fb\u200d\u2642\ufe0f", "Man Facepalming: Light Skin Tone" }, // 1f926-1f3fb-200d-2642-fe0f
            { "\U0001f926\U0001f3fc\u200d\u2642\ufe0f", "Man Facepalming: Medium-Light Skin Tone" }, // 1f926-1f3fc-200d-2642-fe0f
            { "\U0001f926\U0001f3fd\u200d\u2642\ufe0f", "Man Facepalming: Medium Skin Tone" }, // 1f926-1f3fd-200d-2642-fe0f
            { "\U0001f926\U0001f3fe\u200d\u2642\ufe0f", "Man Facepalming: Medium-Dark Skin Tone" }, // 1f926-1f3fe-200d-2642-fe0f
            { "\U0001f926\U0001f3ff\u200d\u2642\ufe0f", "Man Facepalming: Dark Skin Tone" }, // 1f926-1f3ff-200d-2642-fe0f
            { "\U0001f937", "Person Shrugging" }, // 1f937
            { "\U0001f937\U0001f3fb", "Person Shrugging: Light Skin Tone" }, // 1f937-1f3fb
            { "\U0001f937\U0001f3fc", "Person Shrugging: Medium-Light Skin Tone" }, // 1f937-1f3fc
            { "\U0001f937\U0001f3fd", "Person Shrugging: Medium Skin Tone" }, // 1f937-1f3fd
            { "\U0001f937\U0001f3fe", "Person Shrugging: Medium-Dark Skin Tone" }, // 1f937-1f3fe
            { "\U0001f937\U0001f3ff", "Person Shrugging: Dark Skin Tone" }, // 1f937-1f3ff
            { "\U0001f937\u200d\u2642\ufe0f", "Man Shrugging" }, // 1f937-200d-2642-fe0f
            { "\U0001f937\U0001f3fb\u200d\u2642\ufe0f", "Man Shrugging: Light Skin Tone" }, // 1f937-1f3fb-200d-2642-fe0f
            { "\U0001f937\U0001f3fc\u200d\u2642\ufe0f", "Man Shrugging: Medium-Light Skin Tone" }, // 1f937-1f3fc-200d-2642-fe0f
            { "\U0001f937\U0001f3fd\u200d\u2642\ufe0f", "Man Shrugging: Medium Skin Tone" }, // 1f937-1f3fd-200d-2642-fe0f
            { "\U0001f937\U0001f3fe\u200d\u2642\ufe0f", "Man Shrugging: Medium-Dark Skin Tone" }, // 1f937-1f3fe-200d-2642-fe0f
            { "\U0001f937\U0001f3ff\u200d\u2642\ufe0f", "Man Shrugging: Dark Skin Tone" }, // 1f937-1f3ff-200d-2642-fe0f
            { "\U0001f486", "Person Getting Massage" }, // 1f486
            { "\U0001f486\U0001f3fb", "Person Getting Massage: Light Skin Tone" }, // 1f486-1f3fb
            { "\U0001f486\U0001f3fc", "Person Getting Massage: Medium-Light Skin Tone" }, // 1f486-1f3fc
            { "\U0001f486\U0001f3fd", "Person Getting Massage: Medium Skin Tone" }, // 1f486-1f3fd
            { "\U0001f486\U0001f3fe", "Person Getting Massage: Medium-Dark Skin Tone" }, // 1f486-1f3fe
            { "\U0001f486\U0001f3ff", "Person Getting Massage: Dark Skin Tone" }, // 1f486-1f3ff
            { "\U0001f486\u200d\u2642\ufe0f", "Man Getting Massage" }, // 1f486-200d-2642-fe0f
            { "\U0001f486\U0001f3fb\u200d\u2642\ufe0f", "Man Getting Massage: Light Skin Tone" }, // 1f486-1f3fb-200d-2642-fe0f
            { "\U0001f486\U0001f3fc\u200d\u2642\ufe0f", "Man Getting Massage: Medium-Light Skin Tone" }, // 1f486-1f3fc-200d-2642-fe0f
            { "\U0001f486\U0001f3fd\u200d\u2642\ufe0f", "Man Getting Massage: Medium Skin Tone" }, // 1f486-1f3fd-200d-2642-fe0f
            { "\U0001f486\U0001f3fe\u200d\u2642\ufe0f", "Man Getting Massage: Medium-Dark Skin Tone" }, // 1f486-1f3fe-200d-2642-fe0f
            { "\U0001f486\U0001f3ff\u200d\u2642\ufe0f", "Man Getting Massage: Dark Skin Tone" }, // 1f486-1f3ff-200d-2642-fe0f
            { "\U0001f486\u200d\u2640\ufe0f", "Woman Getting Massage" }, // 1f486-200d-2640-fe0f
            { "\U0001f486\U0001f3fb\u200d\u2640\ufe0f", "Woman Getting Massage: Light Skin Tone" }, // 1f486-1f3fb-200d-2640-fe0f
            { "\U0001f486\U0001f3fc\u200d\u2640\ufe0f", "Woman Getting Massage: Medium-Light Skin Tone" }, // 1f486-1f3fc-200d-2640-fe0f
            { "\U0001f486\U0001f3fd\u200d\u2640\ufe0f", "Woman Getting Massage: Medium Skin Tone" }, // 1f486-1f3fd-200d-2640-fe0f
            { "\U0001f486\U0001f3fe\u200d\u2640\ufe0f", "Woman Getting Massage: Medium-Dark Skin Tone" }, // 1f486-1f3fe-200d-2640-fe0f
            { "\U0001f486\U0001f3ff\u200d\u2640\ufe0f", "Woman Getting Massage: Dark Skin Tone" }, // 1f486-1f3ff-200d-2640-fe0f
            { "\U0001f487", "Person Getting Haircut" }, // 1f487
            { "\U0001f487\U0001f3fb", "Person Getting Haircut: Light Skin Tone" }, // 1f487-1f3fb
            { "\U0001f487\U0001f3fc", "Person Getting Haircut: Medium-Light Skin Tone" }, // 1f487-1f3fc
            { "\U0001f487\U0001f3fd", "Person Getting Haircut: Medium Skin Tone" }, // 1f487-1f3fd
            { "\U0001f487\U0001f3fe", "Person Getting Haircut: Medium-Dark Skin Tone" }, // 1f487-1f3fe
            { "\U0001f487\U0001f3ff", "Person Getting Haircut: Dark Skin Tone" }, // 1f487-1f3ff
            { "\U0001f487\u200d\u2642\ufe0f", "Man Getting Haircut" }, // 1f487-200d-2642-fe0f
            { "\U0001f487\U0001f3fb\u200d\u2642\ufe0f", "Man Getting Haircut: Light Skin Tone" }, // 1f487-1f3fb-200d-2642-fe0f
            { "\U0001f487\U0001f3fc\u200d\u2642\ufe0f", "Man Getting Haircut: Medium-Light Skin Tone" }, // 1f487-1f3fc-200d-2642-fe0f
            { "\U0001f487\U0001f3fd\u200d\u2642\ufe0f", "Man Getting Haircut: Medium Skin Tone" }, // 1f487-1f3fd-200d-2642-fe0f
            { "\U0001f487\U0001f3fe\u200d\u2642\ufe0f", "Man Getting Haircut: Medium-Dark Skin Tone" }, // 1f487-1f3fe-200d-2642-fe0f
            { "\U0001f487\U0001f3ff\u200d\u2642\ufe0f", "Man Getting Haircut: Dark Skin Tone" }, // 1f487-1f3ff-200d-2642-fe0f
            { "\U0001f6b6", "Person Walking" }, // 1f6b6
            { "\U0001f6b6\U0001f3fb", "Person Walking: Light Skin Tone" }, // 1f6b6-1f3fb
            { "\U0001f6b6\U0001f3fc", "Person Walking: Medium-Light Skin Tone" }, // 1f6b6-1f3fc
            { "\U0001f6b6\U0001f3fd", "Person Walking: Medium Skin Tone" }, // 1f6b6-1f3fd
            { "\U0001f6b6\U0001f3fe", "Person Walking: Medium-Dark Skin Tone" }, // 1f6b6-1f3fe
            { "\U0001f6b6\U0001f3ff", "Person Walking: Dark Skin Tone" }, // 1f6b6-1f3ff
            { "\U0001f6b6\u200d\u2642\ufe0f", "Man Walking" }, // 1f6b6-200d-2642-fe0f
            { "\U0001f6b6\U0001f3fb\u200d\u2642\ufe0f", "Man Walking: Light Skin Tone" }, // 1f6b6-1f3fb-200d-2642-fe0f
            { "\U0001f6b6\U0001f3fc\u200d\u2642\ufe0f", "Man Walking: Medium-Light Skin Tone" }, // 1f6b6-1f3fc-200d-2642-fe0f
            { "\U0001f6b6\U0001f3fd\u200d\u2642\ufe0f", "Man Walking: Medium Skin Tone" }, // 1f6b6-1f3fd-200d-2642-fe0f
            { "\U0001f6b6\U0001f3fe\u200d\u2642\ufe0f", "Man Walking: Medium-Dark Skin Tone" }, // 1f6b6-1f3fe-200d-2642-fe0f
            { "\U0001f6b6\U0001f3ff\u200d\u2642\ufe0f", "Man Walking: Dark Skin Tone" }, // 1f6b6-1f3ff-200d-2642-fe0f
            { "\U0001f6b6\u200d\u2640\ufe0f", "Woman Walking" }, // 1f6b6-200d-2640-fe0f
            { "\U0001f6b6\U0001f3fb\u200d\u2640\ufe0f", "Woman Walking: Light Skin Tone" }, // 1f6b6-1f3fb-200d-2640-fe0f
            { "\U0001f6b6\U0001f3fc\u200d\u2640\ufe0f", "Woman Walking: Medium-Light Skin Tone" }, // 1f6b6-1f3fc-200d-2640-fe0f
            { "\U0001f6b6\U0001f3fd\u200d\u2640\ufe0f", "Woman Walking: Medium Skin Tone" }, // 1f6b6-1f3fd-200d-2640-fe0f
            { "\U0001f6b6\U0001f3fe\u200d\u2640\ufe0f", "Woman Walking: Medium-Dark Skin Tone" }, // 1f6b6-1f3fe-200d-2640-fe0f
            { "\U0001f6b6\U0001f3ff\u200d\u2640\ufe0f", "Woman Walking: Dark Skin Tone" }, // 1f6b6-1f3ff-200d-2640-fe0f
            { "\U0001f3c3", "Person Running" }, // 1f3c3
            { "\U0001f3c3\U0001f3fb", "Person Running: Light Skin Tone" }, // 1f3c3-1f3fb
            { "\U0001f3c3\U0001f3fc", "Person Running: Medium-Light Skin Tone" }, // 1f3c3-1f3fc
            { "\U0001f3c3\U0001f3fd", "Person Running: Medium Skin Tone" }, // 1f3c3-1f3fd
            { "\U0001f3c3\U0001f3fe", "Person Running: Medium-Dark Skin Tone" }, // 1f3c3-1f3fe
            { "\U0001f3c3\U0001f3ff", "Person Running: Dark Skin Tone" }, // 1f3c3-1f3ff
            { "\U0001f3c3\u200d\u2642\ufe0f", "Man Running" }, // 1f3c3-200d-2642-fe0f
            { "\U0001f3c3\U0001f3fb\u200d\u2642\ufe0f", "Man Running: Light Skin Tone" }, // 1f3c3-1f3fb-200d-2642-fe0f
            { "\U0001f3c3\U0001f3fc\u200d\u2642\ufe0f", "Man Running: Medium-Light Skin Tone" }, // 1f3c3-1f3fc-200d-2642-fe0f
            { "\U0001f3c3\U0001f3fd\u200d\u2642\ufe0f", "Man Running: Medium Skin Tone" }, // 1f3c3-1f3fd-200d-2642-fe0f
            { "\U0001f3c3\U0001f3fe\u200d\u2642\ufe0f", "Man Running: Medium-Dark Skin Tone" }, // 1f3c3-1f3fe-200d-2642-fe0f
            { "\U0001f3c3\U0001f3ff\u200d\u2642\ufe0f", "Man Running: Dark Skin Tone" }, // 1f3c3-1f3ff-200d-2642-fe0f
            { "\U0001f3c3\u200d\u2640\ufe0f", "Woman Running" }, // 1f3c3-200d-2640-fe0f
            { "\U0001f3c3\U0001f3fb\u200d\u2640\ufe0f", "Woman Running: Light Skin Tone" }, // 1f3c3-1f3fb-200d-2640-fe0f
            { "\U0001f3c3\U0001f3fc\u200d\u2640\ufe0f", "Woman Running: Medium-Light Skin Tone" }, // 1f3c3-1f3fc-200d-2640-fe0f
            { "\U0001f3c3\U0001f3fd\u200d\u2640\ufe0f", "Woman Running: Medium Skin Tone" }, // 1f3c3-1f3fd-200d-2640-fe0f
            { "\U0001f3c3\U0001f3fe\u200d\u2640\ufe0f", "Woman Running: Medium-Dark Skin Tone" }, // 1f3c3-1f3fe-200d-2640-fe0f
            { "\U0001f3c3\U0001f3ff\u200d\u2640\ufe0f", "Woman Running: Dark Skin Tone" }, // 1f3c3-1f3ff-200d-2640-fe0f
            { "\U0001f483", "Woman Dancing" }, // 1f483
            { "\U0001f483\U0001f3fb", "Woman Dancing: Light Skin Tone" }, // 1f483-1f3fb
            { "\U0001f483\U0001f3fc", "Woman Dancing: Medium-Light Skin Tone" }, // 1f483-1f3fc
            { "\U0001f483\U0001f3fd", "Woman Dancing: Medium Skin Tone" }, // 1f483-1f3fd
            { "\U0001f483\U0001f3fe", "Woman Dancing: Medium-Dark Skin Tone" }, // 1f483-1f3fe
            { "\U0001f483\U0001f3ff", "Woman Dancing: Dark Skin Tone" }, // 1f483-1f3ff
            { "\U0001f57a", "Man Dancing" }, // 1f57a
            { "\U0001f57a\U0001f3fb", "Man Dancing: Light Skin Tone" }, // 1f57a-1f3fb
            { "\U0001f57a\U0001f3fc", "Man Dancing: Medium-Light Skin Tone" }, // 1f57a-1f3fc
            { "\U0001f57a\U0001f3fd", "Man Dancing: Medium Skin Tone" }, // 1f57a-1f3fd
            { "\U0001f57a\U0001f3fe", "Man Dancing: Medium-Dark Skin Tone" }, // 1f57a-1f3fe
            { "\U0001f57a\U0001f3ff", "Man Dancing: Dark Skin Tone" }, // 1f57a-1f3ff
            { "\U0001f46f", "People With Bunny Ears Partying" }, // 1f46f
            { "\U0001f46f\u200d\u2642\ufe0f", "Men With Bunny Ears Partying" }, // 1f46f-200d-2642-fe0f
            { "\U0001f46f\u200d\u2640\ufe0f", "Women With Bunny Ears Partying" }, // 1f46f-200d-2640-fe0f
            { "\U0001f9d6", "Person in Steamy Room" }, // 1f9d6
            { "\U0001f9d6\U0001f3fb", "Person in Steamy Room: Light Skin Tone" }, // 1f9d6-1f3fb
            { "\U0001f9d6\U0001f3fc", "Person in Steamy Room: Medium-Light Skin Tone" }, // 1f9d6-1f3fc
            { "\U0001f9d6\U0001f3fd", "Person in Steamy Room: Medium Skin Tone" }, // 1f9d6-1f3fd
            { "\U0001f9d6\U0001f3fe", "Person in Steamy Room: Medium-Dark Skin Tone" }, // 1f9d6-1f3fe
            { "\U0001f9d6\U0001f3ff", "Person in Steamy Room: Dark Skin Tone" }, // 1f9d6-1f3ff
            { "\U0001f9d6\u200d\u2640\ufe0f", "Woman in Steamy Room" }, // 1f9d6-200d-2640-fe0f
            { "\U0001f9d6\U0001f3fb\u200d\u2640\ufe0f", "Woman in Steamy Room: Light Skin Tone" }, // 1f9d6-1f3fb-200d-2640-fe0f
            { "\U0001f9d6\U0001f3fc\u200d\u2640\ufe0f", "Woman in Steamy Room: Medium-Light Skin Tone" }, // 1f9d6-1f3fc-200d-2640-fe0f
            { "\U0001f9d6\U0001f3fd\u200d\u2640\ufe0f", "Woman in Steamy Room: Medium Skin Tone" }, // 1f9d6-1f3fd-200d-2640-fe0f
            { "\U0001f9d6\U0001f3fe\u200d\u2640\ufe0f", "Woman in Steamy Room: Medium-Dark Skin Tone" }, // 1f9d6-1f3fe-200d-2640-fe0f
            { "\U0001f9d6\U0001f3ff\u200d\u2640\ufe0f", "Woman in Steamy Room: Dark Skin Tone" }, // 1f9d6-1f3ff-200d-2640-fe0f
            { "\U0001f9d6\u200d\u2642\ufe0f", "Man in Steamy Room" }, // 1f9d6-200d-2642-fe0f
            { "\U0001f9d6\U0001f3fb\u200d\u2642\ufe0f", "Man in Steamy Room: Light Skin Tone" }, // 1f9d6-1f3fb-200d-2642-fe0f
            { "\U0001f9d6\U0001f3fc\u200d\u2642\ufe0f", "Man in Steamy Room: Medium-Light Skin Tone" }, // 1f9d6-1f3fc-200d-2642-fe0f
            { "\U0001f9d6\U0001f3fd\u200d\u2642\ufe0f", "Man in Steamy Room: Medium Skin Tone" }, // 1f9d6-1f3fd-200d-2642-fe0f
            { "\U0001f9d6\U0001f3fe\u200d\u2642\ufe0f", "Man in Steamy Room: Medium-Dark Skin Tone" }, // 1f9d6-1f3fe-200d-2642-fe0f
            { "\U0001f9d6\U0001f3ff\u200d\u2642\ufe0f", "Man in Steamy Room: Dark Skin Tone" }, // 1f9d6-1f3ff-200d-2642-fe0f
            { "\U0001f9d7", "Person Climbing" }, // 1f9d7
            { "\U0001f9d7\U0001f3fb", "Person Climbing: Light Skin Tone" }, // 1f9d7-1f3fb
            { "\U0001f9d7\U0001f3fc", "Person Climbing: Medium-Light Skin Tone" }, // 1f9d7-1f3fc
            { "\U0001f9d7\U0001f3fd", "Person Climbing: Medium Skin Tone" }, // 1f9d7-1f3fd
            { "\U0001f9d7\U0001f3fe", "Person Climbing: Medium-Dark Skin Tone" }, // 1f9d7-1f3fe
            { "\U0001f9d7\U0001f3ff", "Person Climbing: Dark Skin Tone" }, // 1f9d7-1f3ff
            { "\U0001f9d7\u200d\u2640\ufe0f", "Woman Climbing" }, // 1f9d7-200d-2640-fe0f
            { "\U0001f9d7\U0001f3fb\u200d\u2640\ufe0f", "Woman Climbing: Light Skin Tone" }, // 1f9d7-1f3fb-200d-2640-fe0f
            { "\U0001f9d7\U0001f3fc\u200d\u2640\ufe0f", "Woman Climbing: Medium-Light Skin Tone" }, // 1f9d7-1f3fc-200d-2640-fe0f
            { "\U0001f9d7\U0001f3fd\u200d\u2640\ufe0f", "Woman Climbing: Medium Skin Tone" }, // 1f9d7-1f3fd-200d-2640-fe0f
            { "\U0001f9d7\U0001f3fe\u200d\u2640\ufe0f", "Woman Climbing: Medium-Dark Skin Tone" }, // 1f9d7-1f3fe-200d-2640-fe0f
            { "\U0001f9d7\U0001f3ff\u200d\u2640\ufe0f", "Woman Climbing: Dark Skin Tone" }, // 1f9d7-1f3ff-200d-2640-fe0f
            { "\U0001f9d7\u200d\u2642\ufe0f", "Man Climbing" }, // 1f9d7-200d-2642-fe0f
            { "\U0001f9d7\U0001f3fb\u200d\u2642\ufe0f", "Man Climbing: Light Skin Tone" }, // 1f9d7-1f3fb-200d-2642-fe0f
            { "\U0001f9d7\U0001f3fc\u200d\u2642\ufe0f", "Man Climbing: Medium-Light Skin Tone" }, // 1f9d7-1f3fc-200d-2642-fe0f
            { "\U0001f9d7\U0001f3fd\u200d\u2642\ufe0f", "Man Climbing: Medium Skin Tone" }, // 1f9d7-1f3fd-200d-2642-fe0f
            { "\U0001f9d7\U0001f3fe\u200d\u2642\ufe0f", "Man Climbing: Medium-Dark Skin Tone" }, // 1f9d7-1f3fe-200d-2642-fe0f
            { "\U0001f9d7\U0001f3ff\u200d\u2642\ufe0f", "Man Climbing: Dark Skin Tone" }, // 1f9d7-1f3ff-200d-2642-fe0f
            { "\U0001f9d8", "Person in Lotus Position" }, // 1f9d8
            { "\U0001f9d8\U0001f3fb", "Person in Lotus Position: Light Skin Tone" }, // 1f9d8-1f3fb
            { "\U0001f9d8\U0001f3fc", "Person in Lotus Position: Medium-Light Skin Tone" }, // 1f9d8-1f3fc
            { "\U0001f9d8\U0001f3fd", "Person in Lotus Position: Medium Skin Tone" }, // 1f9d8-1f3fd
            { "\U0001f9d8\U0001f3fe", "Person in Lotus Position: Medium-Dark Skin Tone" }, // 1f9d8-1f3fe
            { "\U0001f9d8\U0001f3ff", "Person in Lotus Position: Dark Skin Tone" }, // 1f9d8-1f3ff
            { "\U0001f9d8\u200d\u2640\ufe0f", "Woman in Lotus Position" }, // 1f9d8-200d-2640-fe0f
            { "\U0001f9d8\U0001f3fb\u200d\u2640\ufe0f", "Woman in Lotus Position: Light Skin Tone" }, // 1f9d8-1f3fb-200d-2640-fe0f
            { "\U0001f9d8\U0001f3fc\u200d\u2640\ufe0f", "Woman in Lotus Position: Medium-Light Skin Tone" }, // 1f9d8-1f3fc-200d-2640-fe0f
            { "\U0001f9d8\U0001f3fd\u200d\u2640\ufe0f", "Woman in Lotus Position: Medium Skin Tone" }, // 1f9d8-1f3fd-200d-2640-fe0f
            { "\U0001f9d8\U0001f3fe\u200d\u2640\ufe0f", "Woman in Lotus Position: Medium-Dark Skin Tone" }, // 1f9d8-1f3fe-200d-2640-fe0f
            { "\U0001f9d8\U0001f3ff\u200d\u2640\ufe0f", "Woman in Lotus Position: Dark Skin Tone" }, // 1f9d8-1f3ff-200d-2640-fe0f
            { "\U0001f9d8\u200d\u2642\ufe0f", "Man in Lotus Position" }, // 1f9d8-200d-2642-fe0f
            { "\U0001f9d8\U0001f3fb\u200d\u2642\ufe0f", "Man in Lotus Position: Light Skin Tone" }, // 1f9d8-1f3fb-200d-2642-fe0f
            { "\U0001f9d8\U0001f3fc\u200d\u2642\ufe0f", "Man in Lotus Position: Medium-Light Skin Tone" }, // 1f9d8-1f3fc-200d-2642-fe0f
            { "\U0001f9d8\U0001f3fd\u200d\u2642\ufe0f", "Man in Lotus Position: Medium Skin Tone" }, // 1f9d8-1f3fd-200d-2642-fe0f
            { "\U0001f9d8\U0001f3fe\u200d\u2642\ufe0f", "Man in Lotus Position: Medium-Dark Skin Tone" }, // 1f9d8-1f3fe-200d-2642-fe0f
            { "\U0001f9d8\U0001f3ff\u200d\u2642\ufe0f", "Man in Lotus Position: Dark Skin Tone" }, // 1f9d8-1f3ff-200d-2642-fe0f
            { "\U0001f6c0", "Person Taking Bath" }, // 1f6c0
            { "\U0001f6c0\U0001f3fb", "Person Taking Bath: Light Skin Tone" }, // 1f6c0-1f3fb
            { "\U0001f6c0\U0001f3fc", "Person Taking Bath: Medium-Light Skin Tone" }, // 1f6c0-1f3fc
            { "\U0001f6c0\U0001f3fd", "Person Taking Bath: Medium Skin Tone" }, // 1f6c0-1f3fd
            { "\U0001f6c0\U0001f3fe", "Person Taking Bath: Medium-Dark Skin Tone" }, // 1f6c0-1f3fe
            { "\U0001f6c0\U0001f3ff", "Person Taking Bath: Dark Skin Tone" }, // 1f6c0-1f3ff
            { "\U0001f6cc", "Person in Bed" }, // 1f6cc
            { "\U0001f6cc\U0001f3fb", "Person in Bed: Light Skin Tone" }, // 1f6cc-1f3fb
            { "\U0001f6cc\U0001f3fc", "Person in Bed: Medium-Light Skin Tone" }, // 1f6cc-1f3fc
            { "\U0001f6cc\U0001f3fd", "Person in Bed: Medium Skin Tone" }, // 1f6cc-1f3fd
            { "\U0001f6cc\U0001f3fe", "Person in Bed: Medium-Dark Skin Tone" }, // 1f6cc-1f3fe
            { "\U0001f6cc\U0001f3ff", "Person in Bed: Dark Skin Tone" }, // 1f6cc-1f3ff
            { "\U0001f574", "Man in Business Suit Levitating" }, // 1f574
            { "\U0001f574\U0001f3fb", "Man in Business Suit Levitating: Light Skin Tone" }, // 1f574-1f3fb
            { "\U0001f574\U0001f3fc", "Man in Business Suit Levitating: Medium-Light Skin Tone" }, // 1f574-1f3fc
            { "\U0001f574\U0001f3fd", "Man in Business Suit Levitating: Medium Skin Tone" }, // 1f574-1f3fd
            { "\U0001f574\U0001f3fe", "Man in Business Suit Levitating: Medium-Dark Skin Tone" }, // 1f574-1f3fe
            { "\U0001f574\U0001f3ff", "Man in Business Suit Levitating: Dark Skin Tone" }, // 1f574-1f3ff
            { "\U0001f5e3", "Speaking Head" }, // 1f5e3
            { "\U0001f464", "Bust in Silhouette" }, // 1f464
            { "\U0001f465", "Busts in Silhouette" }, // 1f465
            { "\U0001f93a", "Person Fencing" }, // 1f93a
            { "\U0001f3c7", "Horse Racing" }, // 1f3c7
            { "\U0001f3c7\U0001f3fb", "Horse Racing: Light Skin Tone" }, // 1f3c7-1f3fb
            { "\U0001f3c7\U0001f3fc", "Horse Racing: Medium-Light Skin Tone" }, // 1f3c7-1f3fc
            { "\U0001f3c7\U0001f3fd", "Horse Racing: Medium Skin Tone" }, // 1f3c7-1f3fd
            { "\U0001f3c7\U0001f3fe", "Horse Racing: Medium-Dark Skin Tone" }, // 1f3c7-1f3fe
            { "\U0001f3c7\U0001f3ff", "Horse Racing: Dark Skin Tone" }, // 1f3c7-1f3ff
            { "\u26f7", "Skier" }, // 26f7
            { "\U0001f3c2", "Snowboarder" }, // 1f3c2
            { "\U0001f3c2\U0001f3fb", "Snowboarder: Light Skin Tone" }, // 1f3c2-1f3fb
            { "\U0001f3c2\U0001f3fc", "Snowboarder: Medium-Light Skin Tone" }, // 1f3c2-1f3fc
            { "\U0001f3c2\U0001f3fd", "Snowboarder: Medium Skin Tone" }, // 1f3c2-1f3fd
            { "\U0001f3c2\U0001f3fe", "Snowboarder: Medium-Dark Skin Tone" }, // 1f3c2-1f3fe
            { "\U0001f3c2\U0001f3ff", "Snowboarder: Dark Skin Tone" }, // 1f3c2-1f3ff
            { "\U0001f3cc", "Person Golfing" }, // 1f3cc
            { "\U0001f3cc\U0001f3fb", "Person Golfing: Light Skin Tone" }, // 1f3cc-1f3fb
            { "\U0001f3cc\U0001f3fc", "Person Golfing: Medium-Light Skin Tone" }, // 1f3cc-1f3fc
            { "\U0001f3cc\U0001f3fd", "Person Golfing: Medium Skin Tone" }, // 1f3cc-1f3fd
            { "\U0001f3cc\U0001f3fe", "Person Golfing: Medium-Dark Skin Tone" }, // 1f3cc-1f3fe
            { "\U0001f3cc\U0001f3ff", "Person Golfing: Dark Skin Tone" }, // 1f3cc-1f3ff
            { "\U0001f3cc\ufe0f\u200d\u2642\ufe0f", "Man Golfing" }, // 1f3cc-fe0f-200d-2642-fe0f
            { "\U0001f3cc\U0001f3fb\u200d\u2642\ufe0f", "Man Golfing: Light Skin Tone" }, // 1f3cc-1f3fb-200d-2642-fe0f
            { "\U0001f3cc\U0001f3fc\u200d\u2642\ufe0f", "Man Golfing: Medium-Light Skin Tone" }, // 1f3cc-1f3fc-200d-2642-fe0f
            { "\U0001f3cc\U0001f3fd\u200d\u2642\ufe0f", "Man Golfing: Medium Skin Tone" }, // 1f3cc-1f3fd-200d-2642-fe0f
            { "\U0001f3cc\U0001f3fe\u200d\u2642\ufe0f", "Man Golfing: Medium-Dark Skin Tone" }, // 1f3cc-1f3fe-200d-2642-fe0f
            { "\U0001f3cc\U0001f3ff\u200d\u2642\ufe0f", "Man Golfing: Dark Skin Tone" }, // 1f3cc-1f3ff-200d-2642-fe0f
            { "\U0001f3cc\ufe0f\u200d\u2640\ufe0f", "Woman Golfing" }, // 1f3cc-fe0f-200d-2640-fe0f
            { "\U0001f3cc\U0001f3fb\u200d\u2640\ufe0f", "Woman Golfing: Light Skin Tone" }, // 1f3cc-1f3fb-200d-2640-fe0f
            { "\U0001f3cc\U0001f3fc\u200d\u2640\ufe0f", "Woman Golfing: Medium-Light Skin Tone" }, // 1f3cc-1f3fc-200d-2640-fe0f
            { "\U0001f3cc\U0001f3fd\u200d\u2640\ufe0f", "Woman Golfing: Medium Skin Tone" }, // 1f3cc-1f3fd-200d-2640-fe0f
            { "\U0001f3cc\U0001f3fe\u200d\u2640\ufe0f", "Woman Golfing: Medium-Dark Skin Tone" }, // 1f3cc-1f3fe-200d-2640-fe0f
            { "\U0001f3cc\U0001f3ff\u200d\u2640\ufe0f", "Woman Golfing: Dark Skin Tone" }, // 1f3cc-1f3ff-200d-2640-fe0f
            { "\U0001f3c4", "Person Surfing" }, // 1f3c4
            { "\U0001f3c4\U0001f3fb", "Person Surfing: Light Skin Tone" }, // 1f3c4-1f3fb
            { "\U0001f3c4\U0001f3fc", "Person Surfing: Medium-Light Skin Tone" }, // 1f3c4-1f3fc
            { "\U0001f3c4\U0001f3fd", "Person Surfing: Medium Skin Tone" }, // 1f3c4-1f3fd
            { "\U0001f3c4\U0001f3fe", "Person Surfing: Medium-Dark Skin Tone" }, // 1f3c4-1f3fe
            { "\U0001f3c4\U0001f3ff", "Person Surfing: Dark Skin Tone" }, // 1f3c4-1f3ff
            { "\U0001f3c4\u200d\u2642\ufe0f", "Man Surfing" }, // 1f3c4-200d-2642-fe0f
            { "\U0001f3c4\U0001f3fb\u200d\u2642\ufe0f", "Man Surfing: Light Skin Tone" }, // 1f3c4-1f3fb-200d-2642-fe0f
            { "\U0001f3c4\U0001f3fc\u200d\u2642\ufe0f", "Man Surfing: Medium-Light Skin Tone" }, // 1f3c4-1f3fc-200d-2642-fe0f
            { "\U0001f3c4\U0001f3fd\u200d\u2642\ufe0f", "Man Surfing: Medium Skin Tone" }, // 1f3c4-1f3fd-200d-2642-fe0f
            { "\U0001f3c4\U0001f3fe\u200d\u2642\ufe0f", "Man Surfing: Medium-Dark Skin Tone" }, // 1f3c4-1f3fe-200d-2642-fe0f
            { "\U0001f3c4\U0001f3ff\u200d\u2642\ufe0f", "Man Surfing: Dark Skin Tone" }, // 1f3c4-1f3ff-200d-2642-fe0f
            { "\U0001f3c4\u200d\u2640\ufe0f", "Woman Surfing" }, // 1f3c4-200d-2640-fe0f
            { "\U0001f3c4\U0001f3fb\u200d\u2640\ufe0f", "Woman Surfing: Light Skin Tone" }, // 1f3c4-1f3fb-200d-2640-fe0f
            { "\U0001f3c4\U0001f3fc\u200d\u2640\ufe0f", "Woman Surfing: Medium-Light Skin Tone" }, // 1f3c4-1f3fc-200d-2640-fe0f
            { "\U0001f3c4\U0001f3fd\u200d\u2640\ufe0f", "Woman Surfing: Medium Skin Tone" }, // 1f3c4-1f3fd-200d-2640-fe0f
            { "\U0001f3c4\U0001f3fe\u200d\u2640\ufe0f", "Woman Surfing: Medium-Dark Skin Tone" }, // 1f3c4-1f3fe-200d-2640-fe0f
            { "\U0001f3c4\U0001f3ff\u200d\u2640\ufe0f", "Woman Surfing: Dark Skin Tone" }, // 1f3c4-1f3ff-200d-2640-fe0f
            { "\U0001f6a3", "Person Rowing Boat" }, // 1f6a3
            { "\U0001f6a3\U0001f3fb", "Person Rowing Boat: Light Skin Tone" }, // 1f6a3-1f3fb
            { "\U0001f6a3\U0001f3fc", "Person Rowing Boat: Medium-Light Skin Tone" }, // 1f6a3-1f3fc
            { "\U0001f6a3\U0001f3fd", "Person Rowing Boat: Medium Skin Tone" }, // 1f6a3-1f3fd
            { "\U0001f6a3\U0001f3fe", "Person Rowing Boat: Medium-Dark Skin Tone" }, // 1f6a3-1f3fe
            { "\U0001f6a3\U0001f3ff", "Person Rowing Boat: Dark Skin Tone" }, // 1f6a3-1f3ff
            { "\U0001f6a3\u200d\u2642\ufe0f", "Man Rowing Boat" }, // 1f6a3-200d-2642-fe0f
            { "\U0001f6a3\U0001f3fb\u200d\u2642\ufe0f", "Man Rowing Boat: Light Skin Tone" }, // 1f6a3-1f3fb-200d-2642-fe0f
            { "\U0001f6a3\U0001f3fc\u200d\u2642\ufe0f", "Man Rowing Boat: Medium-Light Skin Tone" }, // 1f6a3-1f3fc-200d-2642-fe0f
            { "\U0001f6a3\U0001f3fd\u200d\u2642\ufe0f", "Man Rowing Boat: Medium Skin Tone" }, // 1f6a3-1f3fd-200d-2642-fe0f
            { "\U0001f6a3\U0001f3fe\u200d\u2642\ufe0f", "Man Rowing Boat: Medium-Dark Skin Tone" }, // 1f6a3-1f3fe-200d-2642-fe0f
            { "\U0001f6a3\U0001f3ff\u200d\u2642\ufe0f", "Man Rowing Boat: Dark Skin Tone" }, // 1f6a3-1f3ff-200d-2642-fe0f
            { "\U0001f6a3\u200d\u2640\ufe0f", "Woman Rowing Boat" }, // 1f6a3-200d-2640-fe0f
            { "\U0001f6a3\U0001f3fb\u200d\u2640\ufe0f", "Woman Rowing Boat: Light Skin Tone" }, // 1f6a3-1f3fb-200d-2640-fe0f
            { "\U0001f6a3\U0001f3fc\u200d\u2640\ufe0f", "Woman Rowing Boat: Medium-Light Skin Tone" }, // 1f6a3-1f3fc-200d-2640-fe0f
            { "\U0001f6a3\U0001f3fd\u200d\u2640\ufe0f", "Woman Rowing Boat: Medium Skin Tone" }, // 1f6a3-1f3fd-200d-2640-fe0f
            { "\U0001f6a3\U0001f3fe\u200d\u2640\ufe0f", "Woman Rowing Boat: Medium-Dark Skin Tone" }, // 1f6a3-1f3fe-200d-2640-fe0f
            { "\U0001f6a3\U0001f3ff\u200d\u2640\ufe0f", "Woman Rowing Boat: Dark Skin Tone" }, // 1f6a3-1f3ff-200d-2640-fe0f
            { "\U0001f3ca", "Person Swimming" }, // 1f3ca
            { "\U0001f3ca\U0001f3fb", "Person Swimming: Light Skin Tone" }, // 1f3ca-1f3fb
            { "\U0001f3ca\U0001f3fc", "Person Swimming: Medium-Light Skin Tone" }, // 1f3ca-1f3fc
            { "\U0001f3ca\U0001f3fd", "Person Swimming: Medium Skin Tone" }, // 1f3ca-1f3fd
            { "\U0001f3ca\U0001f3fe", "Person Swimming: Medium-Dark Skin Tone" }, // 1f3ca-1f3fe
            { "\U0001f3ca\U0001f3ff", "Person Swimming: Dark Skin Tone" }, // 1f3ca-1f3ff
            { "\U0001f3ca\u200d\u2642\ufe0f", "Man Swimming" }, // 1f3ca-200d-2642-fe0f
            { "\U0001f3ca\U0001f3fb\u200d\u2642\ufe0f", "Man Swimming: Light Skin Tone" }, // 1f3ca-1f3fb-200d-2642-fe0f
            { "\U0001f3ca\U0001f3fc\u200d\u2642\ufe0f", "Man Swimming: Medium-Light Skin Tone" }, // 1f3ca-1f3fc-200d-2642-fe0f
            { "\U0001f3ca\U0001f3fd\u200d\u2642\ufe0f", "Man Swimming: Medium Skin Tone" }, // 1f3ca-1f3fd-200d-2642-fe0f
            { "\U0001f3ca\U0001f3fe\u200d\u2642\ufe0f", "Man Swimming: Medium-Dark Skin Tone" }, // 1f3ca-1f3fe-200d-2642-fe0f
            { "\U0001f3ca\U0001f3ff\u200d\u2642\ufe0f", "Man Swimming: Dark Skin Tone" }, // 1f3ca-1f3ff-200d-2642-fe0f
            { "\U0001f3ca\u200d\u2640\ufe0f", "Woman Swimming" }, // 1f3ca-200d-2640-fe0f
            { "\U0001f3ca\U0001f3fb\u200d\u2640\ufe0f", "Woman Swimming: Light Skin Tone" }, // 1f3ca-1f3fb-200d-2640-fe0f
            { "\U0001f3ca\U0001f3fc\u200d\u2640\ufe0f", "Woman Swimming: Medium-Light Skin Tone" }, // 1f3ca-1f3fc-200d-2640-fe0f
            { "\U0001f3ca\U0001f3fd\u200d\u2640\ufe0f", "Woman Swimming: Medium Skin Tone" }, // 1f3ca-1f3fd-200d-2640-fe0f
            { "\U0001f3ca\U0001f3fe\u200d\u2640\ufe0f", "Woman Swimming: Medium-Dark Skin Tone" }, // 1f3ca-1f3fe-200d-2640-fe0f
            { "\U0001f3ca\U0001f3ff\u200d\u2640\ufe0f", "Woman Swimming: Dark Skin Tone" }, // 1f3ca-1f3ff-200d-2640-fe0f
            { "\u26f9", "Person Bouncing Ball" }, // 26f9
            { "\u26f9\U0001f3fb", "Person Bouncing Ball: Light Skin Tone" }, // 26f9-1f3fb
            { "\u26f9\U0001f3fc", "Person Bouncing Ball: Medium-Light Skin Tone" }, // 26f9-1f3fc
            { "\u26f9\U0001f3fd", "Person Bouncing Ball: Medium Skin Tone" }, // 26f9-1f3fd
            { "\u26f9\U0001f3fe", "Person Bouncing Ball: Medium-Dark Skin Tone" }, // 26f9-1f3fe
            { "\u26f9\U0001f3ff", "Person Bouncing Ball: Dark Skin Tone" }, // 26f9-1f3ff
            { "\u26f9\ufe0f\u200d\u2640\ufe0f", "Woman Bouncing Ball" }, // 26f9-fe0f-200d-2640-fe0f
            { "\u26f9\U0001f3fb\u200d\u2640\ufe0f", "Woman Bouncing Ball: Light Skin Tone" }, // 26f9-1f3fb-200d-2640-fe0f
            { "\u26f9\U0001f3fc\u200d\u2640\ufe0f", "Woman Bouncing Ball: Medium-Light Skin Tone" }, // 26f9-1f3fc-200d-2640-fe0f
            { "\u26f9\U0001f3fd\u200d\u2640\ufe0f", "Woman Bouncing Ball: Medium Skin Tone" }, // 26f9-1f3fd-200d-2640-fe0f
            { "\u26f9\U0001f3fe\u200d\u2640\ufe0f", "Woman Bouncing Ball: Medium-Dark Skin Tone" }, // 26f9-1f3fe-200d-2640-fe0f
            { "\u26f9\U0001f3ff\u200d\u2640\ufe0f", "Woman Bouncing Ball: Dark Skin Tone" }, // 26f9-1f3ff-200d-2640-fe0f
            { "\U0001f3cb", "Person Lifting Weights" }, // 1f3cb
            { "\U0001f3cb\U0001f3fb", "Person Lifting Weights: Light Skin Tone" }, // 1f3cb-1f3fb
            { "\U0001f3cb\U0001f3fc", "Person Lifting Weights: Medium-Light Skin Tone" }, // 1f3cb-1f3fc
            { "\U0001f3cb\U0001f3fd", "Person Lifting Weights: Medium Skin Tone" }, // 1f3cb-1f3fd
            { "\U0001f3cb\U0001f3fe", "Person Lifting Weights: Medium-Dark Skin Tone" }, // 1f3cb-1f3fe
            { "\U0001f3cb\U0001f3ff", "Person Lifting Weights: Dark Skin Tone" }, // 1f3cb-1f3ff
            { "\U0001f3cb\ufe0f\u200d\u2642\ufe0f", "Man Lifting Weights" }, // 1f3cb-fe0f-200d-2642-fe0f
            { "\U0001f3cb\U0001f3fb\u200d\u2642\ufe0f", "Man Lifting Weights: Light Skin Tone" }, // 1f3cb-1f3fb-200d-2642-fe0f
            { "\U0001f3cb\U0001f3fc\u200d\u2642\ufe0f", "Man Lifting Weights: Medium-Light Skin Tone" }, // 1f3cb-1f3fc-200d-2642-fe0f
            { "\U0001f3cb\U0001f3fd\u200d\u2642\ufe0f", "Man Lifting Weights: Medium Skin Tone" }, // 1f3cb-1f3fd-200d-2642-fe0f
            { "\U0001f3cb\U0001f3fe\u200d\u2642\ufe0f", "Man Lifting Weights: Medium-Dark Skin Tone" }, // 1f3cb-1f3fe-200d-2642-fe0f
            { "\U0001f3cb\U0001f3ff\u200d\u2642\ufe0f", "Man Lifting Weights: Dark Skin Tone" }, // 1f3cb-1f3ff-200d-2642-fe0f
            { "\U0001f3cb\ufe0f\u200d\u2640\ufe0f", "Woman Lifting Weights" }, // 1f3cb-fe0f-200d-2640-fe0f
            { "\U0001f3cb\U0001f3fb\u200d\u2640\ufe0f", "Woman Lifting Weights: Light Skin Tone" }, // 1f3cb-1f3fb-200d-2640-fe0f
            { "\U0001f3cb\U0001f3fc\u200d\u2640\ufe0f", "Woman Lifting Weights: Medium-Light Skin Tone" }, // 1f3cb-1f3fc-200d-2640-fe0f
            { "\U0001f3cb\U0001f3fd\u200d\u2640\ufe0f", "Woman Lifting Weights: Medium Skin Tone" }, // 1f3cb-1f3fd-200d-2640-fe0f
            { "\U0001f3cb\U0001f3fe\u200d\u2640\ufe0f", "Woman Lifting Weights: Medium-Dark Skin Tone" }, // 1f3cb-1f3fe-200d-2640-fe0f
            { "\U0001f3cb\U0001f3ff\u200d\u2640\ufe0f", "Woman Lifting Weights: Dark Skin Tone" }, // 1f3cb-1f3ff-200d-2640-fe0f
            { "\U0001f6b4", "Person Biking" }, // 1f6b4
            { "\U0001f6b4\U0001f3fb", "Person Biking: Light Skin Tone" }, // 1f6b4-1f3fb
            { "\U0001f6b4\U0001f3fc", "Person Biking: Medium-Light Skin Tone" }, // 1f6b4-1f3fc
            { "\U0001f6b4\U0001f3fd", "Person Biking: Medium Skin Tone" }, // 1f6b4-1f3fd
            { "\U0001f6b4\U0001f3fe", "Person Biking: Medium-Dark Skin Tone" }, // 1f6b4-1f3fe
            { "\U0001f6b4\U0001f3ff", "Person Biking: Dark Skin Tone" }, // 1f6b4-1f3ff
            { "\U0001f6b4\u200d\u2642\ufe0f", "Man Biking" }, // 1f6b4-200d-2642-fe0f
            { "\U0001f6b4\U0001f3fb\u200d\u2642\ufe0f", "Man Biking: Light Skin Tone" }, // 1f6b4-1f3fb-200d-2642-fe0f
            { "\U0001f6b4\U0001f3fc\u200d\u2642\ufe0f", "Man Biking: Medium-Light Skin Tone" }, // 1f6b4-1f3fc-200d-2642-fe0f
            { "\U0001f6b4\U0001f3fd\u200d\u2642\ufe0f", "Man Biking: Medium Skin Tone" }, // 1f6b4-1f3fd-200d-2642-fe0f
            { "\U0001f6b4\U0001f3fe\u200d\u2642\ufe0f", "Man Biking: Medium-Dark Skin Tone" }, // 1f6b4-1f3fe-200d-2642-fe0f
            { "\U0001f6b4\U0001f3ff\u200d\u2642\ufe0f", "Man Biking: Dark Skin Tone" }, // 1f6b4-1f3ff-200d-2642-fe0f
            { "\U0001f6b4\u200d\u2640\ufe0f", "Woman Biking" }, // 1f6b4-200d-2640-fe0f
            { "\U0001f6b4\U0001f3fb\u200d\u2640\ufe0f", "Woman Biking: Light Skin Tone" }, // 1f6b4-1f3fb-200d-2640-fe0f
            { "\U0001f6b4\U0001f3fc\u200d\u2640\ufe0f", "Woman Biking: Medium-Light Skin Tone" }, // 1f6b4-1f3fc-200d-2640-fe0f
            { "\U0001f6b4\U0001f3fd\u200d\u2640\ufe0f", "Woman Biking: Medium Skin Tone" }, // 1f6b4-1f3fd-200d-2640-fe0f
            { "\U0001f6b4\U0001f3fe\u200d\u2640\ufe0f", "Woman Biking: Medium-Dark Skin Tone" }, // 1f6b4-1f3fe-200d-2640-fe0f
            { "\U0001f6b4\U0001f3ff\u200d\u2640\ufe0f", "Woman Biking: Dark Skin Tone" }, // 1f6b4-1f3ff-200d-2640-fe0f
            { "\U0001f6b5", "Person Mountain Biking" }, // 1f6b5
            { "\U0001f6b5\U0001f3fb", "Person Mountain Biking: Light Skin Tone" }, // 1f6b5-1f3fb
            { "\U0001f6b5\U0001f3fc", "Person Mountain Biking: Medium-Light Skin Tone" }, // 1f6b5-1f3fc
            { "\U0001f6b5\U0001f3fd", "Person Mountain Biking: Medium Skin Tone" }, // 1f6b5-1f3fd
            { "\U0001f6b5\U0001f3fe", "Person Mountain Biking: Medium-Dark Skin Tone" }, // 1f6b5-1f3fe
            { "\U0001f6b5\U0001f3ff", "Person Mountain Biking: Dark Skin Tone" }, // 1f6b5-1f3ff
            { "\U0001f6b5\u200d\u2642\ufe0f", "Man Mountain Biking" }, // 1f6b5-200d-2642-fe0f
            { "\U0001f6b5\U0001f3fb\u200d\u2642\ufe0f", "Man Mountain Biking: Light Skin Tone" }, // 1f6b5-1f3fb-200d-2642-fe0f
            { "\U0001f6b5\U0001f3fc\u200d\u2642\ufe0f", "Man Mountain Biking: Medium-Light Skin Tone" }, // 1f6b5-1f3fc-200d-2642-fe0f
            { "\U0001f6b5\U0001f3fd\u200d\u2642\ufe0f", "Man Mountain Biking: Medium Skin Tone" }, // 1f6b5-1f3fd-200d-2642-fe0f
            { "\U0001f6b5\U0001f3fe\u200d\u2642\ufe0f", "Man Mountain Biking: Medium-Dark Skin Tone" }, // 1f6b5-1f3fe-200d-2642-fe0f
            { "\U0001f6b5\U0001f3ff\u200d\u2642\ufe0f", "Man Mountain Biking: Dark Skin Tone" }, // 1f6b5-1f3ff-200d-2642-fe0f
            { "\U0001f6b5\u200d\u2640\ufe0f", "Woman Mountain Biking" }, // 1f6b5-200d-2640-fe0f
            { "\U0001f6b5\U0001f3fb\u200d\u2640\ufe0f", "Woman Mountain Biking: Light Skin Tone" }, // 1f6b5-1f3fb-200d-2640-fe0f
            { "\U0001f6b5\U0001f3fc\u200d\u2640\ufe0f", "Woman Mountain Biking: Medium-Light Skin Tone" }, // 1f6b5-1f3fc-200d-2640-fe0f
            { "\U0001f6b5\U0001f3fd\u200d\u2640\ufe0f", "Woman Mountain Biking: Medium Skin Tone" }, // 1f6b5-1f3fd-200d-2640-fe0f
            { "\U0001f6b5\U0001f3fe\u200d\u2640\ufe0f", "Woman Mountain Biking: Medium-Dark Skin Tone" }, // 1f6b5-1f3fe-200d-2640-fe0f
            { "\U0001f6b5\U0001f3ff\u200d\u2640\ufe0f", "Woman Mountain Biking: Dark Skin Tone" }, // 1f6b5-1f3ff-200d-2640-fe0f
            { "\U0001f3ce", "Racing Car" }, // 1f3ce
            { "\U0001f3cd", "Motorcycle" }, // 1f3cd
            { "\U0001f938", "Person Cartwheeling" }, // 1f938
            { "\U0001f938\U0001f3fb", "Person Cartwheeling: Light Skin Tone" }, // 1f938-1f3fb
            { "\U0001f938\U0001f3fc", "Person Cartwheeling: Medium-Light Skin Tone" }, // 1f938-1f3fc
            { "\U0001f938\U0001f3fd", "Person Cartwheeling: Medium Skin Tone" }, // 1f938-1f3fd
            { "\U0001f938\U0001f3fe", "Person Cartwheeling: Medium-Dark Skin Tone" }, // 1f938-1f3fe
            { "\U0001f938\U0001f3ff", "Person Cartwheeling: Dark Skin Tone" }, // 1f938-1f3ff
            { "\U0001f938\u200d\u2642\ufe0f", "Man Cartwheeling" }, // 1f938-200d-2642-fe0f
            { "\U0001f938\U0001f3fb\u200d\u2642\ufe0f", "Man Cartwheeling: Light Skin Tone" }, // 1f938-1f3fb-200d-2642-fe0f
            { "\U0001f938\U0001f3fc\u200d\u2642\ufe0f", "Man Cartwheeling: Medium-Light Skin Tone" }, // 1f938-1f3fc-200d-2642-fe0f
            { "\U0001f938\U0001f3fd\u200d\u2642\ufe0f", "Man Cartwheeling: Medium Skin Tone" }, // 1f938-1f3fd-200d-2642-fe0f
            { "\U0001f938\U0001f3fe\u200d\u2642\ufe0f", "Man Cartwheeling: Medium-Dark Skin Tone" }, // 1f938-1f3fe-200d-2642-fe0f
            { "\U0001f938\U0001f3ff\u200d\u2642\ufe0f", "Man Cartwheeling: Dark Skin Tone" }, // 1f938-1f3ff-200d-2642-fe0f
            { "\U0001f93c", "People Wrestling" }, // 1f93c
            { "\U0001f93c\u200d\u2642\ufe0f", "Men Wrestling" }, // 1f93c-200d-2642-fe0f
            { "\U0001f93c\u200d\u2640\ufe0f", "Women Wrestling" }, // 1f93c-200d-2640-fe0f
            { "\U0001f93d", "Person Playing Water Polo" }, // 1f93d
            { "\U0001f93d\U0001f3fb", "Person Playing Water Polo: Light Skin Tone" }, // 1f93d-1f3fb
            { "\U0001f93d\U0001f3fc", "Person Playing Water Polo: Medium-Light Skin Tone" }, // 1f93d-1f3fc
            { "\U0001f93d\U0001f3fd", "Person Playing Water Polo: Medium Skin Tone" }, // 1f93d-1f3fd
            { "\U0001f93d\U0001f3fe", "Person Playing Water Polo: Medium-Dark Skin Tone" }, // 1f93d-1f3fe
            { "\U0001f93d\U0001f3ff", "Person Playing Water Polo: Dark Skin Tone" }, // 1f93d-1f3ff
            { "\U0001f93d\u200d\u2640\ufe0f", "Woman Playing Water Polo" }, // 1f93d-200d-2640-fe0f
            { "\U0001f93d\U0001f3fb\u200d\u2640\ufe0f", "Woman Playing Water Polo: Light Skin Tone" }, // 1f93d-1f3fb-200d-2640-fe0f
            { "\U0001f93d\U0001f3fc\u200d\u2640\ufe0f", "Woman Playing Water Polo: Medium-Light Skin Tone" }, // 1f93d-1f3fc-200d-2640-fe0f
            { "\U0001f93d\U0001f3fd\u200d\u2640\ufe0f", "Woman Playing Water Polo: Medium Skin Tone" }, // 1f93d-1f3fd-200d-2640-fe0f
            { "\U0001f93d\U0001f3fe\u200d\u2640\ufe0f", "Woman Playing Water Polo: Medium-Dark Skin Tone" }, // 1f93d-1f3fe-200d-2640-fe0f
            { "\U0001f93d\U0001f3ff\u200d\u2640\ufe0f", "Woman Playing Water Polo: Dark Skin Tone" }, // 1f93d-1f3ff-200d-2640-fe0f
            { "\U0001f93e", "Person Playing Handball" }, // 1f93e
            { "\U0001f93e\U0001f3fb", "Person Playing Handball: Light Skin Tone" }, // 1f93e-1f3fb
            { "\U0001f93e\U0001f3fc", "Person Playing Handball: Medium-Light Skin Tone" }, // 1f93e-1f3fc
            { "\U0001f93e\U0001f3fd", "Person Playing Handball: Medium Skin Tone" }, // 1f93e-1f3fd
            { "\U0001f93e\U0001f3fe", "Person Playing Handball: Medium-Dark Skin Tone" }, // 1f93e-1f3fe
            { "\U0001f93e\U0001f3ff", "Person Playing Handball: Dark Skin Tone" }, // 1f93e-1f3ff
            { "\U0001f93e\u200d\u2642\ufe0f", "Man Playing Handball" }, // 1f93e-200d-2642-fe0f
            { "\U0001f93e\U0001f3fb\u200d\u2642\ufe0f", "Man Playing Handball: Light Skin Tone" }, // 1f93e-1f3fb-200d-2642-fe0f
            { "\U0001f93e\U0001f3fc\u200d\u2642\ufe0f", "Man Playing Handball: Medium-Light Skin Tone" }, // 1f93e-1f3fc-200d-2642-fe0f
            { "\U0001f93e\U0001f3fd\u200d\u2642\ufe0f", "Man Playing Handball: Medium Skin Tone" }, // 1f93e-1f3fd-200d-2642-fe0f
            { "\U0001f93e\U0001f3fe\u200d\u2642\ufe0f", "Man Playing Handball: Medium-Dark Skin Tone" }, // 1f93e-1f3fe-200d-2642-fe0f
            { "\U0001f93e\U0001f3ff\u200d\u2642\ufe0f", "Man Playing Handball: Dark Skin Tone" }, // 1f93e-1f3ff-200d-2642-fe0f
            { "\U0001f93e\u200d\u2640\ufe0f", "Woman Playing Handball" }, // 1f93e-200d-2640-fe0f
            { "\U0001f93e\U0001f3fb\u200d\u2640\ufe0f", "Woman Playing Handball: Light Skin Tone" }, // 1f93e-1f3fb-200d-2640-fe0f
            { "\U0001f93e\U0001f3fc\u200d\u2640\ufe0f", "Woman Playing Handball: Medium-Light Skin Tone" }, // 1f93e-1f3fc-200d-2640-fe0f
            { "\U0001f93e\U0001f3fd\u200d\u2640\ufe0f", "Woman Playing Handball: Medium Skin Tone" }, // 1f93e-1f3fd-200d-2640-fe0f
            { "\U0001f93e\U0001f3fe\u200d\u2640\ufe0f", "Woman Playing Handball: Medium-Dark Skin Tone" }, // 1f93e-1f3fe-200d-2640-fe0f
            { "\U0001f93e\U0001f3ff\u200d\u2640\ufe0f", "Woman Playing Handball: Dark Skin Tone" }, // 1f93e-1f3ff-200d-2640-fe0f
            { "\U0001f939", "Person Juggling" }, // 1f939
            { "\U0001f939\U0001f3fb", "Person Juggling: Light Skin Tone" }, // 1f939-1f3fb
            { "\U0001f939\U0001f3fc", "Person Juggling: Medium-Light Skin Tone" }, // 1f939-1f3fc
            { "\U0001f939\U0001f3fd", "Person Juggling: Medium Skin Tone" }, // 1f939-1f3fd
            { "\U0001f939\U0001f3fe", "Person Juggling: Medium-Dark Skin Tone" }, // 1f939-1f3fe
            { "\U0001f939\U0001f3ff", "Person Juggling: Dark Skin Tone" }, // 1f939-1f3ff
            { "\U0001f939\u200d\u2642\ufe0f", "Man Juggling" }, // 1f939-200d-2642-fe0f
            { "\U0001f939\U0001f3fb\u200d\u2642\ufe0f", "Man Juggling: Light Skin Tone" }, // 1f939-1f3fb-200d-2642-fe0f
            { "\U0001f939\U0001f3fc\u200d\u2642\ufe0f", "Man Juggling: Medium-Light Skin Tone" }, // 1f939-1f3fc-200d-2642-fe0f
            { "\U0001f939\U0001f3fd\u200d\u2642\ufe0f", "Man Juggling: Medium Skin Tone" }, // 1f939-1f3fd-200d-2642-fe0f
            { "\U0001f939\U0001f3fe\u200d\u2642\ufe0f", "Man Juggling: Medium-Dark Skin Tone" }, // 1f939-1f3fe-200d-2642-fe0f
            { "\U0001f939\U0001f3ff\u200d\u2642\ufe0f", "Man Juggling: Dark Skin Tone" }, // 1f939-1f3ff-200d-2642-fe0f
            { "\U0001f939\u200d\u2640\ufe0f", "Woman Juggling" }, // 1f939-200d-2640-fe0f
            { "\U0001f939\U0001f3fb\u200d\u2640\ufe0f", "Woman Juggling: Light Skin Tone" }, // 1f939-1f3fb-200d-2640-fe0f
            { "\U0001f939\U0001f3fc\u200d\u2640\ufe0f", "Woman Juggling: Medium-Light Skin Tone" }, // 1f939-1f3fc-200d-2640-fe0f
            { "\U0001f939\U0001f3fd\u200d\u2640\ufe0f", "Woman Juggling: Medium Skin Tone" }, // 1f939-1f3fd-200d-2640-fe0f
            { "\U0001f939\U0001f3fe\u200d\u2640\ufe0f", "Woman Juggling: Medium-Dark Skin Tone" }, // 1f939-1f3fe-200d-2640-fe0f
            { "\U0001f939\U0001f3ff\u200d\u2640\ufe0f", "Woman Juggling: Dark Skin Tone" }, // 1f939-1f3ff-200d-2640-fe0f
            { "\U0001f93c\U0001f3fb", "Wrestlers, Type-1-2" }, // 1f93c-1f3fb
            { "\U0001f93c\U0001f3fc", "Wrestlers, Type-3" }, // 1f93c-1f3fc
            { "\U0001f46b", "Man and Woman Holding Hands" }, // 1f46b
            { "\U0001f93c\U0001f3fd", "Wrestlers, Type-4" }, // 1f93c-1f3fd
            { "\U0001f46c", "Two Men Holding Hands" }, // 1f46c
            { "\U0001f93c\U0001f3fe", "Wrestlers, Type-5" }, // 1f93c-1f3fe
            { "\U0001f46d", "Two Women Holding Hands" }, // 1f46d
            { "\U0001f93c\U0001f3ff", "Wrestlers, Type-6" }, // 1f93c-1f3ff
            { "\U0001f48f", "Kiss" }, // 1f48f
            { "\U0001f93c\U0001f3fb\u200d\u2642\ufe0f", "Men Wrestling, Type-1-2" }, // 1f93c-1f3fb-200d-2642-fe0f
            { "\U0001f469\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468", "Kiss: Woman, Man" }, // 1f469-200d-2764-fe0f-200d-1f48b-200d-1f468
            { "\U0001f93c\U0001f3fc\u200d\u2642\ufe0f", "Men Wrestling, Type-3" }, // 1f93c-1f3fc-200d-2642-fe0f
            { "\U0001f93c\U0001f3fd\u200d\u2642\ufe0f", "Men Wrestling, Type-4" }, // 1f93c-1f3fd-200d-2642-fe0f
            { "\U0001f468\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468", "Kiss: Man, Man" }, // 1f468-200d-2764-fe0f-200d-1f48b-200d-1f468
            { "\U0001f93c\U0001f3fe\u200d\u2642\ufe0f", "Men Wrestling, Type-5" }, // 1f93c-1f3fe-200d-2642-fe0f
            { "\U0001f469\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469", "Kiss: Woman, Woman" }, // 1f469-200d-2764-fe0f-200d-1f48b-200d-1f469
            { "\U0001f93c\U0001f3ff\u200d\u2642\ufe0f", "Men Wrestling, Type-6" }, // 1f93c-1f3ff-200d-2642-fe0f
            { "\U0001f491", "Couple With Heart" }, // 1f491
            { "\U0001f93c\U0001f3fb\u200d\u2640\ufe0f", "Women Wrestling, Type-1-2" }, // 1f93c-1f3fb-200d-2640-fe0f
            { "\U0001f469\u200d\u2764\ufe0f\u200d\U0001f468", "Couple With Heart: Woman, Man" }, // 1f469-200d-2764-fe0f-200d-1f468
            { "\U0001f93c\U0001f3fc\u200d\u2640\ufe0f", "Women Wrestling, Type-3" }, // 1f93c-1f3fc-200d-2640-fe0f
            { "\U0001f93c\U0001f3fd\u200d\u2640\ufe0f", "Women Wrestling, Type-4" }, // 1f93c-1f3fd-200d-2640-fe0f
            { "\U0001f93c\U0001f3fe\u200d\u2640\ufe0f", "Women Wrestling, Type-5" }, // 1f93c-1f3fe-200d-2640-fe0f
            { "\U0001f468\u200d\u2764\ufe0f\u200d\U0001f468", "Couple With Heart: Man, Man" }, // 1f468-200d-2764-fe0f-200d-1f468
            { "\U0001f93c\U0001f3ff\u200d\u2640\ufe0f", "Women Wrestling, Type-6" }, // 1f93c-1f3ff-200d-2640-fe0f
            { "\U0001f469\u200d\u2764\ufe0f\u200d\U0001f469", "Couple With Heart: Woman, Woman" }, // 1f469-200d-2764-fe0f-200d-1f469
            { "\U0001f46a", "Family" }, // 1f46a
            { "\U0001f468\u200d\U0001f469\u200d\U0001f466", "Family: Man, Woman, Boy" }, // 1f468-200d-1f469-200d-1f466
            { "\U0001f468\u200d\U0001f469\u200d\U0001f467", "Family: Man, Woman, Girl" }, // 1f468-200d-1f469-200d-1f467
            { "\U0001f468\u200d\U0001f469\u200d\U0001f467\u200d\U0001f466", "Family: Man, Woman, Girl, Boy" }, // 1f468-200d-1f469-200d-1f467-200d-1f466
            { "\U0001f468\u200d\U0001f469\u200d\U0001f466\u200d\U0001f466", "Family: Man, Woman, Boy, Boy" }, // 1f468-200d-1f469-200d-1f466-200d-1f466
            { "\U0001f468\u200d\U0001f469\u200d\U0001f467\u200d\U0001f467", "Family: Man, Woman, Girl, Girl" }, // 1f468-200d-1f469-200d-1f467-200d-1f467
            { "\U0001f468\u200d\U0001f468\u200d\U0001f466", "Family: Man, Man, Boy" }, // 1f468-200d-1f468-200d-1f466
            { "\U0001f468\u200d\U0001f468\u200d\U0001f467", "Family: Man, Man, Girl" }, // 1f468-200d-1f468-200d-1f467
            { "\U0001f468\u200d\U0001f468\u200d\U0001f467\u200d\U0001f466", "Family: Man, Man, Girl, Boy" }, // 1f468-200d-1f468-200d-1f467-200d-1f466
            { "\U0001f468\u200d\U0001f468\u200d\U0001f466\u200d\U0001f466", "Family: Man, Man, Boy, Boy" }, // 1f468-200d-1f468-200d-1f466-200d-1f466
            { "\U0001f468\u200d\U0001f468\u200d\U0001f467\u200d\U0001f467", "Family: Man, Man, Girl, Girl" }, // 1f468-200d-1f468-200d-1f467-200d-1f467
            { "\U0001f469\u200d\U0001f469\u200d\U0001f466", "Family: Woman, Woman, Boy" }, // 1f469-200d-1f469-200d-1f466
            { "\U0001f469\u200d\U0001f469\u200d\U0001f467", "Family: Woman, Woman, Girl" }, // 1f469-200d-1f469-200d-1f467
            { "\U0001f469\u200d\U0001f469\u200d\U0001f467\u200d\U0001f466", "Family: Woman, Woman, Girl, Boy" }, // 1f469-200d-1f469-200d-1f467-200d-1f466
            { "\U0001f469\u200d\U0001f469\u200d\U0001f466\u200d\U0001f466", "Family: Woman, Woman, Boy, Boy" }, // 1f469-200d-1f469-200d-1f466-200d-1f466
            { "\U0001f469\u200d\U0001f469\u200d\U0001f467\u200d\U0001f467", "Family: Woman, Woman, Girl, Girl" }, // 1f469-200d-1f469-200d-1f467-200d-1f467
            { "\U0001f468\u200d\U0001f466", "Family: Man, Boy" }, // 1f468-200d-1f466
            { "\U0001f468\u200d\U0001f466\u200d\U0001f466", "Family: Man, Boy, Boy" }, // 1f468-200d-1f466-200d-1f466
            { "\U0001f468\u200d\U0001f467", "Family: Man, Girl" }, // 1f468-200d-1f467
            { "\U0001f468\u200d\U0001f467\u200d\U0001f466", "Family: Man, Girl, Boy" }, // 1f468-200d-1f467-200d-1f466
            { "\U0001f468\u200d\U0001f467\u200d\U0001f467", "Family: Man, Girl, Girl" }, // 1f468-200d-1f467-200d-1f467
            { "\U0001f469\u200d\U0001f466", "Family: Woman, Boy" }, // 1f469-200d-1f466
            { "\U0001f469\u200d\U0001f466\u200d\U0001f466", "Family: Woman, Boy, Boy" }, // 1f469-200d-1f466-200d-1f466
            { "\U0001f469\u200d\U0001f467", "Family: Woman, Girl" }, // 1f469-200d-1f467
            { "\U0001f469\u200d\U0001f467\u200d\U0001f466", "Family: Woman, Girl, Boy" }, // 1f469-200d-1f467-200d-1f466
            { "\U0001f469\u200d\U0001f467\u200d\U0001f467", "Family: Woman, Girl, Girl" }, // 1f469-200d-1f467-200d-1f467
            { "\U0001f933", "Selfie" }, // 1f933
            { "\U0001f933\U0001f3fb", "Selfie: Light Skin Tone" }, // 1f933-1f3fb
            { "\U0001f933\U0001f3fc", "Selfie: Medium-Light Skin Tone" }, // 1f933-1f3fc
            { "\U0001f933\U0001f3fd", "Selfie: Medium Skin Tone" }, // 1f933-1f3fd
            { "\U0001f933\U0001f3fe", "Selfie: Medium-Dark Skin Tone" }, // 1f933-1f3fe
            { "\U0001f933\U0001f3ff", "Selfie: Dark Skin Tone" }, // 1f933-1f3ff
            { "\U0001f4aa", "Flexed Biceps" }, // 1f4aa
            { "\U0001f4aa\U0001f3fb", "Flexed Biceps: Light Skin Tone" }, // 1f4aa-1f3fb
            { "\U0001f4aa\U0001f3fc", "Flexed Biceps: Medium-Light Skin Tone" }, // 1f4aa-1f3fc
            { "\U0001f4aa\U0001f3fd", "Flexed Biceps: Medium Skin Tone" }, // 1f4aa-1f3fd
            { "\U0001f4aa\U0001f3fe", "Flexed Biceps: Medium-Dark Skin Tone" }, // 1f4aa-1f3fe
            { "\U0001f4aa\U0001f3ff", "Flexed Biceps: Dark Skin Tone" }, // 1f4aa-1f3ff
            { "\U0001f448", "Backhand Index Pointing Left" }, // 1f448
            { "\U0001f448\U0001f3fb", "Backhand Index Pointing Left: Light Skin Tone" }, // 1f448-1f3fb
            { "\U0001f448\U0001f3fc", "Backhand Index Pointing Left: Medium-Light Skin Tone" }, // 1f448-1f3fc
            { "\U0001f448\U0001f3fd", "Backhand Index Pointing Left: Medium Skin Tone" }, // 1f448-1f3fd
            { "\U0001f448\U0001f3fe", "Backhand Index Pointing Left: Medium-Dark Skin Tone" }, // 1f448-1f3fe
            { "\U0001f448\U0001f3ff", "Backhand Index Pointing Left: Dark Skin Tone" }, // 1f448-1f3ff
            { "\U0001f449", "Backhand Index Pointing Right" }, // 1f449
            { "\U0001f449\U0001f3fb", "Backhand Index Pointing Right: Light Skin Tone" }, // 1f449-1f3fb
            { "\U0001f449\U0001f3fc", "Backhand Index Pointing Right: Medium-Light Skin Tone" }, // 1f449-1f3fc
            { "\U0001f449\U0001f3fd", "Backhand Index Pointing Right: Medium Skin Tone" }, // 1f449-1f3fd
            { "\U0001f449\U0001f3fe", "Backhand Index Pointing Right: Medium-Dark Skin Tone" }, // 1f449-1f3fe
            { "\U0001f449\U0001f3ff", "Backhand Index Pointing Right: Dark Skin Tone" }, // 1f449-1f3ff
            { "\u261d", "Index Pointing Up" }, // 261d
            { "\u261d\U0001f3fb", "Index Pointing Up: Light Skin Tone" }, // 261d-1f3fb
            { "\u261d\U0001f3fc", "Index Pointing Up: Medium-Light Skin Tone" }, // 261d-1f3fc
            { "\u261d\U0001f3fd", "Index Pointing Up: Medium Skin Tone" }, // 261d-1f3fd
            { "\u261d\U0001f3fe", "Index Pointing Up: Medium-Dark Skin Tone" }, // 261d-1f3fe
            { "\u261d\U0001f3ff", "Index Pointing Up: Dark Skin Tone" }, // 261d-1f3ff
            { "\U0001f446", "Backhand Index Pointing Up" }, // 1f446
            { "\U0001f446\U0001f3fb", "Backhand Index Pointing Up: Light Skin Tone" }, // 1f446-1f3fb
            { "\U0001f446\U0001f3fc", "Backhand Index Pointing Up: Medium-Light Skin Tone" }, // 1f446-1f3fc
            { "\U0001f446\U0001f3fd", "Backhand Index Pointing Up: Medium Skin Tone" }, // 1f446-1f3fd
            { "\U0001f446\U0001f3fe", "Backhand Index Pointing Up: Medium-Dark Skin Tone" }, // 1f446-1f3fe
            { "\U0001f446\U0001f3ff", "Backhand Index Pointing Up: Dark Skin Tone" }, // 1f446-1f3ff
            { "\U0001f595", "Middle Finger" }, // 1f595
            { "\U0001f595\U0001f3fb", "Middle Finger: Light Skin Tone" }, // 1f595-1f3fb
            { "\U0001f595\U0001f3fc", "Middle Finger: Medium-Light Skin Tone" }, // 1f595-1f3fc
            { "\U0001f595\U0001f3fd", "Middle Finger: Medium Skin Tone" }, // 1f595-1f3fd
            { "\U0001f595\U0001f3fe", "Middle Finger: Medium-Dark Skin Tone" }, // 1f595-1f3fe
            { "\U0001f595\U0001f3ff", "Middle Finger: Dark Skin Tone" }, // 1f595-1f3ff
            { "\U0001f447", "Backhand Index Pointing Down" }, // 1f447
            { "\U0001f447\U0001f3fb", "Backhand Index Pointing Down: Light Skin Tone" }, // 1f447-1f3fb
            { "\U0001f447\U0001f3fc", "Backhand Index Pointing Down: Medium-Light Skin Tone" }, // 1f447-1f3fc
            { "\U0001f447\U0001f3fd", "Backhand Index Pointing Down: Medium Skin Tone" }, // 1f447-1f3fd
            { "\U0001f447\U0001f3fe", "Backhand Index Pointing Down: Medium-Dark Skin Tone" }, // 1f447-1f3fe
            { "\U0001f447\U0001f3ff", "Backhand Index Pointing Down: Dark Skin Tone" }, // 1f447-1f3ff
            { "\u270c", "Victory Hand" }, // 270c
            { "\u270c\U0001f3fb", "Victory Hand: Light Skin Tone" }, // 270c-1f3fb
            { "\u270c\U0001f3fc", "Victory Hand: Medium-Light Skin Tone" }, // 270c-1f3fc
            { "\u270c\U0001f3fd", "Victory Hand: Medium Skin Tone" }, // 270c-1f3fd
            { "\u270c\U0001f3fe", "Victory Hand: Medium-Dark Skin Tone" }, // 270c-1f3fe
            { "\u270c\U0001f3ff", "Victory Hand: Dark Skin Tone" }, // 270c-1f3ff
            { "\U0001f91e", "Crossed Fingers" }, // 1f91e
            { "\U0001f91e\U0001f3fb", "Crossed Fingers: Light Skin Tone" }, // 1f91e-1f3fb
            { "\U0001f91e\U0001f3fc", "Crossed Fingers: Medium-Light Skin Tone" }, // 1f91e-1f3fc
            { "\U0001f91e\U0001f3fd", "Crossed Fingers: Medium Skin Tone" }, // 1f91e-1f3fd
            { "\U0001f91e\U0001f3fe", "Crossed Fingers: Medium-Dark Skin Tone" }, // 1f91e-1f3fe
            { "\U0001f91e\U0001f3ff", "Crossed Fingers: Dark Skin Tone" }, // 1f91e-1f3ff
            { "\U0001f596", "Vulcan Salute" }, // 1f596
            { "\U0001f596\U0001f3fb", "Vulcan Salute: Light Skin Tone" }, // 1f596-1f3fb
            { "\U0001f596\U0001f3fc", "Vulcan Salute: Medium-Light Skin Tone" }, // 1f596-1f3fc
            { "\U0001f596\U0001f3fd", "Vulcan Salute: Medium Skin Tone" }, // 1f596-1f3fd
            { "\U0001f596\U0001f3fe", "Vulcan Salute: Medium-Dark Skin Tone" }, // 1f596-1f3fe
            { "\U0001f596\U0001f3ff", "Vulcan Salute: Dark Skin Tone" }, // 1f596-1f3ff
            { "\U0001f918", "Sign of the Horns" }, // 1f918
            { "\U0001f918\U0001f3fb", "Sign of the Horns: Light Skin Tone" }, // 1f918-1f3fb
            { "\U0001f918\U0001f3fc", "Sign of the Horns: Medium-Light Skin Tone" }, // 1f918-1f3fc
            { "\U0001f918\U0001f3fd", "Sign of the Horns: Medium Skin Tone" }, // 1f918-1f3fd
            { "\U0001f918\U0001f3fe", "Sign of the Horns: Medium-Dark Skin Tone" }, // 1f918-1f3fe
            { "\U0001f918\U0001f3ff", "Sign of the Horns: Dark Skin Tone" }, // 1f918-1f3ff
            { "\U0001f919", "Call Me Hand" }, // 1f919
            { "\U0001f919\U0001f3fb", "Call Me Hand: Light Skin Tone" }, // 1f919-1f3fb
            { "\U0001f919\U0001f3fc", "Call Me Hand: Medium-Light Skin Tone" }, // 1f919-1f3fc
            { "\U0001f919\U0001f3fd", "Call Me Hand: Medium Skin Tone" }, // 1f919-1f3fd
            { "\U0001f919\U0001f3fe", "Call Me Hand: Medium-Dark Skin Tone" }, // 1f919-1f3fe
            { "\U0001f919\U0001f3ff", "Call Me Hand: Dark Skin Tone" }, // 1f919-1f3ff
            { "\U0001f590", "Raised Hand With Fingers Splayed" }, // 1f590
            { "\U0001f590\U0001f3fb", "Raised Hand With Fingers Splayed: Light Skin Tone" }, // 1f590-1f3fb
            { "\U0001f590\U0001f3fc", "Raised Hand With Fingers Splayed: Medium-Light Skin Tone" }, // 1f590-1f3fc
            { "\U0001f590\U0001f3fd", "Raised Hand With Fingers Splayed: Medium Skin Tone" }, // 1f590-1f3fd
            { "\U0001f590\U0001f3fe", "Raised Hand With Fingers Splayed: Medium-Dark Skin Tone" }, // 1f590-1f3fe
            { "\U0001f590\U0001f3ff", "Raised Hand With Fingers Splayed: Dark Skin Tone" }, // 1f590-1f3ff
            { "\u270b", "Raised Hand" }, // 270b
            { "\u270b\U0001f3fb", "Raised Hand: Light Skin Tone" }, // 270b-1f3fb
            { "\u270b\U0001f3fc", "Raised Hand: Medium-Light Skin Tone" }, // 270b-1f3fc
            { "\u270b\U0001f3fd", "Raised Hand: Medium Skin Tone" }, // 270b-1f3fd
            { "\u270b\U0001f3fe", "Raised Hand: Medium-Dark Skin Tone" }, // 270b-1f3fe
            { "\u270b\U0001f3ff", "Raised Hand: Dark Skin Tone" }, // 270b-1f3ff
            { "\U0001f44c", "OK Hand" }, // 1f44c
            { "\U0001f44c\U0001f3fb", "OK Hand: Light Skin Tone" }, // 1f44c-1f3fb
            { "\U0001f44c\U0001f3fc", "OK Hand: Medium-Light Skin Tone" }, // 1f44c-1f3fc
            { "\U0001f44c\U0001f3fd", "OK Hand: Medium Skin Tone" }, // 1f44c-1f3fd
            { "\U0001f44c\U0001f3fe", "OK Hand: Medium-Dark Skin Tone" }, // 1f44c-1f3fe
            { "\U0001f44c\U0001f3ff", "OK Hand: Dark Skin Tone" }, // 1f44c-1f3ff
            { "\U0001f44d", "Thumbs Up" }, // 1f44d
            { "\U0001f44d\U0001f3fb", "Thumbs Up: Light Skin Tone" }, // 1f44d-1f3fb
            { "\U0001f44d\U0001f3fc", "Thumbs Up: Medium-Light Skin Tone" }, // 1f44d-1f3fc
            { "\U0001f44d\U0001f3fd", "Thumbs Up: Medium Skin Tone" }, // 1f44d-1f3fd
            { "\U0001f44d\U0001f3fe", "Thumbs Up: Medium-Dark Skin Tone" }, // 1f44d-1f3fe
            { "\U0001f44d\U0001f3ff", "Thumbs Up: Dark Skin Tone" }, // 1f44d-1f3ff
            { "\U0001f44e", "Thumbs Down" }, // 1f44e
            { "\U0001f44e\U0001f3fb", "Thumbs Down: Light Skin Tone" }, // 1f44e-1f3fb
            { "\U0001f44e\U0001f3fc", "Thumbs Down: Medium-Light Skin Tone" }, // 1f44e-1f3fc
            { "\U0001f44e\U0001f3fd", "Thumbs Down: Medium Skin Tone" }, // 1f44e-1f3fd
            { "\U0001f44e\U0001f3fe", "Thumbs Down: Medium-Dark Skin Tone" }, // 1f44e-1f3fe
            { "\U0001f44e\U0001f3ff", "Thumbs Down: Dark Skin Tone" }, // 1f44e-1f3ff
            { "\u270a", "Raised Fist" }, // 270a
            { "\u270a\U0001f3fb", "Raised Fist: Light Skin Tone" }, // 270a-1f3fb
            { "\u270a\U0001f3fc", "Raised Fist: Medium-Light Skin Tone" }, // 270a-1f3fc
            { "\u270a\U0001f3fd", "Raised Fist: Medium Skin Tone" }, // 270a-1f3fd
            { "\u270a\U0001f3fe", "Raised Fist: Medium-Dark Skin Tone" }, // 270a-1f3fe
            { "\u270a\U0001f3ff", "Raised Fist: Dark Skin Tone" }, // 270a-1f3ff
            { "\U0001f44a", "Oncoming Fist" }, // 1f44a
            { "\U0001f44a\U0001f3fb", "Oncoming Fist: Light Skin Tone" }, // 1f44a-1f3fb
            { "\U0001f44a\U0001f3fc", "Oncoming Fist: Medium-Light Skin Tone" }, // 1f44a-1f3fc
            { "\U0001f44a\U0001f3fd", "Oncoming Fist: Medium Skin Tone" }, // 1f44a-1f3fd
            { "\U0001f44a\U0001f3fe", "Oncoming Fist: Medium-Dark Skin Tone" }, // 1f44a-1f3fe
            { "\U0001f44a\U0001f3ff", "Oncoming Fist: Dark Skin Tone" }, // 1f44a-1f3ff
            { "\U0001f91b", "Left-Facing Fist" }, // 1f91b
            { "\U0001f91b\U0001f3fb", "Left-Facing Fist: Light Skin Tone" }, // 1f91b-1f3fb
            { "\U0001f91b\U0001f3fc", "Left-Facing Fist: Medium-Light Skin Tone" }, // 1f91b-1f3fc
            { "\U0001f91b\U0001f3fd", "Left-Facing Fist: Medium Skin Tone" }, // 1f91b-1f3fd
            { "\U0001f91b\U0001f3fe", "Left-Facing Fist: Medium-Dark Skin Tone" }, // 1f91b-1f3fe
            { "\U0001f91b\U0001f3ff", "Left-Facing Fist: Dark Skin Tone" }, // 1f91b-1f3ff
            { "\U0001f91c", "Right-Facing Fist" }, // 1f91c
            { "\U0001f91c\U0001f3fb", "Right-Facing Fist: Light Skin Tone" }, // 1f91c-1f3fb
            { "\U0001f91c\U0001f3fc", "Right-Facing Fist: Medium-Light Skin Tone" }, // 1f91c-1f3fc
            { "\U0001f91c\U0001f3fd", "Right-Facing Fist: Medium Skin Tone" }, // 1f91c-1f3fd
            { "\U0001f91c\U0001f3fe", "Right-Facing Fist: Medium-Dark Skin Tone" }, // 1f91c-1f3fe
            { "\U0001f91c\U0001f3ff", "Right-Facing Fist: Dark Skin Tone" }, // 1f91c-1f3ff
            { "\U0001f91a", "Raised Back of Hand" }, // 1f91a
            { "\U0001f91a\U0001f3fb", "Raised Back of Hand: Light Skin Tone" }, // 1f91a-1f3fb
            { "\U0001f91a\U0001f3fc", "Raised Back of Hand: Medium-Light Skin Tone" }, // 1f91a-1f3fc
            { "\U0001f91a\U0001f3fd", "Raised Back of Hand: Medium Skin Tone" }, // 1f91a-1f3fd
            { "\U0001f91a\U0001f3fe", "Raised Back of Hand: Medium-Dark Skin Tone" }, // 1f91a-1f3fe
            { "\U0001f91a\U0001f3ff", "Raised Back of Hand: Dark Skin Tone" }, // 1f91a-1f3ff
            { "\U0001f44b", "Waving Hand" }, // 1f44b
            { "\U0001f44b\U0001f3fb", "Waving Hand: Light Skin Tone" }, // 1f44b-1f3fb
            { "\U0001f44b\U0001f3fc", "Waving Hand: Medium-Light Skin Tone" }, // 1f44b-1f3fc
            { "\U0001f44b\U0001f3fd", "Waving Hand: Medium Skin Tone" }, // 1f44b-1f3fd
            { "\U0001f44b\U0001f3fe", "Waving Hand: Medium-Dark Skin Tone" }, // 1f44b-1f3fe
            { "\U0001f44b\U0001f3ff", "Waving Hand: Dark Skin Tone" }, // 1f44b-1f3ff
            { "\U0001f91f", "Love-You Gesture" }, // 1f91f
            { "\U0001f91f\U0001f3fb", "Love-You Gesture: Light Skin Tone" }, // 1f91f-1f3fb
            { "\U0001f91f\U0001f3fc", "Love-You Gesture: Medium-Light Skin Tone" }, // 1f91f-1f3fc
            { "\U0001f91f\U0001f3fd", "Love-You Gesture: Medium Skin Tone" }, // 1f91f-1f3fd
            { "\U0001f91f\U0001f3fe", "Love-You Gesture: Medium-Dark Skin Tone" }, // 1f91f-1f3fe
            { "\U0001f91f\U0001f3ff", "Love-You Gesture: Dark Skin Tone" }, // 1f91f-1f3ff
            { "\u270d", "Writing Hand" }, // 270d
            { "\u270d\U0001f3fb", "Writing Hand: Light Skin Tone" }, // 270d-1f3fb
            { "\u270d\U0001f3fc", "Writing Hand: Medium-Light Skin Tone" }, // 270d-1f3fc
            { "\u270d\U0001f3fd", "Writing Hand: Medium Skin Tone" }, // 270d-1f3fd
            { "\u270d\U0001f3fe", "Writing Hand: Medium-Dark Skin Tone" }, // 270d-1f3fe
            { "\u270d\U0001f3ff", "Writing Hand: Dark Skin Tone" }, // 270d-1f3ff
            { "\U0001f44f", "Clapping Hands" }, // 1f44f
            { "\U0001f44f\U0001f3fb", "Clapping Hands: Light Skin Tone" }, // 1f44f-1f3fb
            { "\U0001f44f\U0001f3fc", "Clapping Hands: Medium-Light Skin Tone" }, // 1f44f-1f3fc
            { "\U0001f44f\U0001f3fd", "Clapping Hands: Medium Skin Tone" }, // 1f44f-1f3fd
            { "\U0001f44f\U0001f3fe", "Clapping Hands: Medium-Dark Skin Tone" }, // 1f44f-1f3fe
            { "\U0001f44f\U0001f3ff", "Clapping Hands: Dark Skin Tone" }, // 1f44f-1f3ff
            { "\U0001f450", "Open Hands" }, // 1f450
            { "\U0001f450\U0001f3fb", "Open Hands: Light Skin Tone" }, // 1f450-1f3fb
            { "\U0001f450\U0001f3fc", "Open Hands: Medium-Light Skin Tone" }, // 1f450-1f3fc
            { "\U0001f450\U0001f3fd", "Open Hands: Medium Skin Tone" }, // 1f450-1f3fd
            { "\U0001f450\U0001f3fe", "Open Hands: Medium-Dark Skin Tone" }, // 1f450-1f3fe
            { "\U0001f450\U0001f3ff", "Open Hands: Dark Skin Tone" }, // 1f450-1f3ff
            { "\U0001f64c", "Raising Hands" }, // 1f64c
            { "\U0001f64c\U0001f3fb", "Raising Hands: Light Skin Tone" }, // 1f64c-1f3fb
            { "\U0001f64c\U0001f3fc", "Raising Hands: Medium-Light Skin Tone" }, // 1f64c-1f3fc
            { "\U0001f64c\U0001f3fd", "Raising Hands: Medium Skin Tone" }, // 1f64c-1f3fd
            { "\U0001f64c\U0001f3fe", "Raising Hands: Medium-Dark Skin Tone" }, // 1f64c-1f3fe
            { "\U0001f64c\U0001f3ff", "Raising Hands: Dark Skin Tone" }, // 1f64c-1f3ff
            { "\U0001f932", "Palms Up Together" }, // 1f932
            { "\U0001f932\U0001f3fb", "Palms Up Together: Light Skin Tone" }, // 1f932-1f3fb
            { "\U0001f932\U0001f3fc", "Palms Up Together: Medium-Light Skin Tone" }, // 1f932-1f3fc
            { "\U0001f932\U0001f3fd", "Palms Up Together: Medium Skin Tone" }, // 1f932-1f3fd
            { "\U0001f932\U0001f3fe", "Palms Up Together: Medium-Dark Skin Tone" }, // 1f932-1f3fe
            { "\U0001f932\U0001f3ff", "Palms Up Together: Dark Skin Tone" }, // 1f932-1f3ff
            { "\U0001f64f", "Folded Hands" }, // 1f64f
            { "\U0001f64f\U0001f3fb", "Folded Hands: Light Skin Tone" }, // 1f64f-1f3fb
            { "\U0001f64f\U0001f3fc", "Folded Hands: Medium-Light Skin Tone" }, // 1f64f-1f3fc
            { "\U0001f64f\U0001f3fd", "Folded Hands: Medium Skin Tone" }, // 1f64f-1f3fd
            { "\U0001f64f\U0001f3fe", "Folded Hands: Medium-Dark Skin Tone" }, // 1f64f-1f3fe
            { "\U0001f64f\U0001f3ff", "Folded Hands: Dark Skin Tone" }, // 1f64f-1f3ff
            { "\U0001f91d", "Handshake" }, // 1f91d
            { "\U0001f485", "Nail Polish" }, // 1f485
            { "\U0001f485\U0001f3fb", "Nail Polish: Light Skin Tone" }, // 1f485-1f3fb
            { "\U0001f485\U0001f3fc", "Nail Polish: Medium-Light Skin Tone" }, // 1f485-1f3fc
            { "\U0001f485\U0001f3fd", "Nail Polish: Medium Skin Tone" }, // 1f485-1f3fd
            { "\U0001f485\U0001f3fe", "Nail Polish: Medium-Dark Skin Tone" }, // 1f485-1f3fe
            { "\U0001f485\U0001f3ff", "Nail Polish: Dark Skin Tone" }, // 1f485-1f3ff
            { "\U0001f442", "Ear" }, // 1f442
            { "\U0001f442\U0001f3fb", "Ear: Light Skin Tone" }, // 1f442-1f3fb
            { "\U0001f442\U0001f3fc", "Ear: Medium-Light Skin Tone" }, // 1f442-1f3fc
            { "\U0001f442\U0001f3fd", "Ear: Medium Skin Tone" }, // 1f442-1f3fd
            { "\U0001f442\U0001f3fe", "Ear: Medium-Dark Skin Tone" }, // 1f442-1f3fe
            { "\U0001f442\U0001f3ff", "Ear: Dark Skin Tone" }, // 1f442-1f3ff
            { "\U0001f443", "Nose" }, // 1f443
            { "\U0001f443\U0001f3fb", "Nose: Light Skin Tone" }, // 1f443-1f3fb
            { "\U0001f443\U0001f3fc", "Nose: Medium-Light Skin Tone" }, // 1f443-1f3fc
            { "\U0001f443\U0001f3fd", "Nose: Medium Skin Tone" }, // 1f443-1f3fd
            { "\U0001f443\U0001f3fe", "Nose: Medium-Dark Skin Tone" }, // 1f443-1f3fe
            { "\U0001f443\U0001f3ff", "Nose: Dark Skin Tone" }, // 1f443-1f3ff
            { "\U0001f463", "Footprints" }, // 1f463
            { "\U0001f440", "Eyes" }, // 1f440
            { "\U0001f441", "Eye" }, // 1f441
            { "\U0001f441\ufe0f\u200d\U0001f5e8\ufe0f", "Eye in Speech Bubble" }, // 1f441-fe0f-200d-1f5e8-fe0f
            { "\U0001f9e0", "Brain" }, // 1f9e0
            { "\U0001f445", "Tongue" }, // 1f445
            { "\U0001f444", "Mouth" }, // 1f444
            { "\U0001f48b", "Kiss Mark" }, // 1f48b
            { "\U0001f498", "Heart With Arrow" }, // 1f498
            { "\u2764", "Red Heart" }, // 2764
            { "\U0001f493", "Beating Heart" }, // 1f493
            { "\U0001f494", "Broken Heart" }, // 1f494
            { "\U0001f495", "Two Hearts" }, // 1f495
            { "\U0001f496", "Sparkling Heart" }, // 1f496
            { "\U0001f497", "Growing Heart" }, // 1f497
            { "\U0001f499", "Blue Heart" }, // 1f499
            { "\U0001f49a", "Green Heart" }, // 1f49a
            { "\U0001f49b", "Yellow Heart" }, // 1f49b
            { "\U0001f9e1", "Orange Heart" }, // 1f9e1
            { "\U0001f49c", "Purple Heart" }, // 1f49c
            { "\U0001f5a4", "Black Heart" }, // 1f5a4
            { "\U0001f49d", "Heart With Ribbon" }, // 1f49d
            { "\U0001f49e", "Revolving Hearts" }, // 1f49e
            { "\U0001f49f", "Heart Decoration" }, // 1f49f
            { "\u2763", "Heavy Heart Exclamation" }, // 2763
            { "\U0001f48c", "Love Letter" }, // 1f48c
            { "\U0001f4a4", "Zzz" }, // 1f4a4
            { "\U0001f4a2", "Anger Symbol" }, // 1f4a2
            { "\U0001f4a3", "Bomb" }, // 1f4a3
            { "\U0001f4a5", "Collision" }, // 1f4a5
            { "\U0001f4a6", "Sweat Droplets" }, // 1f4a6
            { "\U0001f4a8", "Dashing Away" }, // 1f4a8
            { "\U0001f4ab", "Dizzy" }, // 1f4ab
            { "\U0001f4ac", "Speech Balloon" }, // 1f4ac
            { "\U0001f5e8", "Left Speech Bubble" }, // 1f5e8
            { "\U0001f5ef", "Right Anger Bubble" }, // 1f5ef
            { "\U0001f4ad", "Thought Balloon" }, // 1f4ad
            { "\U0001f573", "Hole" }, // 1f573
            { "\U0001f453", "Glasses" }, // 1f453
            { "\U0001f576", "Sunglasses" }, // 1f576
            { "\U0001f454", "Necktie" }, // 1f454
            { "\U0001f455", "T-Shirt" }, // 1f455
            { "\U0001f456", "Jeans" }, // 1f456
            { "\U0001f9e3", "Scarf" }, // 1f9e3
            { "\U0001f9e4", "Gloves" }, // 1f9e4
            { "\U0001f9e5", "Coat" }, // 1f9e5
            { "\U0001f9e6", "Socks" }, // 1f9e6
            { "\U0001f457", "Dress" }, // 1f457
            { "\U0001f458", "Kimono" }, // 1f458
            { "\U0001f459", "Bikini" }, // 1f459
            { "\U0001f45a", "Woman’s Clothes" }, // 1f45a
            { "\U0001f45b", "Purse" }, // 1f45b
            { "\U0001f45c", "Handbag" }, // 1f45c
            { "\U0001f45d", "Clutch Bag" }, // 1f45d
            { "\U0001f6cd", "Shopping Bags" }, // 1f6cd
            { "\U0001f392", "School Backpack" }, // 1f392
            { "\U0001f45e", "Man’s Shoe" }, // 1f45e
            { "\U0001f45f", "Running Shoe" }, // 1f45f
            { "\U0001f460", "High-Heeled Shoe" }, // 1f460
            { "\U0001f461", "Woman’s Sandal" }, // 1f461
            { "\U0001f462", "Woman’s Boot" }, // 1f462
            { "\U0001f451", "Crown" }, // 1f451
            { "\U0001f452", "Woman’s Hat" }, // 1f452
            { "\U0001f3a9", "Top Hat" }, // 1f3a9
            { "\U0001f393", "Graduation Cap" }, // 1f393
            { "\U0001f9e2", "Billed Cap" }, // 1f9e2
            { "\u26d1", "Rescue Worker’s Helmet" }, // 26d1
            { "\U0001f4ff", "Prayer Beads" }, // 1f4ff
            { "\U0001f484", "Lipstick" }, // 1f484
            { "\U0001f48d", "Ring" }, // 1f48d
            { "\U0001f48e", "Gem Stone" }, // 1f48e
            { "\U0001f435", "Monkey Face" }, // 1f435
            { "\U0001f412", "Monkey" }, // 1f412
            { "\U0001f98d", "Gorilla" }, // 1f98d
            { "\U0001f436", "Dog Face" }, // 1f436
            { "\U0001f415", "Dog" }, // 1f415
            { "\U0001f429", "Poodle" }, // 1f429
            { "\U0001f43a", "Wolf Face" }, // 1f43a
            { "\U0001f98a", "Fox Face" }, // 1f98a
            { "\U0001f431", "Cat Face" }, // 1f431
            { "\U0001f408", "Cat" }, // 1f408
            { "\U0001f981", "Lion Face" }, // 1f981
            { "\U0001f42f", "Tiger Face" }, // 1f42f
            { "\U0001f405", "Tiger" }, // 1f405
            { "\U0001f406", "Leopard" }, // 1f406
            { "\U0001f434", "Horse Face" }, // 1f434
            { "\U0001f40e", "Horse" }, // 1f40e
            { "\U0001f984", "Unicorn Face" }, // 1f984
            { "\U0001f993", "Zebra" }, // 1f993
            { "\U0001f98c", "Deer" }, // 1f98c
            { "\U0001f42e", "Cow Face" }, // 1f42e
            { "\U0001f402", "Ox" }, // 1f402
            { "\U0001f403", "Water Buffalo" }, // 1f403
            { "\U0001f404", "Cow" }, // 1f404
            { "\U0001f437", "Pig Face" }, // 1f437
            { "\U0001f416", "Pig" }, // 1f416
            { "\U0001f417", "Boar" }, // 1f417
            { "\U0001f43d", "Pig Nose" }, // 1f43d
            { "\U0001f40f", "Ram" }, // 1f40f
            { "\U0001f411", "Ewe" }, // 1f411
            { "\U0001f410", "Goat" }, // 1f410
            { "\U0001f42a", "Camel" }, // 1f42a
            { "\U0001f42b", "Two-Hump Camel" }, // 1f42b
            { "\U0001f992", "Giraffe" }, // 1f992
            { "\U0001f418", "Elephant" }, // 1f418
            { "\U0001f98f", "Rhinoceros" }, // 1f98f
            { "\U0001f42d", "Mouse Face" }, // 1f42d
            { "\U0001f401", "Mouse" }, // 1f401
            { "\U0001f400", "Rat" }, // 1f400
            { "\U0001f439", "Hamster Face" }, // 1f439
            { "\U0001f430", "Rabbit Face" }, // 1f430
            { "\U0001f407", "Rabbit" }, // 1f407
            { "\U0001f43f", "Chipmunk" }, // 1f43f
            { "\U0001f994", "Hedgehog" }, // 1f994
            { "\U0001f987", "Bat" }, // 1f987
            { "\U0001f43b", "Bear Face" }, // 1f43b
            { "\U0001f428", "Koala" }, // 1f428
            { "\U0001f43c", "Panda Face" }, // 1f43c
            { "\U0001f43e", "Paw Prints" }, // 1f43e
            { "\U0001f983", "Turkey" }, // 1f983
            { "\U0001f414", "Chicken" }, // 1f414
            { "\U0001f413", "Rooster" }, // 1f413
            { "\U0001f423", "Hatching Chick" }, // 1f423
            { "\U0001f424", "Baby Chick" }, // 1f424
            { "\U0001f425", "Front-Facing Baby Chick" }, // 1f425
            { "\U0001f426", "Bird" }, // 1f426
            { "\U0001f427", "Penguin" }, // 1f427
            { "\U0001f54a", "Dove" }, // 1f54a
            { "\U0001f985", "Eagle" }, // 1f985
            { "\U0001f986", "Duck" }, // 1f986
            { "\U0001f989", "Owl" }, // 1f989
            { "\U0001f438", "Frog Face" }, // 1f438
            { "\U0001f40a", "Crocodile" }, // 1f40a
            { "\U0001f422", "Turtle" }, // 1f422
            { "\U0001f98e", "Lizard" }, // 1f98e
            { "\U0001f40d", "Snake" }, // 1f40d
            { "\U0001f432", "Dragon Face" }, // 1f432
            { "\U0001f409", "Dragon" }, // 1f409
            { "\U0001f995", "Sauropod" }, // 1f995
            { "\U0001f996", "T-Rex" }, // 1f996
            { "\U0001f433", "Spouting Whale" }, // 1f433
            { "\U0001f40b", "Whale" }, // 1f40b
            { "\U0001f42c", "Dolphin" }, // 1f42c
            { "\U0001f41f", "Fish" }, // 1f41f
            { "\U0001f420", "Tropical Fish" }, // 1f420
            { "\U0001f421", "Blowfish" }, // 1f421
            { "\U0001f988", "Shark" }, // 1f988
            { "\U0001f419", "Octopus" }, // 1f419
            { "\U0001f41a", "Spiral Shell" }, // 1f41a
            { "\U0001f980", "Crab" }, // 1f980
            { "\U0001f990", "Shrimp" }, // 1f990
            { "\U0001f991", "Squid" }, // 1f991
            { "\U0001f40c", "Snail" }, // 1f40c
            { "\U0001f98b", "Butterfly" }, // 1f98b
            { "\U0001f41b", "Bug" }, // 1f41b
            { "\U0001f41c", "Ant" }, // 1f41c
            { "\U0001f41d", "Honeybee" }, // 1f41d
            { "\U0001f41e", "Lady Beetle" }, // 1f41e
            { "\U0001f997", "Cricket" }, // 1f997
            { "\U0001f577", "Spider" }, // 1f577
            { "\U0001f578", "Spider Web" }, // 1f578
            { "\U0001f982", "Scorpion" }, // 1f982
            { "\U0001f490", "Bouquet" }, // 1f490
            { "\U0001f338", "Cherry Blossom" }, // 1f338
            { "\U0001f4ae", "White Flower" }, // 1f4ae
            { "\U0001f3f5", "Rosette" }, // 1f3f5
            { "\U0001f339", "Rose" }, // 1f339
            { "\U0001f940", "Wilted Flower" }, // 1f940
            { "\U0001f33a", "Hibiscus" }, // 1f33a
            { "\U0001f33b", "Sunflower" }, // 1f33b
            { "\U0001f33c", "Blossom" }, // 1f33c
            { "\U0001f337", "Tulip" }, // 1f337
            { "\U0001f331", "Seedling" }, // 1f331
            { "\U0001f332", "Evergreen Tree" }, // 1f332
            { "\U0001f333", "Deciduous Tree" }, // 1f333
            { "\U0001f334", "Palm Tree" }, // 1f334
            { "\U0001f335", "Cactus" }, // 1f335
            { "\U0001f33e", "Sheaf of Rice" }, // 1f33e
            { "\U0001f33f", "Herb" }, // 1f33f
            { "\u2618", "Shamrock" }, // 2618
            { "\U0001f340", "Four Leaf Clover" }, // 1f340
            { "\U0001f341", "Maple Leaf" }, // 1f341
            { "\U0001f342", "Fallen Leaf" }, // 1f342
            { "\U0001f343", "Leaf Fluttering in Wind" }, // 1f343
            { "\U0001f347", "Grapes" }, // 1f347
            { "\U0001f348", "Melon" }, // 1f348
            { "\U0001f349", "Watermelon" }, // 1f349
            { "\U0001f34a", "Tangerine" }, // 1f34a
            { "\U0001f34b", "Lemon" }, // 1f34b
            { "\U0001f34c", "Banana" }, // 1f34c
            { "\U0001f34d", "Pineapple" }, // 1f34d
            { "\U0001f34e", "Red Apple" }, // 1f34e
            { "\U0001f34f", "Green Apple" }, // 1f34f
            { "\U0001f350", "Pear" }, // 1f350
            { "\U0001f351", "Peach" }, // 1f351
            { "\U0001f352", "Cherries" }, // 1f352
            { "\U0001f353", "Strawberry" }, // 1f353
            { "\U0001f95d", "Kiwi Fruit" }, // 1f95d
            { "\U0001f345", "Tomato" }, // 1f345
            { "\U0001f965", "Coconut" }, // 1f965
            { "\U0001f951", "Avocado" }, // 1f951
            { "\U0001f346", "Eggplant" }, // 1f346
            { "\U0001f954", "Potato" }, // 1f954
            { "\U0001f955", "Carrot" }, // 1f955
            { "\U0001f33d", "Ear of Corn" }, // 1f33d
            { "\U0001f336", "Hot Pepper" }, // 1f336
            { "\U0001f952", "Cucumber" }, // 1f952
            { "\U0001f966", "Broccoli" }, // 1f966
            { "\U0001f344", "Mushroom" }, // 1f344
            { "\U0001f95c", "Peanuts" }, // 1f95c
            { "\U0001f330", "Chestnut" }, // 1f330
            { "\U0001f35e", "Bread" }, // 1f35e
            { "\U0001f950", "Croissant" }, // 1f950
            { "\U0001f956", "Baguette Bread" }, // 1f956
            { "\U0001f968", "Pretzel" }, // 1f968
            { "\U0001f95e", "Pancakes" }, // 1f95e
            { "\U0001f9c0", "Cheese Wedge" }, // 1f9c0
            { "\U0001f356", "Meat on Bone" }, // 1f356
            { "\U0001f357", "Poultry Leg" }, // 1f357
            { "\U0001f969", "Cut of Meat" }, // 1f969
            { "\U0001f953", "Bacon" }, // 1f953
            { "\U0001f354", "Hamburger" }, // 1f354
            { "\U0001f35f", "French Fries" }, // 1f35f
            { "\U0001f355", "Pizza" }, // 1f355
            { "\U0001f32d", "Hot Dog" }, // 1f32d
            { "\U0001f96a", "Sandwich" }, // 1f96a
            { "\U0001f32e", "Taco" }, // 1f32e
            { "\U0001f32f", "Burrito" }, // 1f32f
            { "\U0001f959", "Stuffed Flatbread" }, // 1f959
            { "\U0001f95a", "Egg" }, // 1f95a
            { "\U0001f373", "Cooking" }, // 1f373
            { "\U0001f958", "Shallow Pan of Food" }, // 1f958
            { "\U0001f372", "Pot of Food" }, // 1f372
            { "\U0001f963", "Bowl With Spoon" }, // 1f963
            { "\U0001f957", "Green Salad" }, // 1f957
            { "\U0001f37f", "Popcorn" }, // 1f37f
            { "\U0001f96b", "Canned Food" }, // 1f96b
            { "\U0001f371", "Bento Box" }, // 1f371
            { "\U0001f358", "Rice Cracker" }, // 1f358
            { "\U0001f359", "Rice Ball" }, // 1f359
            { "\U0001f35a", "Cooked Rice" }, // 1f35a
            { "\U0001f35b", "Curry Rice" }, // 1f35b
            { "\U0001f35c", "Steaming Bowl" }, // 1f35c
            { "\U0001f35d", "Spaghetti" }, // 1f35d
            { "\U0001f360", "Roasted Sweet Potato" }, // 1f360
            { "\U0001f362", "Oden" }, // 1f362
            { "\U0001f363", "Sushi" }, // 1f363
            { "\U0001f364", "Fried Shrimp" }, // 1f364
            { "\U0001f365", "Fish Cake With Swirl" }, // 1f365
            { "\U0001f361", "Dango" }, // 1f361
            { "\U0001f95f", "Dumpling" }, // 1f95f
            { "\U0001f960", "Fortune Cookie" }, // 1f960
            { "\U0001f961", "Takeout Box" }, // 1f961
            { "\U0001f366", "Soft Ice Cream" }, // 1f366
            { "\U0001f367", "Shaved Ice" }, // 1f367
            { "\U0001f368", "Ice Cream" }, // 1f368
            { "\U0001f369", "Doughnut" }, // 1f369
            { "\U0001f36a", "Cookie" }, // 1f36a
            { "\U0001f382", "Birthday Cake" }, // 1f382
            { "\U0001f370", "Shortcake" }, // 1f370
            { "\U0001f967", "Pie" }, // 1f967
            { "\U0001f36b", "Chocolate Bar" }, // 1f36b
            { "\U0001f36c", "Candy" }, // 1f36c
            { "\U0001f36d", "Lollipop" }, // 1f36d
            { "\U0001f36e", "Custard" }, // 1f36e
            { "\U0001f36f", "Honey Pot" }, // 1f36f
            { "\U0001f37c", "Baby Bottle" }, // 1f37c
            { "\U0001f95b", "Glass of Milk" }, // 1f95b
            { "\u2615", "Hot Beverage" }, // 2615
            { "\U0001f375", "Teacup Without Handle" }, // 1f375
            { "\U0001f376", "Sake" }, // 1f376
            { "\U0001f37e", "Bottle With Popping Cork" }, // 1f37e
            { "\U0001f377", "Wine Glass" }, // 1f377
            { "\U0001f378", "Cocktail Glass" }, // 1f378
            { "\U0001f379", "Tropical Drink" }, // 1f379
            { "\U0001f37a", "Beer Mug" }, // 1f37a
            { "\U0001f37b", "Clinking Beer Mugs" }, // 1f37b
            { "\U0001f942", "Clinking Glasses" }, // 1f942
            { "\U0001f943", "Tumbler Glass" }, // 1f943
            { "\U0001f964", "Cup With Straw" }, // 1f964
            { "\U0001f962", "Chopsticks" }, // 1f962
            { "\U0001f37d", "Fork and Knife With Plate" }, // 1f37d
            { "\U0001f374", "Fork and Knife" }, // 1f374
            { "\U0001f944", "Spoon" }, // 1f944
            { "\U0001f52a", "Kitchen Knife" }, // 1f52a
            { "\U0001f3fa", "Amphora" }, // 1f3fa
            { "\U0001f30d", "Globe Showing Europe-Africa" }, // 1f30d
            { "\U0001f30e", "Globe Showing Americas" }, // 1f30e
            { "\U0001f30f", "Globe Showing Asia-Australia" }, // 1f30f
            { "\U0001f310", "Globe With Meridians" }, // 1f310
            { "\U0001f5fa", "World Map" }, // 1f5fa
            { "\U0001f5fe", "Map of Japan" }, // 1f5fe
            { "\U0001f3d4", "Snow-Capped Mountain" }, // 1f3d4
            { "\u26f0", "Mountain" }, // 26f0
            { "\U0001f30b", "Volcano" }, // 1f30b
            { "\U0001f5fb", "Mount Fuji" }, // 1f5fb
            { "\U0001f3d5", "Camping" }, // 1f3d5
            { "\U0001f3d6", "Beach With Umbrella" }, // 1f3d6
            { "\U0001f3dc", "Desert" }, // 1f3dc
            { "\U0001f3dd", "Desert Island" }, // 1f3dd
            { "\U0001f3de", "National Park" }, // 1f3de
            { "\U0001f3df", "Stadium" }, // 1f3df
            { "\U0001f3db", "Classical Building" }, // 1f3db
            { "\U0001f3d7", "Building Construction" }, // 1f3d7
            { "\U0001f3d8", "House" }, // 1f3d8
            { "\U0001f3d9", "Cityscape" }, // 1f3d9
            { "\U0001f3da", "Derelict House" }, // 1f3da
            { "\U0001f3e0", "House" }, // 1f3e0
            { "\U0001f3e1", "House With Garden" }, // 1f3e1
            { "\U0001f3e2", "Office Building" }, // 1f3e2
            { "\U0001f3e3", "Japanese Post Office" }, // 1f3e3
            { "\U0001f3e4", "Post Office" }, // 1f3e4
            { "\U0001f3e5", "Hospital" }, // 1f3e5
            { "\U0001f3e6", "Bank" }, // 1f3e6
            { "\U0001f3e8", "Hotel" }, // 1f3e8
            { "\U0001f3e9", "Love Hotel" }, // 1f3e9
            { "\U0001f3ea", "Convenience Store" }, // 1f3ea
            { "\U0001f3eb", "School" }, // 1f3eb
            { "\U0001f3ec", "Department Store" }, // 1f3ec
            { "\U0001f3ed", "Factory" }, // 1f3ed
            { "\U0001f3ef", "Japanese Castle" }, // 1f3ef
            { "\U0001f3f0", "Castle" }, // 1f3f0
            { "\U0001f492", "Wedding" }, // 1f492
            { "\U0001f5fc", "Tokyo Tower" }, // 1f5fc
            { "\U0001f5fd", "Statue of Liberty" }, // 1f5fd
            { "\u26ea", "Church" }, // 26ea
            { "\U0001f54c", "Mosque" }, // 1f54c
            { "\U0001f54d", "Synagogue" }, // 1f54d
            { "\u26e9", "Shinto Shrine" }, // 26e9
            { "\U0001f54b", "Kaaba" }, // 1f54b
            { "\u26f2", "Fountain" }, // 26f2
            { "\u26fa", "Tent" }, // 26fa
            { "\U0001f301", "Foggy" }, // 1f301
            { "\U0001f303", "Night With Stars" }, // 1f303
            { "\U0001f304", "Sunrise Over Mountains" }, // 1f304
            { "\U0001f305", "Sunrise" }, // 1f305
            { "\U0001f306", "Cityscape at Dusk" }, // 1f306
            { "\U0001f307", "Sunset" }, // 1f307
            { "\U0001f309", "Bridge at Night" }, // 1f309
            { "\u2668", "Hot Springs" }, // 2668
            { "\U0001f30c", "Milky Way" }, // 1f30c
            { "\U0001f3a0", "Carousel Horse" }, // 1f3a0
            { "\U0001f3a1", "Ferris Wheel" }, // 1f3a1
            { "\U0001f3a2", "Roller Coaster" }, // 1f3a2
            { "\U0001f488", "Barber Pole" }, // 1f488
            { "\U0001f3aa", "Circus Tent" }, // 1f3aa
            { "\U0001f3ad", "Performing Arts" }, // 1f3ad
            { "\U0001f5bc", "Framed Picture" }, // 1f5bc
            { "\U0001f3a8", "Artist Palette" }, // 1f3a8
            { "\U0001f3b0", "Slot Machine" }, // 1f3b0
            { "\U0001f682", "Locomotive" }, // 1f682
            { "\U0001f683", "Railway Car" }, // 1f683
            { "\U0001f684", "High-Speed Train" }, // 1f684
            { "\U0001f685", "High-Speed Train With Bullet Nose" }, // 1f685
            { "\U0001f686", "Train" }, // 1f686
            { "\U0001f687", "Metro" }, // 1f687
            { "\U0001f688", "Light Rail" }, // 1f688
            { "\U0001f689", "Station" }, // 1f689
            { "\U0001f68a", "Tram" }, // 1f68a
            { "\U0001f69d", "Monorail" }, // 1f69d
            { "\U0001f69e", "Mountain Railway" }, // 1f69e
            { "\U0001f68b", "Tram Car" }, // 1f68b
            { "\U0001f68c", "Bus" }, // 1f68c
            { "\U0001f68d", "Oncoming Bus" }, // 1f68d
            { "\U0001f68e", "Trolleybus" }, // 1f68e
            { "\U0001f690", "Minibus" }, // 1f690
            { "\U0001f691", "Ambulance" }, // 1f691
            { "\U0001f692", "Fire Engine" }, // 1f692
            { "\U0001f693", "Police Car" }, // 1f693
            { "\U0001f694", "Oncoming Police Car" }, // 1f694
            { "\U0001f695", "Taxi" }, // 1f695
            { "\U0001f696", "Oncoming Taxi" }, // 1f696
            { "\U0001f697", "Automobile" }, // 1f697
            { "\U0001f698", "Oncoming Automobile" }, // 1f698
            { "\U0001f699", "Sport Utility Vehicle" }, // 1f699
            { "\U0001f69a", "Delivery Truck" }, // 1f69a
            { "\U0001f69b", "Articulated Lorry" }, // 1f69b
            { "\U0001f69c", "Tractor" }, // 1f69c
            { "\U0001f6b2", "Bicycle" }, // 1f6b2
            { "\U0001f6f4", "Kick Scooter" }, // 1f6f4
            { "\U0001f6f5", "Motor Scooter" }, // 1f6f5
            { "\U0001f68f", "Bus Stop" }, // 1f68f
            { "\U0001f6e3", "Motorway" }, // 1f6e3
            { "\U0001f6e4", "Railway Track" }, // 1f6e4
            { "\u26fd", "Fuel Pump" }, // 26fd
            { "\U0001f6a8", "Police Car Light" }, // 1f6a8
            { "\U0001f6a5", "Horizontal Traffic Light" }, // 1f6a5
            { "\U0001f6a6", "Vertical Traffic Light" }, // 1f6a6
            { "\U0001f6a7", "Construction" }, // 1f6a7
            { "\U0001f6d1", "Stop Sign" }, // 1f6d1
            { "\u2693", "Anchor" }, // 2693
            { "\u26f5", "Sailboat" }, // 26f5
            { "\U0001f6f6", "Canoe" }, // 1f6f6
            { "\U0001f6a4", "Speedboat" }, // 1f6a4
            { "\U0001f6f3", "Passenger Ship" }, // 1f6f3
            { "\u26f4", "Ferry" }, // 26f4
            { "\U0001f6e5", "Motor Boat" }, // 1f6e5
            { "\U0001f6a2", "Ship" }, // 1f6a2
            { "\u2708", "Airplane" }, // 2708
            { "\U0001f6e9", "Small Airplane" }, // 1f6e9
            { "\U0001f6eb", "Airplane Departure" }, // 1f6eb
            { "\U0001f6ec", "Airplane Arrival" }, // 1f6ec
            { "\U0001f4ba", "Seat" }, // 1f4ba
            { "\U0001f681", "Helicopter" }, // 1f681
            { "\U0001f69f", "Suspension Railway" }, // 1f69f
            { "\U0001f6a0", "Mountain Cableway" }, // 1f6a0
            { "\U0001f6a1", "Aerial Tramway" }, // 1f6a1
            { "\U0001f6f0", "Satellite" }, // 1f6f0
            { "\U0001f680", "Rocket" }, // 1f680
            { "\U0001f6f8", "Flying Saucer" }, // 1f6f8
            { "\U0001f6ce", "Bellhop Bell" }, // 1f6ce
            { "\U0001f6aa", "Door" }, // 1f6aa
            { "\U0001f6cf", "Bed" }, // 1f6cf
            { "\U0001f6cb", "Couch and Lamp" }, // 1f6cb
            { "\U0001f6bd", "Toilet" }, // 1f6bd
            { "\U0001f6bf", "Shower" }, // 1f6bf
            { "\U0001f6c1", "Bathtub" }, // 1f6c1
            { "\u231b", "Hourglass" }, // 231b
            { "\u23f3", "Hourglass With Flowing Sand" }, // 23f3
            { "\u231a", "Watch" }, // 231a
            { "\u23f0", "Alarm Clock" }, // 23f0
            { "\u23f1", "Stopwatch" }, // 23f1
            { "\u23f2", "Timer Clock" }, // 23f2
            { "\U0001f570", "Mantelpiece Clock" }, // 1f570
            { "\U0001f55b", "Twelve O’clock" }, // 1f55b
            { "\U0001f567", "Twelve-Thirty" }, // 1f567
            { "\U0001f550", "One O’clock" }, // 1f550
            { "\U0001f55c", "One-Thirty" }, // 1f55c
            { "\U0001f551", "Two O’clock" }, // 1f551
            { "\U0001f55d", "Two-Thirty" }, // 1f55d
            { "\U0001f552", "Three O’clock" }, // 1f552
            { "\U0001f55e", "Three-Thirty" }, // 1f55e
            { "\U0001f553", "Four O’clock" }, // 1f553
            { "\U0001f55f", "Four-Thirty" }, // 1f55f
            { "\U0001f554", "Five O’clock" }, // 1f554
            { "\U0001f560", "Five-Thirty" }, // 1f560
            { "\U0001f555", "Six O’clock" }, // 1f555
            { "\U0001f561", "Six-Thirty" }, // 1f561
            { "\U0001f556", "Seven O’clock" }, // 1f556
            { "\U0001f562", "Seven-Thirty" }, // 1f562
            { "\U0001f557", "Eight O’clock" }, // 1f557
            { "\U0001f563", "Eight-Thirty" }, // 1f563
            { "\U0001f558", "Nine O’clock" }, // 1f558
            { "\U0001f564", "Nine-Thirty" }, // 1f564
            { "\U0001f559", "Ten O’clock" }, // 1f559
            { "\U0001f565", "Ten-Thirty" }, // 1f565
            { "\U0001f55a", "Eleven O’clock" }, // 1f55a
            { "\U0001f566", "Eleven-Thirty" }, // 1f566
            { "\U0001f311", "New Moon" }, // 1f311
            { "\U0001f312", "Waxing Crescent Moon" }, // 1f312
            { "\U0001f313", "First Quarter Moon" }, // 1f313
            { "\U0001f314", "Waxing Gibbous Moon" }, // 1f314
            { "\U0001f315", "Full Moon" }, // 1f315
            { "\U0001f316", "Waning Gibbous Moon" }, // 1f316
            { "\U0001f317", "Last Quarter Moon" }, // 1f317
            { "\U0001f318", "Waning Crescent Moon" }, // 1f318
            { "\U0001f319", "Crescent Moon" }, // 1f319
            { "\U0001f31a", "New Moon Face" }, // 1f31a
            { "\U0001f31b", "First Quarter Moon With Face" }, // 1f31b
            { "\U0001f31c", "Last Quarter Moon With Face" }, // 1f31c
            { "\U0001f321", "Thermometer" }, // 1f321
            { "\u2600", "Sun" }, // 2600
            { "\U0001f31d", "Full Moon With Face" }, // 1f31d
            { "\U0001f31e", "Sun With Face" }, // 1f31e
            { "\u2b50", "White Medium Star" }, // 2b50
            { "\U0001f31f", "Glowing Star" }, // 1f31f
            { "\U0001f320", "Shooting Star" }, // 1f320
            { "\u2601", "Cloud" }, // 2601
            { "\u26c5", "Sun Behind Cloud" }, // 26c5
            { "\u26c8", "Cloud With Lightning and Rain" }, // 26c8
            { "\U0001f324", "Sun Behind Small Cloud" }, // 1f324
            { "\U0001f325", "Sun Behind Large Cloud" }, // 1f325
            { "\U0001f326", "Sun Behind Rain Cloud" }, // 1f326
            { "\U0001f327", "Cloud With Rain" }, // 1f327
            { "\U0001f328", "Cloud With Snow" }, // 1f328
            { "\U0001f329", "Cloud With Lightning" }, // 1f329
            { "\U0001f32a", "Tornado" }, // 1f32a
            { "\U0001f32b", "Fog" }, // 1f32b
            { "\U0001f32c", "Wind Face" }, // 1f32c
            { "\U0001f300", "Cyclone" }, // 1f300
            { "\U0001f308", "Rainbow" }, // 1f308
            { "\U0001f302", "Closed Umbrella" }, // 1f302
            { "\u2602", "Umbrella" }, // 2602
            { "\u2614", "Umbrella With Rain Drops" }, // 2614
            { "\u26f1", "Umbrella on Ground" }, // 26f1
            { "\u26a1", "High Voltage" }, // 26a1
            { "\u2744", "Snowflake" }, // 2744
            { "\u2603", "Snowman" }, // 2603
            { "\u26c4", "Snowman Without Snow" }, // 26c4
            { "\u2604", "Comet" }, // 2604
            { "\U0001f525", "Fire" }, // 1f525
            { "\U0001f4a7", "Droplet" }, // 1f4a7
            { "\U0001f30a", "Water Wave" }, // 1f30a
            { "\U0001f383", "Jack-O-Lantern" }, // 1f383
            { "\U0001f384", "Christmas Tree" }, // 1f384
            { "\U0001f386", "Fireworks" }, // 1f386
            { "\U0001f387", "Sparkler" }, // 1f387
            { "\u2728", "Sparkles" }, // 2728
            { "\U0001f388", "Balloon" }, // 1f388
            { "\U0001f389", "Party Popper" }, // 1f389
            { "\U0001f38a", "Confetti Ball" }, // 1f38a
            { "\U0001f38b", "Tanabata Tree" }, // 1f38b
            { "\U0001f38d", "Pine Decoration" }, // 1f38d
            { "\U0001f38e", "Japanese Dolls" }, // 1f38e
            { "\U0001f38f", "Carp Streamer" }, // 1f38f
            { "\U0001f390", "Wind Chime" }, // 1f390
            { "\U0001f391", "Moon Viewing Ceremony" }, // 1f391
            { "\U0001f380", "Ribbon" }, // 1f380
            { "\U0001f381", "Wrapped Gift" }, // 1f381
            { "\U0001f397", "Reminder Ribbon" }, // 1f397
            { "\U0001f39f", "Admission Tickets" }, // 1f39f
            { "\U0001f3ab", "Ticket" }, // 1f3ab
            { "\U0001f396", "Military Medal" }, // 1f396
            { "\U0001f3c6", "Trophy" }, // 1f3c6
            { "\U0001f3c5", "Sports Medal" }, // 1f3c5
            { "\U0001f947", "1st Place Medal" }, // 1f947
            { "\U0001f948", "2nd Place Medal" }, // 1f948
            { "\U0001f949", "3rd Place Medal" }, // 1f949
            { "\u26bd", "Soccer Ball" }, // 26bd
            { "\u26be", "Baseball" }, // 26be
            { "\U0001f3c0", "Basketball" }, // 1f3c0
            { "\U0001f3d0", "Volleyball" }, // 1f3d0
            { "\U0001f3c8", "American Football" }, // 1f3c8
            { "\U0001f3c9", "Rugby Football" }, // 1f3c9
            { "\U0001f3be", "Tennis" }, // 1f3be
            { "\U0001f3b1", "Pool 8 Ball" }, // 1f3b1
            { "\U0001f3b3", "Bowling" }, // 1f3b3
            { "\U0001f3cf", "Cricket" }, // 1f3cf
            { "\U0001f3d1", "Field Hockey" }, // 1f3d1
            { "\U0001f3d2", "Ice Hockey" }, // 1f3d2
            { "\U0001f3d3", "Ping Pong" }, // 1f3d3
            { "\U0001f3f8", "Badminton" }, // 1f3f8
            { "\U0001f94a", "Boxing Glove" }, // 1f94a
            { "\U0001f94b", "Martial Arts Uniform" }, // 1f94b
            { "\U0001f945", "Goal Net" }, // 1f945
            { "\U0001f3af", "Direct Hit" }, // 1f3af
            { "\u26f3", "Flag in Hole" }, // 26f3
            { "\u26f8", "Ice Skate" }, // 26f8
            { "\U0001f3a3", "Fishing Pole" }, // 1f3a3
            { "\U0001f3bd", "Running Shirt" }, // 1f3bd
            { "\U0001f3bf", "Skis" }, // 1f3bf
            { "\U0001f6f7", "Sled" }, // 1f6f7
            { "\U0001f94c", "Curling Stone" }, // 1f94c
            { "\U0001f3ae", "Video Game" }, // 1f3ae
            { "\U0001f579", "Joystick" }, // 1f579
            { "\U0001f3b2", "Game Die" }, // 1f3b2
            { "\u2660", "Spade Suit" }, // 2660
            { "\u2665", "Heart Suit" }, // 2665
            { "\u2666", "Diamond Suit" }, // 2666
            { "\u2663", "Club Suit" }, // 2663
            { "\U0001f0cf", "Joker" }, // 1f0cf
            { "\U0001f004", "Mahjong Red Dragon" }, // 1f004
            { "\U0001f3b4", "Flower Playing Cards" }, // 1f3b4
            { "\U0001f507", "Muted Speaker" }, // 1f507
            { "\U0001f508", "Speaker Low Volume" }, // 1f508
            { "\U0001f509", "Speaker Medium Volume" }, // 1f509
            { "\U0001f50a", "Speaker High Volume" }, // 1f50a
            { "\U0001f4e2", "Loudspeaker" }, // 1f4e2
            { "\U0001f4e3", "Megaphone" }, // 1f4e3
            { "\U0001f4ef", "Postal Horn" }, // 1f4ef
            { "\U0001f514", "Bell" }, // 1f514
            { "\U0001f515", "Bell With Slash" }, // 1f515
            { "\U0001f3bc", "Musical Score" }, // 1f3bc
            { "\U0001f3b5", "Musical Note" }, // 1f3b5
            { "\U0001f3b6", "Musical Notes" }, // 1f3b6
            { "\U0001f399", "Studio Microphone" }, // 1f399
            { "\U0001f39a", "Level Slider" }, // 1f39a
            { "\U0001f39b", "Control Knobs" }, // 1f39b
            { "\U0001f3a4", "Microphone" }, // 1f3a4
            { "\U0001f3a7", "Headphone" }, // 1f3a7
            { "\U0001f4fb", "Radio" }, // 1f4fb
            { "\U0001f3b7", "Saxophone" }, // 1f3b7
            { "\U0001f3b8", "Guitar" }, // 1f3b8
            { "\U0001f3b9", "Musical Keyboard" }, // 1f3b9
            { "\U0001f3ba", "Trumpet" }, // 1f3ba
            { "\U0001f3bb", "Violin" }, // 1f3bb
            { "\U0001f941", "Drum" }, // 1f941
            { "\U0001f4f1", "Mobile Phone" }, // 1f4f1
            { "\U0001f4f2", "Mobile Phone With Arrow" }, // 1f4f2
            { "\u260e", "Telephone" }, // 260e
            { "\U0001f4de", "Telephone Receiver" }, // 1f4de
            { "\U0001f4df", "Pager" }, // 1f4df
            { "\U0001f4e0", "Fax Machine" }, // 1f4e0
            { "\U0001f50b", "Battery" }, // 1f50b
            { "\U0001f50c", "Electric Plug" }, // 1f50c
            { "\U0001f4bb", "Laptop Computer" }, // 1f4bb
            { "\U0001f5a5", "Desktop Computer" }, // 1f5a5
            { "\U0001f5a8", "Printer" }, // 1f5a8
            { "\u2328", "Keyboard" }, // 2328
            { "\U0001f5b1", "Computer Mouse" }, // 1f5b1
            { "\U0001f5b2", "Trackball" }, // 1f5b2
            { "\U0001f4bd", "Computer Disk" }, // 1f4bd
            { "\U0001f4be", "Floppy Disk" }, // 1f4be
            { "\U0001f4bf", "Optical Disk" }, // 1f4bf
            { "\U0001f4c0", "DVD" }, // 1f4c0
            { "\U0001f3a5", "Movie Camera" }, // 1f3a5
            { "\U0001f39e", "Film Frames" }, // 1f39e
            { "\U0001f4fd", "Film Projector" }, // 1f4fd
            { "\U0001f3ac", "Clapper Board" }, // 1f3ac
            { "\U0001f4fa", "Television" }, // 1f4fa
            { "\U0001f4f7", "Camera" }, // 1f4f7
            { "\U0001f4f8", "Camera With Flash" }, // 1f4f8
            { "\U0001f4f9", "Video Camera" }, // 1f4f9
            { "\U0001f4fc", "Videocassette" }, // 1f4fc
            { "\U0001f50d", "Left-Pointing Magnifying Glass" }, // 1f50d
            { "\U0001f50e", "Right-Pointing Magnifying Glass" }, // 1f50e
            { "\U0001f52c", "Microscope" }, // 1f52c
            { "\U0001f52d", "Telescope" }, // 1f52d
            { "\U0001f4e1", "Satellite Antenna" }, // 1f4e1
            { "\U0001f56f", "Candle" }, // 1f56f
            { "\U0001f4a1", "Light Bulb" }, // 1f4a1
            { "\U0001f526", "Flashlight" }, // 1f526
            { "\U0001f3ee", "Red Paper Lantern" }, // 1f3ee
            { "\U0001f4d4", "Notebook With Decorative Cover" }, // 1f4d4
            { "\U0001f4d5", "Closed Book" }, // 1f4d5
            { "\U0001f4d6", "Open Book" }, // 1f4d6
            { "\U0001f4d7", "Green Book" }, // 1f4d7
            { "\U0001f4d8", "Blue Book" }, // 1f4d8
            { "\U0001f4d9", "Orange Book" }, // 1f4d9
            { "\U0001f4da", "Books" }, // 1f4da
            { "\U0001f4d3", "Notebook" }, // 1f4d3
            { "\U0001f4d2", "Ledger" }, // 1f4d2
            { "\U0001f4c3", "Page With Curl" }, // 1f4c3
            { "\U0001f4dc", "Scroll" }, // 1f4dc
            { "\U0001f4c4", "Page Facing Up" }, // 1f4c4
            { "\U0001f4f0", "Newspaper" }, // 1f4f0
            { "\U0001f5de", "Rolled-Up Newspaper" }, // 1f5de
            { "\U0001f4d1", "Bookmark Tabs" }, // 1f4d1
            { "\U0001f516", "Bookmark" }, // 1f516
            { "\U0001f3f7", "Label" }, // 1f3f7
            { "\U0001f4b0", "Money Bag" }, // 1f4b0
            { "\U0001f4b4", "Yen Banknote" }, // 1f4b4
            { "\U0001f4b5", "Dollar Banknote" }, // 1f4b5
            { "\U0001f4b6", "Euro Banknote" }, // 1f4b6
            { "\U0001f4b7", "Pound Banknote" }, // 1f4b7
            { "\U0001f4b8", "Money With Wings" }, // 1f4b8
            { "\U0001f4b3", "Credit Card" }, // 1f4b3
            { "\U0001f4b9", "Chart Increasing With Yen" }, // 1f4b9
            { "\U0001f4b1", "Currency Exchange" }, // 1f4b1
            { "\U0001f4b2", "Heavy Dollar Sign" }, // 1f4b2
            { "\u2709", "Envelope" }, // 2709
            { "\U0001f4e7", "E-Mail" }, // 1f4e7
            { "\U0001f4e8", "Incoming Envelope" }, // 1f4e8
            { "\U0001f4e9", "Envelope With Arrow" }, // 1f4e9
            { "\U0001f4e4", "Outbox Tray" }, // 1f4e4
            { "\U0001f4e5", "Inbox Tray" }, // 1f4e5
            { "\U0001f4e6", "Package" }, // 1f4e6
            { "\U0001f4eb", "Closed Mailbox With Raised Flag" }, // 1f4eb
            { "\U0001f4ea", "Closed Mailbox With Lowered Flag" }, // 1f4ea
            { "\U0001f4ec", "Open Mailbox With Raised Flag" }, // 1f4ec
            { "\U0001f4ed", "Open Mailbox With Lowered Flag" }, // 1f4ed
            { "\U0001f4ee", "Postbox" }, // 1f4ee
            { "\U0001f5f3", "Ballot Box With Ballot" }, // 1f5f3
            { "\u270f", "Pencil" }, // 270f
            { "\u2712", "Black Nib" }, // 2712
            { "\U0001f58b", "Fountain Pen" }, // 1f58b
            { "\U0001f58a", "Pen" }, // 1f58a
            { "\U0001f58c", "Paintbrush" }, // 1f58c
            { "\U0001f58d", "Crayon" }, // 1f58d
            { "\U0001f4dd", "Memo" }, // 1f4dd
            { "\U0001f4bc", "Briefcase" }, // 1f4bc
            { "\U0001f4c1", "File Folder" }, // 1f4c1
            { "\U0001f4c2", "Open File Folder" }, // 1f4c2
            { "\U0001f5c2", "Card Index Dividers" }, // 1f5c2
            { "\U0001f4c5", "Calendar" }, // 1f4c5
            { "\U0001f4c6", "Tear-Off Calendar" }, // 1f4c6
            { "\U0001f5d2", "Spiral Notepad" }, // 1f5d2
            { "\U0001f5d3", "Spiral Calendar" }, // 1f5d3
            { "\U0001f4c7", "Card Index" }, // 1f4c7
            { "\U0001f4c8", "Chart Increasing" }, // 1f4c8
            { "\U0001f4c9", "Chart Decreasing" }, // 1f4c9
            { "\U0001f4ca", "Bar Chart" }, // 1f4ca
            { "\U0001f4cb", "Clipboard" }, // 1f4cb
            { "\U0001f4cc", "Pushpin" }, // 1f4cc
            { "\U0001f4cd", "Round Pushpin" }, // 1f4cd
            { "\U0001f4ce", "Paperclip" }, // 1f4ce
            { "\U0001f587", "Linked Paperclips" }, // 1f587
            { "\U0001f4cf", "Straight Ruler" }, // 1f4cf
            { "\U0001f4d0", "Triangular Ruler" }, // 1f4d0
            { "\u2702", "Scissors" }, // 2702
            { "\U0001f5c3", "Card File Box" }, // 1f5c3
            { "\U0001f5c4", "File Cabinet" }, // 1f5c4
            { "\U0001f5d1", "Wastebasket" }, // 1f5d1
            { "\U0001f512", "Locked" }, // 1f512
            { "\U0001f513", "Unlocked" }, // 1f513
            { "\U0001f50f", "Locked With Pen" }, // 1f50f
            { "\U0001f510", "Locked With Key" }, // 1f510
            { "\U0001f511", "Key" }, // 1f511
            { "\U0001f5dd", "Old Key" }, // 1f5dd
            { "\U0001f528", "Hammer" }, // 1f528
            { "\u26cf", "Pick" }, // 26cf
            { "\u2692", "Hammer and Pick" }, // 2692
            { "\U0001f6e0", "Hammer and Wrench" }, // 1f6e0
            { "\U0001f5e1", "Dagger" }, // 1f5e1
            { "\u2694", "Crossed Swords" }, // 2694
            { "\U0001f52b", "Pistol" }, // 1f52b
            { "\U0001f3f9", "Bow and Arrow" }, // 1f3f9
            { "\U0001f6e1", "Shield" }, // 1f6e1
            { "\U0001f527", "Wrench" }, // 1f527
            { "\U0001f529", "Nut and Bolt" }, // 1f529
            { "\u2699", "Gear" }, // 2699
            { "\U0001f5dc", "Clamp" }, // 1f5dc
            { "\u2697", "Alembic" }, // 2697
            { "\u2696", "Balance Scale" }, // 2696
            { "\U0001f517", "Link" }, // 1f517
            { "\u26d3", "Chains" }, // 26d3
            { "\U0001f489", "Syringe" }, // 1f489
            { "\U0001f48a", "Pill" }, // 1f48a
            { "\U0001f6ac", "Cigarette" }, // 1f6ac
            { "\u26b0", "Coffin" }, // 26b0
            { "\u26b1", "Funeral Urn" }, // 26b1
            { "\U0001f5ff", "Moai" }, // 1f5ff
            { "\U0001f6e2", "Oil Drum" }, // 1f6e2
            { "\U0001f52e", "Crystal Ball" }, // 1f52e
            { "\U0001f6d2", "Shopping Cart" }, // 1f6d2
            { "\U0001f3e7", "Atm Sign" }, // 1f3e7
            { "\U0001f6ae", "Litter in Bin Sign" }, // 1f6ae
            { "\U0001f6b0", "Potable Water" }, // 1f6b0
            { "\u267f", "Wheelchair Symbol" }, // 267f
            { "\U0001f6b9", "Men’s Room" }, // 1f6b9
            { "\U0001f6ba", "Women’s Room" }, // 1f6ba
            { "\U0001f6bb", "Restroom" }, // 1f6bb
            { "\U0001f6bc", "Baby Symbol" }, // 1f6bc
            { "\U0001f6be", "Water Closet" }, // 1f6be
            { "\U0001f6c2", "Passport Control" }, // 1f6c2
            { "\U0001f6c3", "Customs" }, // 1f6c3
            { "\U0001f6c4", "Baggage Claim" }, // 1f6c4
            { "\U0001f6c5", "Left Luggage" }, // 1f6c5
            { "\u26a0", "Warning" }, // 26a0
            { "\U0001f6b8", "Children Crossing" }, // 1f6b8
            { "\u26d4", "No Entry" }, // 26d4
            { "\U0001f6ab", "Prohibited" }, // 1f6ab
            { "\U0001f6b3", "No Bicycles" }, // 1f6b3
            { "\U0001f6ad", "No Smoking" }, // 1f6ad
            { "\U0001f6af", "No Littering" }, // 1f6af
            { "\U0001f6b1", "Non-Potable Water" }, // 1f6b1
            { "\U0001f6b7", "No Pedestrians" }, // 1f6b7
            { "\U0001f4f5", "No Mobile Phones" }, // 1f4f5
            { "\U0001f51e", "No One Under Eighteen" }, // 1f51e
            { "\u2622", "Radioactive" }, // 2622
            { "\u2623", "Biohazard" }, // 2623
            { "\u2b06", "Up Arrow" }, // 2b06
            { "\u2197", "Up-Right Arrow" }, // 2197
            { "\u27a1", "Right Arrow" }, // 27a1
            { "\u2198", "Down-Right Arrow" }, // 2198
            { "\u2b07", "Down Arrow" }, // 2b07
            { "\u2199", "Down-Left Arrow" }, // 2199
            { "\u2b05", "Left Arrow" }, // 2b05
            { "\u2196", "Up-Left Arrow" }, // 2196
            { "\u2195", "Up-Down Arrow" }, // 2195
            { "\u2194", "Left-Right Arrow" }, // 2194
            { "\u21a9", "Right Arrow Curving Left" }, // 21a9
            { "\u21aa", "Left Arrow Curving Right" }, // 21aa
            { "\u2934", "Right Arrow Curving Up" }, // 2934
            { "\u2935", "Right Arrow Curving Down" }, // 2935
            { "\U0001f503", "Clockwise Vertical Arrows" }, // 1f503
            { "\U0001f504", "Anticlockwise Arrows Button" }, // 1f504
            { "\U0001f519", "Back Arrow" }, // 1f519
            { "\U0001f51a", "End Arrow" }, // 1f51a
            { "\U0001f51b", "On! Arrow" }, // 1f51b
            { "\U0001f51c", "Soon Arrow" }, // 1f51c
            { "\U0001f51d", "Top Arrow" }, // 1f51d
            { "\U0001f6d0", "Place of Worship" }, // 1f6d0
            { "\u269b", "Atom Symbol" }, // 269b
            { "\U0001f549", "Om" }, // 1f549
            { "\u2721", "Star of David" }, // 2721
            { "\u2638", "Wheel of Dharma" }, // 2638
            { "\u262f", "Yin Yang" }, // 262f
            { "\u271d", "Latin Cross" }, // 271d
            { "\u2626", "Orthodox Cross" }, // 2626
            { "\u262a", "Star and Crescent" }, // 262a
            { "\u262e", "Peace Symbol" }, // 262e
            { "\U0001f54e", "Menorah" }, // 1f54e
            { "\U0001f52f", "Dotted Six-Pointed Star" }, // 1f52f
            { "\u2648", "Aries" }, // 2648
            { "\u2649", "Taurus" }, // 2649
            { "\u264a", "Gemini" }, // 264a
            { "\u264b", "Cancer" }, // 264b
            { "\u264c", "Leo" }, // 264c
            { "\u264d", "Virgo" }, // 264d
            { "\u264e", "Libra" }, // 264e
            { "\u264f", "Scorpius" }, // 264f
            { "\u2650", "Sagittarius" }, // 2650
            { "\u2651", "Capricorn" }, // 2651
            { "\u2652", "Aquarius" }, // 2652
            { "\u2653", "Pisces" }, // 2653
            { "\u26ce", "Ophiuchus" }, // 26ce
            { "\U0001f500", "Shuffle Tracks Button" }, // 1f500
            { "\U0001f501", "Repeat Button" }, // 1f501
            { "\U0001f502", "Repeat Single Button" }, // 1f502
            { "\u25b6", "Play Button" }, // 25b6
            { "\u23e9", "Fast-Forward Button" }, // 23e9
            { "\u23ed", "Next Track Button" }, // 23ed
            { "\u23ef", "Play or Pause Button" }, // 23ef
            { "\u25c0", "Reverse Button" }, // 25c0
            { "\u23ea", "Fast Reverse Button" }, // 23ea
            { "\u23ee", "Last Track Button" }, // 23ee
            { "\U0001f53c", "Up Button" }, // 1f53c
            { "\u23eb", "Fast Up Button" }, // 23eb
            { "\U0001f53d", "Down Button" }, // 1f53d
            { "\u23ec", "Fast Down Button" }, // 23ec
            { "\u23f8", "Pause Button" }, // 23f8
            { "\u23f9", "Stop Button" }, // 23f9
            { "\u23fa", "Record Button" }, // 23fa
            { "\u23cf", "Eject Button" }, // 23cf
            { "\U0001f3a6", "Cinema" }, // 1f3a6
            { "\U0001f505", "Dim Button" }, // 1f505
            { "\U0001f506", "Bright Button" }, // 1f506
            { "\U0001f4f6", "Antenna Bars" }, // 1f4f6
            { "\U0001f4f3", "Vibration Mode" }, // 1f4f3
            { "\U0001f4f4", "Mobile Phone Off" }, // 1f4f4
            { "\u2640", "Female Sign" }, // 2640
            { "\u2642", "Male Sign" }, // 2642
            { "\u2695", "Medical Symbol" }, // 2695
            { "\u267b", "Recycling Symbol" }, // 267b
            { "\u269c", "Fleur-De-Lis" }, // 269c
            { "\U0001f531", "Trident Emblem" }, // 1f531
            { "\U0001f4db", "Name Badge" }, // 1f4db
            { "\U0001f530", "Japanese Symbol for Beginner" }, // 1f530
            { "\u2b55", "Heavy Large Circle" }, // 2b55
            { "\u2705", "White Heavy Check Mark" }, // 2705
            { "\u2611", "Ballot Box With Check" }, // 2611
            { "\u2714", "Heavy Check Mark" }, // 2714
            { "\u2716", "Heavy Multiplication X" }, // 2716
            { "\u274c", "Cross Mark" }, // 274c
            { "\u274e", "Cross Mark Button" }, // 274e
            { "\u2795", "Heavy Plus Sign" }, // 2795
            { "\u2796", "Heavy Minus Sign" }, // 2796
            { "\u2797", "Heavy Division Sign" }, // 2797
            { "\u27b0", "Curly Loop" }, // 27b0
            { "\u27bf", "Double Curly Loop" }, // 27bf
            { "\u303d", "Part Alternation Mark" }, // 303d
            { "\u2733", "Eight-Spoked Asterisk" }, // 2733
            { "\u2734", "Eight-Pointed Star" }, // 2734
            { "\u2747", "Sparkle" }, // 2747
            { "\u203c", "Double Exclamation Mark" }, // 203c
            { "\u2049", "Exclamation Question Mark" }, // 2049
            { "\u2753", "Question Mark" }, // 2753
            { "\u2754", "White Question Mark" }, // 2754
            { "\u2755", "White Exclamation Mark" }, // 2755
            { "\u2757", "Exclamation Mark" }, // 2757
            { "\u3030", "Wavy Dash" }, // 3030
            { "\u00a9", "Copyright" }, // a9
            { "\u00ae", "Registered" }, // ae
            { "\u2122", "Trade Mark" }, // 2122
            { "\u0023\ufe0f\u20e3", "Keycap Number Sign" }, // 23-fe0f-20e3
            { "\u002a\ufe0f\u20e3", "Keycap Asterisk" }, // 2a-fe0f-20e3
            { "\u0030\ufe0f\u20e3", "Keycap Digit Zero" }, // 30-fe0f-20e3
            { "\u0031\ufe0f\u20e3", "Keycap Digit One" }, // 31-fe0f-20e3
            { "\u0032\ufe0f\u20e3", "Keycap Digit Two" }, // 32-fe0f-20e3
            { "\u0033\ufe0f\u20e3", "Keycap Digit Three" }, // 33-fe0f-20e3
            { "\u0034\ufe0f\u20e3", "Keycap Digit Four" }, // 34-fe0f-20e3
            { "\u0035\ufe0f\u20e3", "Keycap Digit Five" }, // 35-fe0f-20e3
            { "\u0036\ufe0f\u20e3", "Keycap Digit Six" }, // 36-fe0f-20e3
            { "\u0037\ufe0f\u20e3", "Keycap Digit Seven" }, // 37-fe0f-20e3
            { "\u0038\ufe0f\u20e3", "Keycap Digit Eight" }, // 38-fe0f-20e3
            { "\u0039\ufe0f\u20e3", "Keycap Digit Nine" }, // 39-fe0f-20e3
            { "\U0001f51f", "Keycap 10" }, // 1f51f
            { "\U0001f4af", "Hundred Points" }, // 1f4af
            { "\U0001f520", "Input Latin Uppercase" }, // 1f520
            { "\U0001f521", "Input Latin Lowercase" }, // 1f521
            { "\U0001f522", "Input Numbers" }, // 1f522
            { "\U0001f523", "Input Symbols" }, // 1f523
            { "\U0001f524", "Input Latin Letters" }, // 1f524
            { "\U0001f170", "A Button (blood Type)" }, // 1f170
            { "\U0001f18e", "Ab Button (blood Type)" }, // 1f18e
            { "\U0001f171", "B Button (blood Type)" }, // 1f171
            { "\U0001f191", "CL Button" }, // 1f191
            { "\U0001f192", "Cool Button" }, // 1f192
            { "\U0001f193", "Free Button" }, // 1f193
            { "\u2139", "Information" }, // 2139
            { "\U0001f194", "ID Button" }, // 1f194
            { "\u24c2", "Circled M" }, // 24c2
            { "\U0001f195", "New Button" }, // 1f195
            { "\U0001f196", "NG Button" }, // 1f196
            { "\U0001f17e", "O Button (blood Type)" }, // 1f17e
            { "\U0001f197", "OK Button" }, // 1f197
            { "\U0001f17f", "P Button" }, // 1f17f
            { "\U0001f198", "SOS Button" }, // 1f198
            { "\U0001f199", "Up! Button" }, // 1f199
            { "\U0001f19a", "Vs Button" }, // 1f19a
            { "\U0001f201", "Japanese “here” Button" }, // 1f201
            { "\U0001f202", "Japanese “service Charge” Button" }, // 1f202
            { "\U0001f237", "Japanese “monthly Amount” Button" }, // 1f237
            { "\U0001f236", "Japanese “not Free of Charge” Button" }, // 1f236
            { "\U0001f22f", "Japanese “reserved” Button" }, // 1f22f
            { "\U0001f250", "Japanese “bargain” Button" }, // 1f250
            { "\U0001f239", "Japanese “discount” Button" }, // 1f239
            { "\U0001f21a", "Japanese “free of Charge” Button" }, // 1f21a
            { "\U0001f232", "Japanese “prohibited” Button" }, // 1f232
            { "\U0001f251", "Japanese “acceptable” Button" }, // 1f251
            { "\U0001f238", "Japanese “application” Button" }, // 1f238
            { "\U0001f234", "Japanese “passing Grade” Button" }, // 1f234
            { "\U0001f233", "Japanese “vacancy” Button" }, // 1f233
            { "\u3297", "Japanese “congratulations” Button" }, // 3297
            { "\u3299", "Japanese “secret” Button" }, // 3299
            { "\U0001f23a", "Japanese “open for Business” Button" }, // 1f23a
            { "\U0001f235", "Japanese “no Vacancy” Button" }, // 1f235
            { "\u25aa", "Black Small Square" }, // 25aa
            { "\u25ab", "White Small Square" }, // 25ab
            { "\u25fb", "White Medium Square" }, // 25fb
            { "\u25fc", "Black Medium Square" }, // 25fc
            { "\u25fd", "White Medium-Small Square" }, // 25fd
            { "\u25fe", "Black Medium-Small Square" }, // 25fe
            { "\u2b1b", "Black Large Square" }, // 2b1b
            { "\u2b1c", "White Large Square" }, // 2b1c
            { "\U0001f536", "Large Orange Diamond" }, // 1f536
            { "\U0001f537", "Large Blue Diamond" }, // 1f537
            { "\U0001f538", "Small Orange Diamond" }, // 1f538
            { "\U0001f539", "Small Blue Diamond" }, // 1f539
            { "\U0001f53a", "Red Triangle Pointed Up" }, // 1f53a
            { "\U0001f53b", "Red Triangle Pointed Down" }, // 1f53b
            { "\U0001f4a0", "Diamond With a Dot" }, // 1f4a0
            { "\U0001f518", "Radio Button" }, // 1f518
            { "\U0001f532", "Black Square Button" }, // 1f532
            { "\U0001f533", "White Square Button" }, // 1f533
            { "\u26aa", "White Circle" }, // 26aa
            { "\u26ab", "Black Circle" }, // 26ab
            { "\U0001f534", "Red Circle" }, // 1f534
            { "\U0001f535", "Blue Circle" }, // 1f535
            { "\U0001f3c1", "Chequered Flag" }, // 1f3c1
            { "\U0001f6a9", "Triangular Flag" }, // 1f6a9
            { "\U0001f38c", "Crossed Flags" }, // 1f38c
            { "\U0001f3f4", "Black Flag" }, // 1f3f4
            { "\U0001f3f3", "White Flag" }, // 1f3f3
            { "\U0001f3f3\ufe0f\u200d\U0001f308", "Rainbow Flag" }, // 1f3f3-fe0f-200d-1f308
            { "\U0001f431\u200d\U0001f3cd", "Stunt Cat" }, // 1f431-200d-1f3cd
            { "\U0001f431\u200d\U0001f453", "Hipster Cat" }, // 1f431-200d-1f453
            { "\U0001f431\u200d\U0001f680", "Astro Cat" }, // 1f431-200d-1f680
            { "\U0001f431\u200d\U0001f464", "Ninja Cat" }, // 1f431-200d-1f464
            { "\U0001f431\u200d\U0001f409", "Dino Cat" }, // 1f431-200d-1f409
            { "\U0001f431\u200d\U0001f4bb", "Hacker Cat" }, // 1f431-200d-1f4bb
            { "\U0001f469\U0001f3fc\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3fe", "Couple With Heart - Woman: Medium-Light Skin Tone, Woman: Medium-Dark Skin Tone" }, // 1f469-1f3fc-200d-2764-fe0f-200d-1f469-1f3fe
            { "\U0001f468\u200d\U0001f469\u200d\U0001f466\u200d\U0001f467", "Family: Man, Woman, Boy, Girl" }, // 1f468-200d-1f469-200d-1f466-200d-1f467
            { "\U0001f468\U0001f3fb\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3fc", "Kiss - Man: Light Skin Tone, Man: Medium-Light Skin Tone" }, // 1f468-1f3fb-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3fc
            { "\U0001f468\U0001f3fd\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3fe", "Couple With Heart - Man: Medium Skin Tone, Woman: Medium-Dark Skin Tone" }, // 1f468-1f3fd-200d-2764-fe0f-200d-1f469-1f3fe
            { "\U0001f468\U0001f3fb\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3fe", "Couple With Heart - Man: Light Skin Tone, Man: Medium-Dark Skin Tone" }, // 1f468-1f3fb-200d-2764-fe0f-200d-1f468-1f3fe
            { "\U0001f468\u200d\U0001f468\u200d\U0001f476", "Family: Man, Man, Baby" }, // 1f468-200d-1f468-200d-1f476
            { "\U0001f468\U0001f3fd\u200d\u2764\ufe0f\u200d\U0001f468", "Couple With Heart - Man: Medium Skin Tone, Man" }, // 1f468-1f3fd-200d-2764-fe0f-200d-1f468
            { "\U0001f468\U0001f3fe\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3fc", "Kiss - Man: Medium-Dark Skin Tone, Woman: Medium-Light Skin Tone" }, // 1f468-1f3fe-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3fc
            { "\U0001f469\U0001f3ff\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3fc", "Kiss - Woman: Dark Skin Tone, Man: Medium-Light Skin Tone" }, // 1f469-1f3ff-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3fc
            { "\U0001f469\U0001f3fd\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3fe", "Kiss - Woman: Medium Skin Tone, Woman: Medium-Dark Skin Tone" }, // 1f469-1f3fd-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3fe
            { "\U0001f468\u200d\U0001f469\u200d\U0001f467\u200d\U0001f476", "Family: Man, Woman, Girl, Baby" }, // 1f468-200d-1f469-200d-1f467-200d-1f476
            { "\U0001f469\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3fc", "Kiss - Woman, Man: Medium-Light Skin Tone" }, // 1f469-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3fc
            { "\U0001f468\u200d\U0001f467\u200d\U0001f476", "Family: Man, Girl, Baby" }, // 1f468-200d-1f467-200d-1f476
            { "\U0001f469\U0001f3fb\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3fe", "Couple With Heart - Woman: Light Skin Tone, Man: Medium-Dark Skin Tone" }, // 1f469-1f3fb-200d-2764-fe0f-200d-1f468-1f3fe
            { "\U0001f468\U0001f3fd\u200d\u2764\ufe0f\u200d\U0001f469", "Couple With Heart - Man: Medium Skin Tone, Woman" }, // 1f468-1f3fd-200d-2764-fe0f-200d-1f469
            { "\U0001f469\U0001f3fc\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3fe", "Kiss - Woman: Medium-Light Skin Tone, Man: Medium-Dark Skin Tone" }, // 1f469-1f3fc-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3fe
            { "\U0001f469\U0001f3fd\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3fe", "Couple With Heart - Woman: Medium Skin Tone, Woman: Medium-Dark Skin Tone" }, // 1f469-1f3fd-200d-2764-fe0f-200d-1f469-1f3fe
            { "\U0001f469\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3fc", "Couple With Heart - Woman, Woman: Medium-Light Skin Tone" }, // 1f469-200d-2764-fe0f-200d-1f469-1f3fc
            { "\U0001f469\u200d\U0001f469\u200d\U0001f466\u200d\U0001f476", "Family: Woman, Woman, Boy, Baby" }, // 1f469-200d-1f469-200d-1f466-200d-1f476
            { "\U0001f468\u200d\U0001f466\u200d\U0001f467", "Family: Man, Boy, Girl" }, // 1f468-200d-1f466-200d-1f467
            { "\U0001f469\U0001f3fc\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468", "Kiss - Woman: Medium-Light Skin Tone, Man" }, // 1f469-1f3fc-200d-2764-fe0f-200d-1f48b-200d-1f468
            { "\U0001f468\U0001f3fd\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3ff", "Couple With Heart - Man: Medium Skin Tone, Woman: Dark Skin Tone" }, // 1f468-1f3fd-200d-2764-fe0f-200d-1f469-1f3ff
            { "\U0001f469\U0001f3fc\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3fd", "Kiss - Woman: Medium-Light Skin Tone, Man: Medium Skin Tone" }, // 1f469-1f3fc-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3fd
            { "\U0001f469\U0001f3fd\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3fd", "Couple With Heart - Woman: Medium Skin Tone, Woman: Medium Skin Tone" }, // 1f469-1f3fd-200d-2764-fe0f-200d-1f469-1f3fd
            { "\U0001f469\U0001f3fb\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3fd", "Couple With Heart - Woman: Light Skin Tone, Man: Medium Skin Tone" }, // 1f469-1f3fb-200d-2764-fe0f-200d-1f468-1f3fd
            { "\U0001f469\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3fb", "Kiss - Woman, Man: Light Skin Tone" }, // 1f469-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3fb
            { "\U0001f469\U0001f3fd\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3fd", "Kiss - Woman: Medium Skin Tone, Woman: Medium Skin Tone" }, // 1f469-1f3fd-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3fd
            { "\U0001f469\U0001f3ff\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3fb", "Kiss - Woman: Dark Skin Tone, Man: Light Skin Tone" }, // 1f469-1f3ff-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3fb
            { "\U0001f469\U0001f3ff\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3ff", "Kiss - Woman: Dark Skin Tone, Man: Dark Skin Tone" }, // 1f469-1f3ff-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3ff
            { "\U0001f468\U0001f3fc\u200d\u2764\ufe0f\u200d\U0001f469", "Couple With Heart - Man: Medium-Light Skin Tone, Woman" }, // 1f468-1f3fc-200d-2764-fe0f-200d-1f469
            { "\U0001f469\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3fe", "Couple With Heart - Woman, Woman: Medium-Dark Skin Tone" }, // 1f469-200d-2764-fe0f-200d-1f469-1f3fe
            { "\U0001f468\U0001f3fb\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3fb", "Couple With Heart - Man: Light Skin Tone, Man: Light Skin Tone" }, // 1f468-1f3fb-200d-2764-fe0f-200d-1f468-1f3fb
            { "\U0001f468\U0001f3fd\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3fb", "Couple With Heart - Man: Medium Skin Tone, Woman: Light Skin Tone" }, // 1f468-1f3fd-200d-2764-fe0f-200d-1f469-1f3fb
            { "\U0001f468\U0001f3fb\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3fd", "Kiss - Man: Light Skin Tone, Man: Medium Skin Tone" }, // 1f468-1f3fb-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3fd
            { "\U0001f468\u200d\U0001f466\u200d\U0001f476", "Family: Man, Boy, Baby" }, // 1f468-200d-1f466-200d-1f476
            { "\U0001f469\U0001f3fd\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3fc", "Kiss - Woman: Medium Skin Tone, Man: Medium-Light Skin Tone" }, // 1f469-1f3fd-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3fc
            { "\U0001f469\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3fe", "Kiss - Woman, Woman: Medium-Dark Skin Tone" }, // 1f469-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3fe
            { "\U0001f469\U0001f3fb\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3fc", "Couple With Heart - Woman: Light Skin Tone, Woman: Medium-Light Skin Tone" }, // 1f469-1f3fb-200d-2764-fe0f-200d-1f469-1f3fc
            { "\U0001f469\U0001f3fc\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3fc", "Kiss - Woman: Medium-Light Skin Tone, Woman: Medium-Light Skin Tone" }, // 1f469-1f3fc-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3fc
            { "\U0001f469\U0001f3fd\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3fc", "Couple With Heart - Woman: Medium Skin Tone, Man: Medium-Light Skin Tone" }, // 1f469-1f3fd-200d-2764-fe0f-200d-1f468-1f3fc
            { "\U0001f469\U0001f3fc\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3fb", "Kiss - Woman: Medium-Light Skin Tone, Woman: Light Skin Tone" }, // 1f469-1f3fc-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3fb
            { "\U0001f469\U0001f3fd\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3fb", "Couple With Heart - Woman: Medium Skin Tone, Man: Light Skin Tone" }, // 1f469-1f3fd-200d-2764-fe0f-200d-1f468-1f3fb
            { "\U0001f469\U0001f3fb\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3fb", "Couple With Heart - Woman: Light Skin Tone, Woman: Light Skin Tone" }, // 1f469-1f3fb-200d-2764-fe0f-200d-1f469-1f3fb
            { "\U0001f469\U0001f3fd\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3fb", "Kiss - Woman: Medium Skin Tone, Man: Light Skin Tone" }, // 1f469-1f3fd-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3fb
            { "\U0001f468\U0001f3fe\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3ff", "Kiss - Man: Medium-Dark Skin Tone, Man: Dark Skin Tone" }, // 1f468-1f3fe-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3ff
            { "\U0001f468\U0001f3fb\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3ff", "Kiss - Man: Light Skin Tone, Woman: Dark Skin Tone" }, // 1f468-1f3fb-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3ff
            { "\U0001f468\U0001f3fb\u200d\u2764\ufe0f\u200d\U0001f469", "Couple With Heart - Man: Light Skin Tone, Woman" }, // 1f468-1f3fb-200d-2764-fe0f-200d-1f469
            { "\U0001f468\U0001f3fe\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3fe", "Couple With Heart - Man: Medium-Dark Skin Tone, Woman: Medium-Dark Skin Tone" }, // 1f468-1f3fe-200d-2764-fe0f-200d-1f469-1f3fe
            { "\U0001f468\U0001f3fc\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3fe", "Kiss - Man: Medium-Light Skin Tone, Woman: Medium-Dark Skin Tone" }, // 1f468-1f3fc-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3fe
            { "\U0001f468\U0001f3fc\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3fe", "Couple With Heart - Man: Medium-Light Skin Tone, Man: Medium-Dark Skin Tone" }, // 1f468-1f3fc-200d-2764-fe0f-200d-1f468-1f3fe
            { "\U0001f468\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3fb", "Couple With Heart - Man, Woman: Light Skin Tone" }, // 1f468-200d-2764-fe0f-200d-1f469-1f3fb
            { "\U0001f468\U0001f3ff\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3fc", "Kiss - Man: Dark Skin Tone, Woman: Medium-Light Skin Tone" }, // 1f468-1f3ff-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3fc
            { "\U0001f469\U0001f3fd\u200d\u2764\ufe0f\u200d\U0001f468", "Couple With Heart - Woman: Medium Skin Tone, Man" }, // 1f469-1f3fd-200d-2764-fe0f-200d-1f468
            { "\U0001f468\U0001f3fd\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3fe", "Kiss - Man: Medium Skin Tone, Man: Medium-Dark Skin Tone" }, // 1f468-1f3fd-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3fe
            { "\U0001f468\U0001f3ff\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3fc", "Couple With Heart - Man: Dark Skin Tone, Woman: Medium-Light Skin Tone" }, // 1f468-1f3ff-200d-2764-fe0f-200d-1f469-1f3fc
            { "\U0001f468\U0001f3fd\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469", "Kiss - Man: Medium Skin Tone, Woman" }, // 1f468-1f3fd-200d-2764-fe0f-200d-1f48b-200d-1f469
            { "\U0001f468\U0001f3fb\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3fe", "Kiss - Man: Light Skin Tone, Man: Medium-Dark Skin Tone" }, // 1f468-1f3fb-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3fe
            { "\U0001f468\U0001f3fd\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3fc", "Couple With Heart - Man: Medium Skin Tone, Woman: Medium-Light Skin Tone" }, // 1f468-1f3fd-200d-2764-fe0f-200d-1f469-1f3fc
            { "\U0001f468\U0001f3fb\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3fc", "Couple With Heart - Man: Light Skin Tone, Man: Medium-Light Skin Tone" }, // 1f468-1f3fb-200d-2764-fe0f-200d-1f468-1f3fc
            { "\U0001f469\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3fd", "Couple With Heart - Woman, Woman: Medium Skin Tone" }, // 1f469-200d-2764-fe0f-200d-1f469-1f3fd
            { "\U0001f468\U0001f3fc\u200d\u2764\ufe0f\u200d\U0001f468", "Couple With Heart - Man: Medium-Light Skin Tone, Man" }, // 1f468-1f3fc-200d-2764-fe0f-200d-1f468
            { "\U0001f468\u200d\U0001f476", "Family: Man, Baby" }, // 1f468-200d-1f476
            { "\U0001f469\u200d\U0001f469\u200d\U0001f467\u200d\U0001f476", "Family: Woman, Woman, Girl, Baby" }, // 1f469-200d-1f469-200d-1f467-200d-1f476
            { "\U0001f469\U0001f3fd\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3fc", "Kiss - Woman: Medium Skin Tone, Woman: Medium-Light Skin Tone" }, // 1f469-1f3fd-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3fc
            { "\U0001f469\U0001f3ff\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3fe", "Kiss - Woman: Dark Skin Tone, Man: Medium-Dark Skin Tone" }, // 1f469-1f3ff-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3fe
            { "\U0001f469\U0001f3ff\u200d\u2764\ufe0f\u200d\U0001f469", "Couple With Heart - Woman: Dark Skin Tone, Woman" }, // 1f469-1f3ff-200d-2764-fe0f-200d-1f469
            { "\U0001f469\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3ff", "Couple With Heart - Woman, Woman: Dark Skin Tone" }, // 1f469-200d-2764-fe0f-200d-1f469-1f3ff
            { "\U0001f468\U0001f3fe\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469", "Kiss - Man: Medium-Dark Skin Tone, Woman" }, // 1f468-1f3fe-200d-2764-fe0f-200d-1f48b-200d-1f469
            { "\U0001f468\u200d\U0001f469\u200d\U0001f476", "Family: Man, Woman, Baby" }, // 1f468-200d-1f469-200d-1f476
            { "\U0001f468\U0001f3fb\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3ff", "Kiss - Man: Light Skin Tone, Man: Dark Skin Tone" }, // 1f468-1f3fb-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3ff
            { "\U0001f468\U0001f3fe\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468", "Kiss - Man: Medium-Dark Skin Tone, Man" }, // 1f468-1f3fe-200d-2764-fe0f-200d-1f48b-200d-1f468
            { "\U0001f468\u200d\U0001f469\u200d\U0001f466\u200d\U0001f476", "Family: Man, Woman, Boy, Baby" }, // 1f468-200d-1f469-200d-1f466-200d-1f476
            { "\U0001f469\U0001f3fb\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3fb", "Couple With Heart - Woman: Light Skin Tone, Man: Light Skin Tone" }, // 1f469-1f3fb-200d-2764-fe0f-200d-1f468-1f3fb
            { "\U0001f469\U0001f3fc\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3fb", "Kiss - Woman: Medium-Light Skin Tone, Man: Light Skin Tone" }, // 1f469-1f3fc-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3fb
            { "\U0001f469\U0001f3fd\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3fb", "Couple With Heart - Woman: Medium Skin Tone, Woman: Light Skin Tone" }, // 1f469-1f3fd-200d-2764-fe0f-200d-1f469-1f3fb
            { "\U0001f469\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3fd", "Kiss - Woman, Man: Medium Skin Tone" }, // 1f469-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3fd
            { "\U0001f469\U0001f3ff\u200d\u2764\ufe0f\u200d\U0001f468", "Couple With Heart - Woman: Dark Skin Tone, Man" }, // 1f469-1f3ff-200d-2764-fe0f-200d-1f468
            { "\U0001f469\U0001f3ff\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3fd", "Kiss - Woman: Dark Skin Tone, Man: Medium Skin Tone" }, // 1f469-1f3ff-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3fd
            { "\U0001f469\u200d\U0001f469\u200d\U0001f466\u200d\U0001f467", "Family: Woman, Woman, Boy, Girl" }, // 1f469-200d-1f469-200d-1f466-200d-1f467
            { "\U0001f468\U0001f3fe\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3fd", "Kiss - Man: Medium-Dark Skin Tone, Woman: Medium Skin Tone" }, // 1f468-1f3fe-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3fd
            { "\U0001f468\U0001f3fe\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3fe", "Kiss - Man: Medium-Dark Skin Tone, Woman: Medium-Dark Skin Tone" }, // 1f468-1f3fe-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3fe
            { "\U0001f468\U0001f3fe\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3fb", "Kiss - Man: Medium-Dark Skin Tone, Man: Light Skin Tone" }, // 1f468-1f3fe-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3fb
            { "\U0001f468\U0001f3fb\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468", "Kiss - Man: Light Skin Tone, Man" }, // 1f468-1f3fb-200d-2764-fe0f-200d-1f48b-200d-1f468
            { "\U0001f469\U0001f3fd\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3ff", "Couple With Heart - Woman: Medium Skin Tone, Man: Dark Skin Tone" }, // 1f469-1f3fd-200d-2764-fe0f-200d-1f468-1f3ff
            { "\U0001f469\U0001f3fc\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3ff", "Kiss - Woman: Medium-Light Skin Tone, Woman: Dark Skin Tone" }, // 1f469-1f3fc-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3ff
            { "\U0001f469\U0001f3fb\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3ff", "Couple With Heart - Woman: Light Skin Tone, Woman: Dark Skin Tone" }, // 1f469-1f3fb-200d-2764-fe0f-200d-1f469-1f3ff
            { "\U0001f468\U0001f3fb\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3fe", "Couple With Heart - Man: Light Skin Tone, Woman: Medium-Dark Skin Tone" }, // 1f468-1f3fb-200d-2764-fe0f-200d-1f469-1f3fe
            { "\U0001f469\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3fb", "Couple With Heart - Woman, Man: Light Skin Tone" }, // 1f469-200d-2764-fe0f-200d-1f468-1f3fb
            { "\U0001f468\U0001f3ff\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469", "Kiss - Man: Dark Skin Tone, Woman" }, // 1f468-1f3ff-200d-2764-fe0f-200d-1f48b-200d-1f469
            { "\U0001f469\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3fc", "Kiss - Woman, Woman: Medium-Light Skin Tone" }, // 1f469-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3fc
            { "\U0001f469\U0001f3fe\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3fe", "Couple With Heart - Woman: Medium-Dark Skin Tone, Woman: Medium-Dark Skin Tone" }, // 1f469-1f3fe-200d-2764-fe0f-200d-1f469-1f3fe
            { "\U0001f469\U0001f3fb\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3fc", "Kiss - Woman: Light Skin Tone, Woman: Medium-Light Skin Tone" }, // 1f469-1f3fb-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3fc
            { "\U0001f469\U0001f3fc\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3fe", "Couple With Heart - Woman: Medium-Light Skin Tone, Man: Medium-Dark Skin Tone" }, // 1f469-1f3fc-200d-2764-fe0f-200d-1f468-1f3fe
            { "\U0001f468\u200d\U0001f468\u200d\U0001f476\u200d\U0001f466", "Family: Man, Man, Baby, Boy" }, // 1f468-200d-1f468-200d-1f476-200d-1f466
            { "\U0001f469\U0001f3fe\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3fc", "Kiss - Woman: Medium-Dark Skin Tone, Man: Medium-Light Skin Tone" }, // 1f469-1f3fe-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3fc
            { "\U0001f469\U0001f3ff\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3fc", "Couple With Heart - Woman: Dark Skin Tone, Woman: Medium-Light Skin Tone" }, // 1f469-1f3ff-200d-2764-fe0f-200d-1f469-1f3fc
            { "\U0001f468\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3fe", "Kiss - Man, Woman: Medium-Dark Skin Tone" }, // 1f468-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3fe
            { "\U0001f468\U0001f3ff\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3fe", "Couple With Heart - Man: Dark Skin Tone, Woman: Medium-Dark Skin Tone" }, // 1f468-1f3ff-200d-2764-fe0f-200d-1f469-1f3fe
            { "\U0001f468\U0001f3fd\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3fc", "Kiss - Man: Medium Skin Tone, Man: Medium-Light Skin Tone" }, // 1f468-1f3fd-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3fc
            { "\U0001f469\U0001f3fb\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469", "Kiss - Woman: Light Skin Tone, Woman" }, // 1f469-1f3fb-200d-2764-fe0f-200d-1f48b-200d-1f469
            { "\U0001f468\U0001f3ff\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3fe", "Kiss - Man: Dark Skin Tone, Woman: Medium-Dark Skin Tone" }, // 1f468-1f3ff-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3fe
            { "\U0001f468\u200d\U0001f469\u200d\U0001f476\u200d\U0001f476", "Family: Man, Woman, Baby, Baby" }, // 1f468-200d-1f469-200d-1f476-200d-1f476
            { "\U0001f469\U0001f3fb\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3fd", "Couple With Heart - Woman: Light Skin Tone, Woman: Medium Skin Tone" }, // 1f469-1f3fb-200d-2764-fe0f-200d-1f469-1f3fd
            { "\U0001f469\U0001f3fc\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3fd", "Kiss - Woman: Medium-Light Skin Tone, Woman: Medium Skin Tone" }, // 1f469-1f3fc-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3fd
            { "\U0001f469\U0001f3fd\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3fd", "Couple With Heart - Woman: Medium Skin Tone, Man: Medium Skin Tone" }, // 1f469-1f3fd-200d-2764-fe0f-200d-1f468-1f3fd
            { "\U0001f469\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3fb", "Kiss - Woman, Woman: Light Skin Tone" }, // 1f469-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3fb
            { "\U0001f468\U0001f3ff\u200d\U0001f469\U0001f3ff\u200d\U0001f467\U0001f3ff", "Family - Man: Dark Skin Tone, Woman: Dark Skin Tone, Girl: Dark Skin Tone" }, // 1f468-1f3ff-200d-1f469-1f3ff-200d-1f467-1f3ff
            { "\U0001f468\U0001f3ff\u200d\U0001f469\U0001f3ff\u200d\U0001f466\U0001f3ff", "Family - Man: Dark Skin Tone, Woman: Dark Skin Tone, Boy: Dark Skin Tone" }, // 1f468-1f3ff-200d-1f469-1f3ff-200d-1f466-1f3ff
            { "\U0001f468\U0001f3ff\u200d\U0001f468\U0001f3ff\u200d\U0001f476\U0001f3ff", "Family - Man: Dark Skin Tone, Man: Dark Skin Tone, Baby: Dark Skin Tone" }, // 1f468-1f3ff-200d-1f468-1f3ff-200d-1f476-1f3ff
            { "\U0001f468\U0001f3ff\u200d\U0001f468\U0001f3ff\u200d\U0001f467\U0001f3ff", "Family - Man: Dark Skin Tone, Man: Dark Skin Tone, Girl: Dark Skin Tone" }, // 1f468-1f3ff-200d-1f468-1f3ff-200d-1f467-1f3ff
            { "\U0001f468\U0001f3ff\u200d\U0001f468\U0001f3ff\u200d\U0001f466\U0001f3ff", "Family - Man: Dark Skin Tone, Man: Dark Skin Tone, Boy: Dark Skin Tone" }, // 1f468-1f3ff-200d-1f468-1f3ff-200d-1f466-1f3ff
            { "\U0001f468\U0001f3fe\u200d\U0001f469\U0001f3fe\u200d\U0001f476\U0001f3fe", "Family - Man: Medium-Dark Skin Tone, Woman: Medium-Dark Skin Tone, Baby: Medium-Dark Skin Tone" }, // 1f468-1f3fe-200d-1f469-1f3fe-200d-1f476-1f3fe
            { "\U0001f468\U0001f3fe\u200d\U0001f469\U0001f3fe\u200d\U0001f467\U0001f3fe", "Family - Man: Medium-Dark Skin Tone, Woman: Medium-Dark Skin Tone, Girl: Medium-Dark Skin Tone" }, // 1f468-1f3fe-200d-1f469-1f3fe-200d-1f467-1f3fe
            { "\U0001f468\U0001f3fc\u200d\U0001f468\U0001f3fc\u200d\U0001f466\U0001f3fc", "Family - Man: Medium-Light Skin Tone, Man: Medium-Light Skin Tone, Boy: Medium-Light Skin Tone" }, // 1f468-1f3fc-200d-1f468-1f3fc-200d-1f466-1f3fc
            { "\U0001f468\U0001f3fb\u200d\U0001f469\U0001f3fb\u200d\U0001f476\U0001f3fb", "Family - Man: Light Skin Tone, Woman: Light Skin Tone, Baby: Light Skin Tone" }, // 1f468-1f3fb-200d-1f469-1f3fb-200d-1f476-1f3fb
            { "\U0001f468\U0001f3fb\u200d\U0001f469\U0001f3fb\u200d\U0001f467\U0001f3fb", "Family - Man: Light Skin Tone, Woman: Light Skin Tone, Girl: Light Skin Tone" }, // 1f468-1f3fb-200d-1f469-1f3fb-200d-1f467-1f3fb
            { "\U0001f468\U0001f3fb\u200d\U0001f469\U0001f3fb\u200d\U0001f466\U0001f3fb", "Family - Man: Light Skin Tone, Woman: Light Skin Tone, Boy: Light Skin Tone" }, // 1f468-1f3fb-200d-1f469-1f3fb-200d-1f466-1f3fb
            { "\U0001f468\U0001f3fb\u200d\U0001f468\U0001f3fb\u200d\U0001f476\U0001f3fb", "Family - Man: Light Skin Tone, Man: Light Skin Tone, Baby: Light Skin Tone" }, // 1f468-1f3fb-200d-1f468-1f3fb-200d-1f476-1f3fb
            { "\U0001f468\U0001f3fb\u200d\U0001f468\U0001f3fb\u200d\U0001f467\U0001f3fb", "Family - Man: Light Skin Tone, Man: Light Skin Tone, Girl: Light Skin Tone" }, // 1f468-1f3fb-200d-1f468-1f3fb-200d-1f467-1f3fb
            { "\U0001f468\U0001f3fb\u200d\U0001f468\U0001f3fb\u200d\U0001f466\U0001f3fb", "Family - Man: Light Skin Tone, Man: Light Skin Tone, Boy: Light Skin Tone" }, // 1f468-1f3fb-200d-1f468-1f3fb-200d-1f466-1f3fb
            { "\U0001f469\U0001f3ff\u200d\U0001f476\U0001f3ff\u200d\U0001f476\U0001f3ff", "Family - Woman: Dark Skin Tone, Baby: Dark Skin Tone, Baby: Dark Skin Tone" }, // 1f469-1f3ff-200d-1f476-1f3ff-200d-1f476-1f3ff
            { "\U0001f469\U0001f3ff\u200d\U0001f476\U0001f3ff\u200d\U0001f467\U0001f3ff", "Family - Woman: Dark Skin Tone, Baby: Dark Skin Tone, Girl: Dark Skin Tone" }, // 1f469-1f3ff-200d-1f476-1f3ff-200d-1f467-1f3ff
            { "\U0001f469\U0001f3ff\u200d\U0001f476\U0001f3ff\u200d\U0001f466\U0001f3ff", "Family - Woman: Dark Skin Tone, Baby: Dark Skin Tone, Boy: Dark Skin Tone" }, // 1f469-1f3ff-200d-1f476-1f3ff-200d-1f466-1f3ff
            { "\U0001f469\U0001f3ff\u200d\U0001f467\U0001f3ff\u200d\U0001f476\U0001f3ff", "Family - Woman: Dark Skin Tone, Girl: Dark Skin Tone, Baby: Dark Skin Tone" }, // 1f469-1f3ff-200d-1f467-1f3ff-200d-1f476-1f3ff
            { "\U0001f469\U0001f3ff\u200d\U0001f467\U0001f3ff\u200d\U0001f467\U0001f3ff", "Family - Woman: Dark Skin Tone, Girl: Dark Skin Tone, Girl: Dark Skin Tone" }, // 1f469-1f3ff-200d-1f467-1f3ff-200d-1f467-1f3ff
            { "\U0001f469\U0001f3ff\u200d\U0001f467\U0001f3ff\u200d\U0001f466\U0001f3ff", "Family - Woman: Dark Skin Tone, Girl: Dark Skin Tone, Boy: Dark Skin Tone" }, // 1f469-1f3ff-200d-1f467-1f3ff-200d-1f466-1f3ff
            { "\U0001f469\U0001f3ff\u200d\U0001f466\U0001f3ff\u200d\U0001f476\U0001f3ff", "Family - Woman: Dark Skin Tone, Boy: Dark Skin Tone, Baby: Dark Skin Tone" }, // 1f469-1f3ff-200d-1f466-1f3ff-200d-1f476-1f3ff
            { "\U0001f469\U0001f3ff\u200d\U0001f466\U0001f3ff\u200d\U0001f467\U0001f3ff", "Family - Woman: Dark Skin Tone, Boy: Dark Skin Tone, Girl: Dark Skin Tone" }, // 1f469-1f3ff-200d-1f466-1f3ff-200d-1f467-1f3ff
            { "\U0001f469\U0001f3ff\u200d\U0001f466\U0001f3ff\u200d\U0001f466\U0001f3ff", "Family - Woman: Dark Skin Tone, Boy: Dark Skin Tone, Boy: Dark Skin Tone" }, // 1f469-1f3ff-200d-1f466-1f3ff-200d-1f466-1f3ff
            { "\U0001f469\U0001f3fe\u200d\U0001f476\U0001f3fe\u200d\U0001f476\U0001f3fe", "Family - Woman: Medium-Dark Skin Tone, Baby: Medium-Dark Skin Tone, Baby: Medium-Dark Skin Tone" }, // 1f469-1f3fe-200d-1f476-1f3fe-200d-1f476-1f3fe
            { "\U0001f469\U0001f3fe\u200d\U0001f476\U0001f3fe\u200d\U0001f467\U0001f3fe", "Family - Woman: Medium-Dark Skin Tone, Baby: Medium-Dark Skin Tone, Girl: Medium-Dark Skin Tone" }, // 1f469-1f3fe-200d-1f476-1f3fe-200d-1f467-1f3fe
            { "\U0001f469\U0001f3fe\u200d\U0001f476\U0001f3fe\u200d\U0001f466\U0001f3fe", "Family - Woman: Medium-Dark Skin Tone, Baby: Medium-Dark Skin Tone, Boy: Medium-Dark Skin Tone" }, // 1f469-1f3fe-200d-1f476-1f3fe-200d-1f466-1f3fe
            { "\U0001f469\U0001f3fe\u200d\U0001f467\U0001f3fe\u200d\U0001f476\U0001f3fe", "Family - Woman: Medium-Dark Skin Tone, Girl: Medium-Dark Skin Tone, Baby: Medium-Dark Skin Tone" }, // 1f469-1f3fe-200d-1f467-1f3fe-200d-1f476-1f3fe
            { "\U0001f469\U0001f3fe\u200d\U0001f467\U0001f3fe\u200d\U0001f467\U0001f3fe", "Family - Woman: Medium-Dark Skin Tone, Girl: Medium-Dark Skin Tone, Girl: Medium-Dark Skin Tone" }, // 1f469-1f3fe-200d-1f467-1f3fe-200d-1f467-1f3fe
            { "\U0001f469\U0001f3fe\u200d\U0001f467\U0001f3fe\u200d\U0001f466\U0001f3fe", "Family - Woman: Medium-Dark Skin Tone, Girl: Medium-Dark Skin Tone, Boy: Medium-Dark Skin Tone" }, // 1f469-1f3fe-200d-1f467-1f3fe-200d-1f466-1f3fe
            { "\U0001f469\U0001f3fe\u200d\U0001f466\U0001f3fe\u200d\U0001f476\U0001f3fe", "Family - Woman: Medium-Dark Skin Tone, Boy: Medium-Dark Skin Tone, Baby: Medium-Dark Skin Tone" }, // 1f469-1f3fe-200d-1f466-1f3fe-200d-1f476-1f3fe
            { "\U0001f469\U0001f3fe\u200d\U0001f466\U0001f3fe\u200d\U0001f467\U0001f3fe", "Family - Woman: Medium-Dark Skin Tone, Boy: Medium-Dark Skin Tone, Girl: Medium-Dark Skin Tone" }, // 1f469-1f3fe-200d-1f466-1f3fe-200d-1f467-1f3fe
            { "\U0001f469\U0001f3fe\u200d\U0001f466\U0001f3fe\u200d\U0001f466\U0001f3fe", "Family - Woman: Medium-Dark Skin Tone, Boy: Medium-Dark Skin Tone, Boy: Medium-Dark Skin Tone" }, // 1f469-1f3fe-200d-1f466-1f3fe-200d-1f466-1f3fe
            { "\U0001f469\U0001f3fd\u200d\U0001f476\U0001f3fd\u200d\U0001f476\U0001f3fd", "Family - Woman: Medium Skin Tone, Baby: Medium Skin Tone, Baby: Medium Skin Tone" }, // 1f469-1f3fd-200d-1f476-1f3fd-200d-1f476-1f3fd
            { "\U0001f469\U0001f3fd\u200d\U0001f476\U0001f3fd\u200d\U0001f467\U0001f3fd", "Family - Woman: Medium Skin Tone, Baby: Medium Skin Tone, Girl: Medium Skin Tone" }, // 1f469-1f3fd-200d-1f476-1f3fd-200d-1f467-1f3fd
            { "\U0001f469\U0001f3fd\u200d\U0001f476\U0001f3fd\u200d\U0001f466\U0001f3fd", "Family - Woman: Medium Skin Tone, Baby: Medium Skin Tone, Boy: Medium Skin Tone" }, // 1f469-1f3fd-200d-1f476-1f3fd-200d-1f466-1f3fd
            { "\U0001f469\U0001f3fd\u200d\U0001f467\U0001f3fd\u200d\U0001f476\U0001f3fd", "Family - Woman: Medium Skin Tone, Girl: Medium Skin Tone, Baby: Medium Skin Tone" }, // 1f469-1f3fd-200d-1f467-1f3fd-200d-1f476-1f3fd
            { "\U0001f469\U0001f3fd\u200d\U0001f467\U0001f3fd\u200d\U0001f467\U0001f3fd", "Family - Woman: Medium Skin Tone, Girl: Medium Skin Tone, Girl: Medium Skin Tone" }, // 1f469-1f3fd-200d-1f467-1f3fd-200d-1f467-1f3fd
            { "\U0001f469\U0001f3fd\u200d\U0001f467\U0001f3fd\u200d\U0001f466\U0001f3fd", "Family - Woman: Medium Skin Tone, Girl: Medium Skin Tone, Boy: Medium Skin Tone" }, // 1f469-1f3fd-200d-1f467-1f3fd-200d-1f466-1f3fd
            { "\U0001f469\U0001f3fd\u200d\U0001f466\U0001f3fd\u200d\U0001f476\U0001f3fd", "Family - Woman: Medium Skin Tone, Boy: Medium Skin Tone, Baby: Medium Skin Tone" }, // 1f469-1f3fd-200d-1f466-1f3fd-200d-1f476-1f3fd
            { "\U0001f469\U0001f3fd\u200d\U0001f466\U0001f3fd\u200d\U0001f467\U0001f3fd", "Family - Woman: Medium Skin Tone, Boy: Medium Skin Tone, Girl: Medium Skin Tone" }, // 1f469-1f3fd-200d-1f466-1f3fd-200d-1f467-1f3fd
            { "\U0001f469\U0001f3fd\u200d\U0001f466\U0001f3fd\u200d\U0001f466\U0001f3fd", "Family - Woman: Medium Skin Tone, Boy: Medium Skin Tone, Boy: Medium Skin Tone" }, // 1f469-1f3fd-200d-1f466-1f3fd-200d-1f466-1f3fd
            { "\U0001f469\U0001f3fc\u200d\U0001f476\U0001f3fc\u200d\U0001f476\U0001f3fc", "Family - Woman: Medium-Light Skin Tone, Baby: Medium-Light Skin Tone, Baby: Medium-Light Skin Tone" }, // 1f469-1f3fc-200d-1f476-1f3fc-200d-1f476-1f3fc
            { "\U0001f469\U0001f3fc\u200d\U0001f476\U0001f3fc\u200d\U0001f467\U0001f3fc", "Family - Woman: Medium-Light Skin Tone, Baby: Medium-Light Skin Tone, Girl: Medium-Light Skin Tone" }, // 1f469-1f3fc-200d-1f476-1f3fc-200d-1f467-1f3fc
            { "\U0001f469\U0001f3fc\u200d\U0001f476\U0001f3fc\u200d\U0001f466\U0001f3fc", "Family - Woman: Medium-Light Skin Tone, Baby: Medium-Light Skin Tone, Boy: Medium-Light Skin Tone" }, // 1f469-1f3fc-200d-1f476-1f3fc-200d-1f466-1f3fc
            { "\U0001f468\U0001f3fd\u200d\U0001f469\U0001f3fd\u200d\U0001f467\U0001f3fd\u200d\U0001f467\U0001f3fd", "Family - Man: Medium Skin Tone, Woman: Medium Skin Tone, Girl: Medium Skin Tone, Girl: Medium Skin Tone" }, // 1f468-1f3fd-200d-1f469-1f3fd-200d-1f467-1f3fd-200d-1f467-1f3fd
            { "\U0001f468\U0001f3fd\u200d\U0001f469\U0001f3fd\u200d\U0001f467\U0001f3fd\u200d\U0001f466\U0001f3fd", "Family - Man: Medium Skin Tone, Woman: Medium Skin Tone, Girl: Medium Skin Tone, Boy: Medium Skin Tone" }, // 1f468-1f3fd-200d-1f469-1f3fd-200d-1f467-1f3fd-200d-1f466-1f3fd
            { "\U0001f468\U0001f3fd\u200d\U0001f469\U0001f3fd\u200d\U0001f466\U0001f3fd\u200d\U0001f476\U0001f3fd", "Family - Man: Medium Skin Tone, Woman: Medium Skin Tone, Boy: Medium Skin Tone, Baby: Medium Skin Tone" }, // 1f468-1f3fd-200d-1f469-1f3fd-200d-1f466-1f3fd-200d-1f476-1f3fd
            { "\U0001f468\U0001f3fd\u200d\U0001f469\U0001f3fd\u200d\U0001f466\U0001f3fd\u200d\U0001f467\U0001f3fd", "Family - Man: Medium Skin Tone, Woman: Medium Skin Tone, Boy: Medium Skin Tone, Girl: Medium Skin Tone" }, // 1f468-1f3fd-200d-1f469-1f3fd-200d-1f466-1f3fd-200d-1f467-1f3fd
            { "\U0001f468\U0001f3fd\u200d\U0001f469\U0001f3fd\u200d\U0001f466\U0001f3fd\u200d\U0001f466\U0001f3fd", "Family - Man: Medium Skin Tone, Woman: Medium Skin Tone, Boy: Medium Skin Tone, Boy: Medium Skin Tone" }, // 1f468-1f3fd-200d-1f469-1f3fd-200d-1f466-1f3fd-200d-1f466-1f3fd
            { "\U0001f468\U0001f3fd\u200d\U0001f468\U0001f3fd\u200d\U0001f476\U0001f3fd\u200d\U0001f476\U0001f3fd", "Family - Man: Medium Skin Tone, Man: Medium Skin Tone, Baby: Medium Skin Tone, Baby: Medium Skin Tone" }, // 1f468-1f3fd-200d-1f468-1f3fd-200d-1f476-1f3fd-200d-1f476-1f3fd
            { "\U0001f468\U0001f3fd\u200d\U0001f468\U0001f3fd\u200d\U0001f476\U0001f3fd\u200d\U0001f467\U0001f3fd", "Family - Man: Medium Skin Tone, Man: Medium Skin Tone, Baby: Medium Skin Tone, Girl: Medium Skin Tone" }, // 1f468-1f3fd-200d-1f468-1f3fd-200d-1f476-1f3fd-200d-1f467-1f3fd
            { "\U0001f468\U0001f3fd\u200d\U0001f468\U0001f3fd\u200d\U0001f476\U0001f3fd\u200d\U0001f466\U0001f3fd", "Family - Man: Medium Skin Tone, Man: Medium Skin Tone, Baby: Medium Skin Tone, Boy: Medium Skin Tone" }, // 1f468-1f3fd-200d-1f468-1f3fd-200d-1f476-1f3fd-200d-1f466-1f3fd
            { "\U0001f468\U0001f3fd\u200d\U0001f468\U0001f3fd\u200d\U0001f467\U0001f3fd\u200d\U0001f476\U0001f3fd", "Family - Man: Medium Skin Tone, Man: Medium Skin Tone, Girl: Medium Skin Tone, Baby: Medium Skin Tone" }, // 1f468-1f3fd-200d-1f468-1f3fd-200d-1f467-1f3fd-200d-1f476-1f3fd
            { "\U0001f468\U0001f3fd\u200d\U0001f468\U0001f3fd\u200d\U0001f467\U0001f3fd\u200d\U0001f467\U0001f3fd", "Family - Man: Medium Skin Tone, Man: Medium Skin Tone, Girl: Medium Skin Tone, Girl: Medium Skin Tone" }, // 1f468-1f3fd-200d-1f468-1f3fd-200d-1f467-1f3fd-200d-1f467-1f3fd
            { "\U0001f468\U0001f3fd\u200d\U0001f468\U0001f3fd\u200d\U0001f467\U0001f3fd\u200d\U0001f466\U0001f3fd", "Family - Man: Medium Skin Tone, Man: Medium Skin Tone, Girl: Medium Skin Tone, Boy: Medium Skin Tone" }, // 1f468-1f3fd-200d-1f468-1f3fd-200d-1f467-1f3fd-200d-1f466-1f3fd
            { "\U0001f468\U0001f3fd\u200d\U0001f468\U0001f3fd\u200d\U0001f466\U0001f3fd\u200d\U0001f476\U0001f3fd", "Family - Man: Medium Skin Tone, Man: Medium Skin Tone, Boy: Medium Skin Tone, Baby: Medium Skin Tone" }, // 1f468-1f3fd-200d-1f468-1f3fd-200d-1f466-1f3fd-200d-1f476-1f3fd
            { "\U0001f468\U0001f3fd\u200d\U0001f468\U0001f3fd\u200d\U0001f466\U0001f3fd\u200d\U0001f467\U0001f3fd", "Family - Man: Medium Skin Tone, Man: Medium Skin Tone, Boy: Medium Skin Tone, Girl: Medium Skin Tone" }, // 1f468-1f3fd-200d-1f468-1f3fd-200d-1f466-1f3fd-200d-1f467-1f3fd
            { "\U0001f468\U0001f3fd\u200d\U0001f468\U0001f3fd\u200d\U0001f466\U0001f3fd\u200d\U0001f466\U0001f3fd", "Family - Man: Medium Skin Tone, Man: Medium Skin Tone, Boy: Medium Skin Tone, Boy: Medium Skin Tone" }, // 1f468-1f3fd-200d-1f468-1f3fd-200d-1f466-1f3fd-200d-1f466-1f3fd
            { "\U0001f468\U0001f3fc\u200d\U0001f469\U0001f3fc\u200d\U0001f476\U0001f3fc\u200d\U0001f476\U0001f3fc", "Family - Man: Medium-Light Skin Tone, Woman: Medium-Light Skin Tone, Baby: Medium-Light Skin Tone, Baby: Medium-Light Skin Tone" }, // 1f468-1f3fc-200d-1f469-1f3fc-200d-1f476-1f3fc-200d-1f476-1f3fc
            { "\U0001f468\U0001f3fc\u200d\U0001f469\U0001f3fc\u200d\U0001f476\U0001f3fc\u200d\U0001f467\U0001f3fc", "Family - Man: Medium-Light Skin Tone, Woman: Medium-Light Skin Tone, Baby: Medium-Light Skin Tone, Girl: Medium-Light Skin Tone" }, // 1f468-1f3fc-200d-1f469-1f3fc-200d-1f476-1f3fc-200d-1f467-1f3fc
            { "\U0001f468\U0001f3fc\u200d\U0001f468\U0001f3fc\u200d\U0001f476\U0001f3fc\u200d\U0001f476\U0001f3fc", "Family - Man: Medium-Light Skin Tone, Man: Medium-Light Skin Tone, Baby: Medium-Light Skin Tone, Baby: Medium-Light Skin Tone" }, // 1f468-1f3fc-200d-1f468-1f3fc-200d-1f476-1f3fc-200d-1f476-1f3fc
            { "\U0001f468\U0001f3fc\u200d\U0001f468\U0001f3fc\u200d\U0001f476\U0001f3fc\u200d\U0001f467\U0001f3fc", "Family - Man: Medium-Light Skin Tone, Man: Medium-Light Skin Tone, Baby: Medium-Light Skin Tone, Girl: Medium-Light Skin Tone" }, // 1f468-1f3fc-200d-1f468-1f3fc-200d-1f476-1f3fc-200d-1f467-1f3fc
            { "\U0001f468\U0001f3fc\u200d\U0001f468\U0001f3fc\u200d\U0001f476\U0001f3fc\u200d\U0001f466\U0001f3fc", "Family - Man: Medium-Light Skin Tone, Man: Medium-Light Skin Tone, Baby: Medium-Light Skin Tone, Boy: Medium-Light Skin Tone" }, // 1f468-1f3fc-200d-1f468-1f3fc-200d-1f476-1f3fc-200d-1f466-1f3fc
            { "\U0001f468\U0001f3fc\u200d\U0001f468\U0001f3fc\u200d\U0001f467\U0001f3fc\u200d\U0001f476\U0001f3fc", "Family - Man: Medium-Light Skin Tone, Man: Medium-Light Skin Tone, Girl: Medium-Light Skin Tone, Baby: Medium-Light Skin Tone" }, // 1f468-1f3fc-200d-1f468-1f3fc-200d-1f467-1f3fc-200d-1f476-1f3fc
            { "\U0001f468\U0001f3fc\u200d\U0001f468\U0001f3fc\u200d\U0001f467\U0001f3fc\u200d\U0001f467\U0001f3fc", "Family - Man: Medium-Light Skin Tone, Man: Medium-Light Skin Tone, Girl: Medium-Light Skin Tone, Girl: Medium-Light Skin Tone" }, // 1f468-1f3fc-200d-1f468-1f3fc-200d-1f467-1f3fc-200d-1f467-1f3fc
            { "\U0001f468\U0001f3fc\u200d\U0001f468\U0001f3fc\u200d\U0001f467\U0001f3fc\u200d\U0001f466\U0001f3fc", "Family - Man: Medium-Light Skin Tone, Man: Medium-Light Skin Tone, Girl: Medium-Light Skin Tone, Boy: Medium-Light Skin Tone" }, // 1f468-1f3fc-200d-1f468-1f3fc-200d-1f467-1f3fc-200d-1f466-1f3fc
            { "\U0001f468\U0001f3fc\u200d\U0001f468\U0001f3fc\u200d\U0001f466\U0001f3fc\u200d\U0001f476\U0001f3fc", "Family - Man: Medium-Light Skin Tone, Man: Medium-Light Skin Tone, Boy: Medium-Light Skin Tone, Baby: Medium-Light Skin Tone" }, // 1f468-1f3fc-200d-1f468-1f3fc-200d-1f466-1f3fc-200d-1f476-1f3fc
            { "\U0001f468\U0001f3fc\u200d\U0001f468\U0001f3fc\u200d\U0001f466\U0001f3fc\u200d\U0001f467\U0001f3fc", "Family - Man: Medium-Light Skin Tone, Man: Medium-Light Skin Tone, Boy: Medium-Light Skin Tone, Girl: Medium-Light Skin Tone" }, // 1f468-1f3fc-200d-1f468-1f3fc-200d-1f466-1f3fc-200d-1f467-1f3fc
            { "\U0001f468\U0001f3fc\u200d\U0001f468\U0001f3fc\u200d\U0001f466\U0001f3fc\u200d\U0001f466\U0001f3fc", "Family - Man: Medium-Light Skin Tone, Man: Medium-Light Skin Tone, Boy: Medium-Light Skin Tone, Boy: Medium-Light Skin Tone" }, // 1f468-1f3fc-200d-1f468-1f3fc-200d-1f466-1f3fc-200d-1f466-1f3fc
            { "\U0001f468\U0001f3fb\u200d\U0001f469\U0001f3fb\u200d\U0001f476\U0001f3fb\u200d\U0001f476\U0001f3fb", "Family - Man: Light Skin Tone, Woman: Light Skin Tone, Baby: Light Skin Tone, Baby: Light Skin Tone" }, // 1f468-1f3fb-200d-1f469-1f3fb-200d-1f476-1f3fb-200d-1f476-1f3fb
            { "\U0001f468\U0001f3fb\u200d\U0001f469\U0001f3fb\u200d\U0001f476\U0001f3fb\u200d\U0001f467\U0001f3fb", "Family - Man: Light Skin Tone, Woman: Light Skin Tone, Baby: Light Skin Tone, Girl: Light Skin Tone" }, // 1f468-1f3fb-200d-1f469-1f3fb-200d-1f476-1f3fb-200d-1f467-1f3fb
            { "\U0001f468\U0001f3fb\u200d\U0001f469\U0001f3fb\u200d\U0001f476\U0001f3fb\u200d\U0001f466\U0001f3fb", "Family - Man: Light Skin Tone, Woman: Light Skin Tone, Baby: Light Skin Tone, Boy: Light Skin Tone" }, // 1f468-1f3fb-200d-1f469-1f3fb-200d-1f476-1f3fb-200d-1f466-1f3fb
            { "\U0001f468\U0001f3fb\u200d\U0001f469\U0001f3fb\u200d\U0001f467\U0001f3fb\u200d\U0001f476\U0001f3fb", "Family - Man: Light Skin Tone, Woman: Light Skin Tone, Girl: Light Skin Tone, Baby: Light Skin Tone" }, // 1f468-1f3fb-200d-1f469-1f3fb-200d-1f467-1f3fb-200d-1f476-1f3fb
            { "\U0001f468\U0001f3fb\u200d\U0001f469\U0001f3fb\u200d\U0001f467\U0001f3fb\u200d\U0001f467\U0001f3fb", "Family - Man: Light Skin Tone, Woman: Light Skin Tone, Girl: Light Skin Tone, Girl: Light Skin Tone" }, // 1f468-1f3fb-200d-1f469-1f3fb-200d-1f467-1f3fb-200d-1f467-1f3fb
            { "\U0001f468\U0001f3fb\u200d\U0001f469\U0001f3fb\u200d\U0001f467\U0001f3fb\u200d\U0001f466\U0001f3fb", "Family - Man: Light Skin Tone, Woman: Light Skin Tone, Girl: Light Skin Tone, Boy: Light Skin Tone" }, // 1f468-1f3fb-200d-1f469-1f3fb-200d-1f467-1f3fb-200d-1f466-1f3fb
            { "\U0001f468\U0001f3fb\u200d\U0001f469\U0001f3fb\u200d\U0001f466\U0001f3fb\u200d\U0001f476\U0001f3fb", "Family - Man: Light Skin Tone, Woman: Light Skin Tone, Boy: Light Skin Tone, Baby: Light Skin Tone" }, // 1f468-1f3fb-200d-1f469-1f3fb-200d-1f466-1f3fb-200d-1f476-1f3fb
            { "\U0001f469\U0001f3ff\u200d\U0001f469\U0001f3ff\u200d\U0001f476\U0001f3ff", "Family - Woman: Dark Skin Tone, Woman: Dark Skin Tone, Baby: Dark Skin Tone" }, // 1f469-1f3ff-200d-1f469-1f3ff-200d-1f476-1f3ff
            { "\U0001f469\U0001f3ff\u200d\U0001f469\U0001f3ff\u200d\U0001f467\U0001f3ff", "Family - Woman: Dark Skin Tone, Woman: Dark Skin Tone, Girl: Dark Skin Tone" }, // 1f469-1f3ff-200d-1f469-1f3ff-200d-1f467-1f3ff
            { "\U0001f469\U0001f3ff\u200d\U0001f469\U0001f3ff\u200d\U0001f466\U0001f3ff", "Family - Woman: Dark Skin Tone, Woman: Dark Skin Tone, Boy: Dark Skin Tone" }, // 1f469-1f3ff-200d-1f469-1f3ff-200d-1f466-1f3ff
            { "\U0001f469\U0001f3ff\u200d\U0001f468\U0001f3ff\u200d\U0001f476\U0001f3ff", "Family - Woman: Dark Skin Tone, Man: Dark Skin Tone, Baby: Dark Skin Tone" }, // 1f469-1f3ff-200d-1f468-1f3ff-200d-1f476-1f3ff
            { "\U0001f469\U0001f3ff\u200d\U0001f468\U0001f3ff\u200d\U0001f467\U0001f3ff", "Family - Woman: Dark Skin Tone, Man: Dark Skin Tone, Girl: Dark Skin Tone" }, // 1f469-1f3ff-200d-1f468-1f3ff-200d-1f467-1f3ff
            { "\U0001f469\U0001f3ff\u200d\U0001f468\U0001f3ff\u200d\U0001f466\U0001f3ff", "Family - Woman: Dark Skin Tone, Man: Dark Skin Tone, Boy: Dark Skin Tone" }, // 1f469-1f3ff-200d-1f468-1f3ff-200d-1f466-1f3ff
            { "\U0001f469\U0001f3fe\u200d\U0001f469\U0001f3fe\u200d\U0001f476\U0001f3fe", "Family - Woman: Medium-Dark Skin Tone, Woman: Medium-Dark Skin Tone, Baby: Medium-Dark Skin Tone" }, // 1f469-1f3fe-200d-1f469-1f3fe-200d-1f476-1f3fe
            { "\U0001f469\U0001f3fe\u200d\U0001f469\U0001f3fe\u200d\U0001f467\U0001f3fe", "Family - Woman: Medium-Dark Skin Tone, Woman: Medium-Dark Skin Tone, Girl: Medium-Dark Skin Tone" }, // 1f469-1f3fe-200d-1f469-1f3fe-200d-1f467-1f3fe
            { "\U0001f469\U0001f3fe\u200d\U0001f469\U0001f3fe\u200d\U0001f466\U0001f3fe", "Family - Woman: Medium-Dark Skin Tone, Woman: Medium-Dark Skin Tone, Boy: Medium-Dark Skin Tone" }, // 1f469-1f3fe-200d-1f469-1f3fe-200d-1f466-1f3fe
            { "\U0001f469\U0001f3fe\u200d\U0001f468\U0001f3fe\u200d\U0001f476\U0001f3fe", "Family - Woman: Medium-Dark Skin Tone, Man: Medium-Dark Skin Tone, Baby: Medium-Dark Skin Tone" }, // 1f469-1f3fe-200d-1f468-1f3fe-200d-1f476-1f3fe
            { "\U0001f469\U0001f3fe\u200d\U0001f468\U0001f3fe\u200d\U0001f467\U0001f3fe", "Family - Woman: Medium-Dark Skin Tone, Man: Medium-Dark Skin Tone, Girl: Medium-Dark Skin Tone" }, // 1f469-1f3fe-200d-1f468-1f3fe-200d-1f467-1f3fe
            { "\U0001f469\U0001f3fe\u200d\U0001f468\U0001f3fe\u200d\U0001f466\U0001f3fe", "Family - Woman: Medium-Dark Skin Tone, Man: Medium-Dark Skin Tone, Boy: Medium-Dark Skin Tone" }, // 1f469-1f3fe-200d-1f468-1f3fe-200d-1f466-1f3fe
            { "\U0001f469\U0001f3ff\u200d\U0001f469\U0001f3ff\u200d\U0001f476\U0001f3ff\u200d\U0001f476\U0001f3ff", "Family - Woman: Dark Skin Tone, Woman: Dark Skin Tone, Baby: Dark Skin Tone, Baby: Dark Skin Tone" }, // 1f469-1f3ff-200d-1f469-1f3ff-200d-1f476-1f3ff-200d-1f476-1f3ff
            { "\U0001f469\U0001f3ff\u200d\U0001f469\U0001f3ff\u200d\U0001f476\U0001f3ff\u200d\U0001f467\U0001f3ff", "Family - Woman: Dark Skin Tone, Woman: Dark Skin Tone, Baby: Dark Skin Tone, Girl: Dark Skin Tone" }, // 1f469-1f3ff-200d-1f469-1f3ff-200d-1f476-1f3ff-200d-1f467-1f3ff
            { "\U0001f469\U0001f3fb\u200d\U0001f469\U0001f3fb\u200d\U0001f476\U0001f3fb\u200d\U0001f467\U0001f3fb", "Family - Woman: Light Skin Tone, Woman: Light Skin Tone, Baby: Light Skin Tone, Girl: Light Skin Tone" }, // 1f469-1f3fb-200d-1f469-1f3fb-200d-1f476-1f3fb-200d-1f467-1f3fb
            { "\U0001f469\U0001f3fb\u200d\U0001f469\U0001f3fb\u200d\U0001f476\U0001f3fb\u200d\U0001f466\U0001f3fb", "Family - Woman: Light Skin Tone, Woman: Light Skin Tone, Baby: Light Skin Tone, Boy: Light Skin Tone" }, // 1f469-1f3fb-200d-1f469-1f3fb-200d-1f476-1f3fb-200d-1f466-1f3fb
            { "\U0001f469\U0001f3fb\u200d\U0001f469\U0001f3fb\u200d\U0001f467\U0001f3fb\u200d\U0001f476\U0001f3fb", "Family - Woman: Light Skin Tone, Woman: Light Skin Tone, Girl: Light Skin Tone, Baby: Light Skin Tone" }, // 1f469-1f3fb-200d-1f469-1f3fb-200d-1f467-1f3fb-200d-1f476-1f3fb
            { "\U0001f469\U0001f3fb\u200d\U0001f469\U0001f3fb\u200d\U0001f467\U0001f3fb\u200d\U0001f467\U0001f3fb", "Family - Woman: Light Skin Tone, Woman: Light Skin Tone, Girl: Light Skin Tone, Girl: Light Skin Tone" }, // 1f469-1f3fb-200d-1f469-1f3fb-200d-1f467-1f3fb-200d-1f467-1f3fb
            { "\U0001f469\U0001f3fb\u200d\U0001f469\U0001f3fb\u200d\U0001f467\U0001f3fb\u200d\U0001f466\U0001f3fb", "Family - Woman: Light Skin Tone, Woman: Light Skin Tone, Girl: Light Skin Tone, Boy: Light Skin Tone" }, // 1f469-1f3fb-200d-1f469-1f3fb-200d-1f467-1f3fb-200d-1f466-1f3fb
            { "\U0001f469\U0001f3fb\u200d\U0001f469\U0001f3fb\u200d\U0001f466\U0001f3fb\u200d\U0001f476\U0001f3fb", "Family - Woman: Light Skin Tone, Woman: Light Skin Tone, Boy: Light Skin Tone, Baby: Light Skin Tone" }, // 1f469-1f3fb-200d-1f469-1f3fb-200d-1f466-1f3fb-200d-1f476-1f3fb
            { "\U0001f469\U0001f3fb\u200d\U0001f469\U0001f3fb\u200d\U0001f466\U0001f3fb\u200d\U0001f467\U0001f3fb", "Family - Woman: Light Skin Tone, Woman: Light Skin Tone, Boy: Light Skin Tone, Girl: Light Skin Tone" }, // 1f469-1f3fb-200d-1f469-1f3fb-200d-1f466-1f3fb-200d-1f467-1f3fb
            { "\U0001f469\U0001f3fb\u200d\U0001f469\U0001f3fb\u200d\U0001f466\U0001f3fb\u200d\U0001f466\U0001f3fb", "Family - Woman: Light Skin Tone, Woman: Light Skin Tone, Boy: Light Skin Tone, Boy: Light Skin Tone" }, // 1f469-1f3fb-200d-1f469-1f3fb-200d-1f466-1f3fb-200d-1f466-1f3fb
            { "\U0001f469\U0001f3fb\u200d\U0001f468\U0001f3fb\u200d\U0001f476\U0001f3fb\u200d\U0001f476\U0001f3fb", "Family - Woman: Light Skin Tone, Man: Light Skin Tone, Baby: Light Skin Tone, Baby: Light Skin Tone" }, // 1f469-1f3fb-200d-1f468-1f3fb-200d-1f476-1f3fb-200d-1f476-1f3fb
            { "\U0001f469\U0001f3fb\u200d\U0001f468\U0001f3fb\u200d\U0001f476\U0001f3fb\u200d\U0001f467\U0001f3fb", "Family - Woman: Light Skin Tone, Man: Light Skin Tone, Baby: Light Skin Tone, Girl: Light Skin Tone" }, // 1f469-1f3fb-200d-1f468-1f3fb-200d-1f476-1f3fb-200d-1f467-1f3fb
            { "\U0001f469\U0001f3fb\u200d\U0001f468\U0001f3fb\u200d\U0001f476\U0001f3fb\u200d\U0001f466\U0001f3fb", "Family - Woman: Light Skin Tone, Man: Light Skin Tone, Baby: Light Skin Tone, Boy: Light Skin Tone" }, // 1f469-1f3fb-200d-1f468-1f3fb-200d-1f476-1f3fb-200d-1f466-1f3fb
            { "\U0001f469\U0001f3fb\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468", "Kiss - Woman: Light Skin Tone, Man" }, // 1f469-1f3fb-200d-2764-fe0f-200d-1f48b-200d-1f468
            { "\U0001f468\U0001f3ff\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3fd", "Kiss - Man: Dark Skin Tone, Woman: Medium Skin Tone" }, // 1f468-1f3ff-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3fd
            { "\U0001f468\U0001f3fd\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3fb", "Kiss - Man: Medium Skin Tone, Man: Light Skin Tone" }, // 1f468-1f3fd-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3fb
            { "\U0001f469\U0001f3fc\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3fe", "Kiss - Woman: Medium-Light Skin Tone, Woman: Medium-Dark Skin Tone" }, // 1f469-1f3fc-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3fe
            { "\U0001f469\U0001f3fd\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3fe", "Couple With Heart - Woman: Medium Skin Tone, Man: Medium-Dark Skin Tone" }, // 1f469-1f3fd-200d-2764-fe0f-200d-1f468-1f3fe
            { "\U0001f469\U0001f3fb\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3fe", "Couple With Heart - Woman: Light Skin Tone, Woman: Medium-Dark Skin Tone" }, // 1f469-1f3fb-200d-2764-fe0f-200d-1f469-1f3fe
            { "\U0001f469\u200d\U0001f469\u200d\U0001f476\u200d\U0001f476", "Family: Woman, Woman, Baby, Baby" }, // 1f469-200d-1f469-200d-1f476-200d-1f476
            { "\U0001f468\U0001f3fd\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468", "Kiss - Man: Medium Skin Tone, Man" }, // 1f468-1f3fd-200d-2764-fe0f-200d-1f48b-200d-1f468
            { "\U0001f468\U0001f3ff\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3fb", "Couple With Heart - Man: Dark Skin Tone, Woman: Light Skin Tone" }, // 1f468-1f3ff-200d-2764-fe0f-200d-1f469-1f3fb
            { "\U0001f469\U0001f3fd\u200d\u2764\ufe0f\u200d\U0001f469", "Couple With Heart - Woman: Medium Skin Tone, Woman" }, // 1f469-1f3fd-200d-2764-fe0f-200d-1f469
            { "\U0001f469\u200d\U0001f468\u200d\U0001f476\u200d\U0001f476", "Family: Woman, Man, Baby, Baby" }, // 1f469-200d-1f468-200d-1f476-200d-1f476
            { "\U0001f468\U0001f3fc\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3fd", "Couple With Heart - Man: Medium-Light Skin Tone, Man: Medium Skin Tone" }, // 1f468-1f3fc-200d-2764-fe0f-200d-1f468-1f3fd
            { "\U0001f468\U0001f3fd\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3ff", "Couple With Heart - Man: Medium Skin Tone, Man: Dark Skin Tone" }, // 1f468-1f3fd-200d-2764-fe0f-200d-1f468-1f3ff
            { "\U0001f468\U0001f3fb\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3ff", "Couple With Heart - Man: Light Skin Tone, Woman: Dark Skin Tone" }, // 1f468-1f3fb-200d-2764-fe0f-200d-1f469-1f3ff
            { "\U0001f468\U0001f3ff\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468", "Kiss - Man: Dark Skin Tone, Man" }, // 1f468-1f3ff-200d-2764-fe0f-200d-1f48b-200d-1f468
            { "\U0001f469\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3fe", "Couple With Heart - Woman, Man: Medium-Dark Skin Tone" }, // 1f469-200d-2764-fe0f-200d-1f468-1f3fe
            { "\U0001f468\U0001f3fd\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3fb", "Couple With Heart - Man: Medium Skin Tone, Man: Light Skin Tone" }, // 1f468-1f3fd-200d-2764-fe0f-200d-1f468-1f3fb
            { "\U0001f468\U0001f3fb\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3fd", "Kiss - Man: Light Skin Tone, Woman: Medium Skin Tone" }, // 1f468-1f3fb-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3fd
            { "\U0001f468\U0001f3fb\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3fb", "Couple With Heart - Man: Light Skin Tone, Woman: Light Skin Tone" }, // 1f468-1f3fb-200d-2764-fe0f-200d-1f469-1f3fb
            { "\U0001f469\U0001f3fd\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468", "Kiss - Woman: Medium Skin Tone, Man" }, // 1f469-1f3fd-200d-2764-fe0f-200d-1f48b-200d-1f468
            { "\U0001f469\U0001f3ff\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3ff", "Kiss - Woman: Dark Skin Tone, Woman: Dark Skin Tone" }, // 1f469-1f3ff-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3ff
            { "\U0001f469\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3ff", "Kiss - Woman, Woman: Dark Skin Tone" }, // 1f469-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3ff
            { "\U0001f468\u200d\U0001f469\u200d\U0001f476\u200d\U0001f466", "Family: Man, Woman, Baby, Boy" }, // 1f468-200d-1f469-200d-1f476-200d-1f466
            { "\U0001f468\u200d\U0001f469\u200d\U0001f476\u200d\U0001f467", "Family: Man, Woman, Baby, Girl" }, // 1f468-200d-1f469-200d-1f476-200d-1f467
            { "\U0001f469\U0001f3fd\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469", "Kiss - Woman: Medium Skin Tone, Woman" }, // 1f469-1f3fd-200d-2764-fe0f-200d-1f48b-200d-1f469
            { "\U0001f468\U0001f3fe\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3fe", "Kiss - Man: Medium-Dark Skin Tone, Man: Medium-Dark Skin Tone" }, // 1f468-1f3fe-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3fe
            { "\U0001f468\U0001f3fb\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3fc", "Couple With Heart - Man: Light Skin Tone, Woman: Medium-Light Skin Tone" }, // 1f468-1f3fb-200d-2764-fe0f-200d-1f469-1f3fc
            { "\U0001f468\u200d\u2764\ufe0f\u200d\U0001f469", "Couple With Heart - Man, Woman" }, // 1f468-200d-2764-fe0f-200d-1f469
            { "\U0001f468\U0001f3fb\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3fe", "Kiss - Man: Light Skin Tone, Woman: Medium-Dark Skin Tone" }, // 1f468-1f3fb-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3fe
            { "\U0001f468\U0001f3fd\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3fc", "Couple With Heart - Man: Medium Skin Tone, Man: Medium-Light Skin Tone" }, // 1f468-1f3fd-200d-2764-fe0f-200d-1f468-1f3fc
            { "\U0001f469\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3fd", "Couple With Heart - Woman, Man: Medium Skin Tone" }, // 1f469-200d-2764-fe0f-200d-1f468-1f3fd
            { "\U0001f468\U0001f3fc\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3fd", "Kiss - Man: Medium-Light Skin Tone, Woman: Medium Skin Tone" }, // 1f468-1f3fc-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3fd
            { "\U0001f468\U0001f3fe\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3fd", "Couple With Heart - Man: Medium-Dark Skin Tone, Woman: Medium Skin Tone" }, // 1f468-1f3fe-200d-2764-fe0f-200d-1f469-1f3fd
            { "\U0001f469\U0001f3fe\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3ff", "Couple With Heart - Woman: Medium-Dark Skin Tone, Woman: Dark Skin Tone" }, // 1f469-1f3fe-200d-2764-fe0f-200d-1f469-1f3ff
            { "\U0001f469\U0001f3fc\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3ff", "Couple With Heart - Woman: Medium-Light Skin Tone, Man: Dark Skin Tone" }, // 1f469-1f3fc-200d-2764-fe0f-200d-1f468-1f3ff
            { "\U0001f468\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3ff", "Kiss - Man, Woman: Dark Skin Tone" }, // 1f468-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3ff
            { "\U0001f468\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3fd", "Kiss - Man, Woman: Medium Skin Tone" }, // 1f468-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3fd
            { "\U0001f469\U0001f3ff\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3fb", "Couple With Heart - Woman: Dark Skin Tone, Woman: Light Skin Tone" }, // 1f469-1f3ff-200d-2764-fe0f-200d-1f469-1f3fb
            { "\U0001f469\U0001f3fc\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3fd", "Couple With Heart - Woman: Medium-Light Skin Tone, Man: Medium Skin Tone" }, // 1f469-1f3fc-200d-2764-fe0f-200d-1f468-1f3fd
            { "\U0001f469\U0001f3fe\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3fd", "Couple With Heart - Woman: Medium-Dark Skin Tone, Woman: Medium Skin Tone" }, // 1f469-1f3fe-200d-2764-fe0f-200d-1f469-1f3fd
            { "\U0001f469\U0001f3fb\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3fb", "Kiss - Woman: Light Skin Tone, Woman: Light Skin Tone" }, // 1f469-1f3fb-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3fb
            { "\U0001f468\U0001f3fe\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3ff", "Couple With Heart - Man: Medium-Dark Skin Tone, Woman: Dark Skin Tone" }, // 1f468-1f3fe-200d-2764-fe0f-200d-1f469-1f3ff
            { "\U0001f468\U0001f3fc\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3ff", "Kiss - Man: Medium-Light Skin Tone, Woman: Dark Skin Tone" }, // 1f468-1f3fc-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3ff
            { "\U0001f469\U0001f3fb\u200d\U0001f468\U0001f3fb\u200d\U0001f466\U0001f3fb\u200d\U0001f476\U0001f3fb", "Family - Woman: Light Skin Tone, Man: Light Skin Tone, Boy: Light Skin Tone, Baby: Light Skin Tone" }, // 1f469-1f3fb-200d-1f468-1f3fb-200d-1f466-1f3fb-200d-1f476-1f3fb
            { "\U0001f469\U0001f3fb\u200d\U0001f468\U0001f3fb\u200d\U0001f466\U0001f3fb\u200d\U0001f467\U0001f3fb", "Family - Woman: Light Skin Tone, Man: Light Skin Tone, Boy: Light Skin Tone, Girl: Light Skin Tone" }, // 1f469-1f3fb-200d-1f468-1f3fb-200d-1f466-1f3fb-200d-1f467-1f3fb
            { "\U0001f469\U0001f3fb\u200d\U0001f468\U0001f3fb\u200d\U0001f466\U0001f3fb\u200d\U0001f466\U0001f3fb", "Family - Woman: Light Skin Tone, Man: Light Skin Tone, Boy: Light Skin Tone, Boy: Light Skin Tone" }, // 1f469-1f3fb-200d-1f468-1f3fb-200d-1f466-1f3fb-200d-1f466-1f3fb
            { "\U0001f468\U0001f3ff\u200d\U0001f469\U0001f3ff\u200d\U0001f476\U0001f3ff\u200d\U0001f476\U0001f3ff", "Family - Man: Dark Skin Tone, Woman: Dark Skin Tone, Baby: Dark Skin Tone, Baby: Dark Skin Tone" }, // 1f468-1f3ff-200d-1f469-1f3ff-200d-1f476-1f3ff-200d-1f476-1f3ff
            { "\U0001f468\U0001f3ff\u200d\U0001f469\U0001f3ff\u200d\U0001f476\U0001f3ff\u200d\U0001f467\U0001f3ff", "Family - Man: Dark Skin Tone, Woman: Dark Skin Tone, Baby: Dark Skin Tone, Girl: Dark Skin Tone" }, // 1f468-1f3ff-200d-1f469-1f3ff-200d-1f476-1f3ff-200d-1f467-1f3ff
            { "\U0001f468\U0001f3ff\u200d\U0001f469\U0001f3ff\u200d\U0001f476\U0001f3ff\u200d\U0001f466\U0001f3ff", "Family - Man: Dark Skin Tone, Woman: Dark Skin Tone, Baby: Dark Skin Tone, Boy: Dark Skin Tone" }, // 1f468-1f3ff-200d-1f469-1f3ff-200d-1f476-1f3ff-200d-1f466-1f3ff
            { "\U0001f468\U0001f3ff\u200d\U0001f469\U0001f3ff\u200d\U0001f467\U0001f3ff\u200d\U0001f476\U0001f3ff", "Family - Man: Dark Skin Tone, Woman: Dark Skin Tone, Girl: Dark Skin Tone, Baby: Dark Skin Tone" }, // 1f468-1f3ff-200d-1f469-1f3ff-200d-1f467-1f3ff-200d-1f476-1f3ff
            { "\U0001f468\U0001f3ff\u200d\U0001f469\U0001f3ff\u200d\U0001f467\U0001f3ff\u200d\U0001f467\U0001f3ff", "Family - Man: Dark Skin Tone, Woman: Dark Skin Tone, Girl: Dark Skin Tone, Girl: Dark Skin Tone" }, // 1f468-1f3ff-200d-1f469-1f3ff-200d-1f467-1f3ff-200d-1f467-1f3ff
            { "\U0001f468\U0001f3ff\u200d\U0001f469\U0001f3ff\u200d\U0001f467\U0001f3ff\u200d\U0001f466\U0001f3ff", "Family - Man: Dark Skin Tone, Woman: Dark Skin Tone, Girl: Dark Skin Tone, Boy: Dark Skin Tone" }, // 1f468-1f3ff-200d-1f469-1f3ff-200d-1f467-1f3ff-200d-1f466-1f3ff
            { "\U0001f468\U0001f3ff\u200d\U0001f469\U0001f3ff\u200d\U0001f466\U0001f3ff\u200d\U0001f476\U0001f3ff", "Family - Man: Dark Skin Tone, Woman: Dark Skin Tone, Boy: Dark Skin Tone, Baby: Dark Skin Tone" }, // 1f468-1f3ff-200d-1f469-1f3ff-200d-1f466-1f3ff-200d-1f476-1f3ff
            { "\U0001f468\U0001f3ff\u200d\U0001f469\U0001f3ff\u200d\U0001f466\U0001f3ff\u200d\U0001f467\U0001f3ff", "Family - Man: Dark Skin Tone, Woman: Dark Skin Tone, Boy: Dark Skin Tone, Girl: Dark Skin Tone" }, // 1f468-1f3ff-200d-1f469-1f3ff-200d-1f466-1f3ff-200d-1f467-1f3ff
            { "\U0001f468\U0001f3ff\u200d\U0001f469\U0001f3ff\u200d\U0001f466\U0001f3ff\u200d\U0001f466\U0001f3ff", "Family - Man: Dark Skin Tone, Woman: Dark Skin Tone, Boy: Dark Skin Tone, Boy: Dark Skin Tone" }, // 1f468-1f3ff-200d-1f469-1f3ff-200d-1f466-1f3ff-200d-1f466-1f3ff
            { "\U0001f468\U0001f3ff\u200d\U0001f468\U0001f3ff\u200d\U0001f476\U0001f3ff\u200d\U0001f476\U0001f3ff", "Family - Man: Dark Skin Tone, Man: Dark Skin Tone, Baby: Dark Skin Tone, Baby: Dark Skin Tone" }, // 1f468-1f3ff-200d-1f468-1f3ff-200d-1f476-1f3ff-200d-1f476-1f3ff
            { "\U0001f468\U0001f3ff\u200d\U0001f468\U0001f3ff\u200d\U0001f476\U0001f3ff\u200d\U0001f467\U0001f3ff", "Family - Man: Dark Skin Tone, Man: Dark Skin Tone, Baby: Dark Skin Tone, Girl: Dark Skin Tone" }, // 1f468-1f3ff-200d-1f468-1f3ff-200d-1f476-1f3ff-200d-1f467-1f3ff
            { "\U0001f468\U0001f3ff\u200d\U0001f468\U0001f3ff\u200d\U0001f476\U0001f3ff\u200d\U0001f466\U0001f3ff", "Family - Man: Dark Skin Tone, Man: Dark Skin Tone, Baby: Dark Skin Tone, Boy: Dark Skin Tone" }, // 1f468-1f3ff-200d-1f468-1f3ff-200d-1f476-1f3ff-200d-1f466-1f3ff
            { "\U0001f468\U0001f3ff\u200d\U0001f468\U0001f3ff\u200d\U0001f467\U0001f3ff\u200d\U0001f476\U0001f3ff", "Family - Man: Dark Skin Tone, Man: Dark Skin Tone, Girl: Dark Skin Tone, Baby: Dark Skin Tone" }, // 1f468-1f3ff-200d-1f468-1f3ff-200d-1f467-1f3ff-200d-1f476-1f3ff
            { "\U0001f468\U0001f3ff\u200d\U0001f468\U0001f3ff\u200d\U0001f467\U0001f3ff\u200d\U0001f467\U0001f3ff", "Family - Man: Dark Skin Tone, Man: Dark Skin Tone, Girl: Dark Skin Tone, Girl: Dark Skin Tone" }, // 1f468-1f3ff-200d-1f468-1f3ff-200d-1f467-1f3ff-200d-1f467-1f3ff
            { "\U0001f468\U0001f3ff\u200d\U0001f468\U0001f3ff\u200d\U0001f467\U0001f3ff\u200d\U0001f466\U0001f3ff", "Family - Man: Dark Skin Tone, Man: Dark Skin Tone, Girl: Dark Skin Tone, Boy: Dark Skin Tone" }, // 1f468-1f3ff-200d-1f468-1f3ff-200d-1f467-1f3ff-200d-1f466-1f3ff
            { "\U0001f468\U0001f3ff\u200d\U0001f468\U0001f3ff\u200d\U0001f466\U0001f3ff\u200d\U0001f476\U0001f3ff", "Family - Man: Dark Skin Tone, Man: Dark Skin Tone, Boy: Dark Skin Tone, Baby: Dark Skin Tone" }, // 1f468-1f3ff-200d-1f468-1f3ff-200d-1f466-1f3ff-200d-1f476-1f3ff
            { "\U0001f468\U0001f3ff\u200d\U0001f468\U0001f3ff\u200d\U0001f466\U0001f3ff\u200d\U0001f467\U0001f3ff", "Family - Man: Dark Skin Tone, Man: Dark Skin Tone, Boy: Dark Skin Tone, Girl: Dark Skin Tone" }, // 1f468-1f3ff-200d-1f468-1f3ff-200d-1f466-1f3ff-200d-1f467-1f3ff
            { "\U0001f468\U0001f3ff\u200d\U0001f468\U0001f3ff\u200d\U0001f466\U0001f3ff\u200d\U0001f466\U0001f3ff", "Family - Man: Dark Skin Tone, Man: Dark Skin Tone, Boy: Dark Skin Tone, Boy: Dark Skin Tone" }, // 1f468-1f3ff-200d-1f468-1f3ff-200d-1f466-1f3ff-200d-1f466-1f3ff
            { "\U0001f469\U0001f3fb\u200d\U0001f467\U0001f3fb\u200d\U0001f476\U0001f3fb", "Family - Woman: Light Skin Tone, Girl: Light Skin Tone, Baby: Light Skin Tone" }, // 1f469-1f3fb-200d-1f467-1f3fb-200d-1f476-1f3fb
            { "\U0001f469\U0001f3fd\u200d\U0001f469\U0001f3fd\u200d\U0001f467\U0001f3fd", "Family - Woman: Medium Skin Tone, Woman: Medium Skin Tone, Girl: Medium Skin Tone" }, // 1f469-1f3fd-200d-1f469-1f3fd-200d-1f467-1f3fd
            { "\U0001f469\U0001f3fd\u200d\U0001f469\U0001f3fd\u200d\U0001f466\U0001f3fd", "Family - Woman: Medium Skin Tone, Woman: Medium Skin Tone, Boy: Medium Skin Tone" }, // 1f469-1f3fd-200d-1f469-1f3fd-200d-1f466-1f3fd
            { "\U0001f469\U0001f3fd\u200d\U0001f468\U0001f3fd\u200d\U0001f476\U0001f3fd", "Family - Woman: Medium Skin Tone, Man: Medium Skin Tone, Baby: Medium Skin Tone" }, // 1f469-1f3fd-200d-1f468-1f3fd-200d-1f476-1f3fd
            { "\U0001f469\U0001f3fd\u200d\U0001f468\U0001f3fd\u200d\U0001f467\U0001f3fd", "Family - Woman: Medium Skin Tone, Man: Medium Skin Tone, Girl: Medium Skin Tone" }, // 1f469-1f3fd-200d-1f468-1f3fd-200d-1f467-1f3fd
            { "\U0001f469\U0001f3fd\u200d\U0001f468\U0001f3fd\u200d\U0001f466\U0001f3fd", "Family - Woman: Medium Skin Tone, Man: Medium Skin Tone, Boy: Medium Skin Tone" }, // 1f469-1f3fd-200d-1f468-1f3fd-200d-1f466-1f3fd
            { "\U0001f469\U0001f3fc\u200d\U0001f469\U0001f3fc\u200d\U0001f476\U0001f3fc", "Family - Woman: Medium-Light Skin Tone, Woman: Medium-Light Skin Tone, Baby: Medium-Light Skin Tone" }, // 1f469-1f3fc-200d-1f469-1f3fc-200d-1f476-1f3fc
            { "\U0001f469\U0001f3fc\u200d\U0001f469\U0001f3fc\u200d\U0001f467\U0001f3fc", "Family - Woman: Medium-Light Skin Tone, Woman: Medium-Light Skin Tone, Girl: Medium-Light Skin Tone" }, // 1f469-1f3fc-200d-1f469-1f3fc-200d-1f467-1f3fc
            { "\U0001f469\U0001f3fc\u200d\U0001f469\U0001f3fc\u200d\U0001f466\U0001f3fc", "Family - Woman: Medium-Light Skin Tone, Woman: Medium-Light Skin Tone, Boy: Medium-Light Skin Tone" }, // 1f469-1f3fc-200d-1f469-1f3fc-200d-1f466-1f3fc
            { "\U0001f469\U0001f3fc\u200d\U0001f468\U0001f3fc\u200d\U0001f476\U0001f3fc", "Family - Woman: Medium-Light Skin Tone, Man: Medium-Light Skin Tone, Baby: Medium-Light Skin Tone" }, // 1f469-1f3fc-200d-1f468-1f3fc-200d-1f476-1f3fc
            { "\U0001f469\U0001f3fc\u200d\U0001f468\U0001f3fc\u200d\U0001f467\U0001f3fc", "Family - Woman: Medium-Light Skin Tone, Man: Medium-Light Skin Tone, Girl: Medium-Light Skin Tone" }, // 1f469-1f3fc-200d-1f468-1f3fc-200d-1f467-1f3fc
            { "\U0001f469\U0001f3fc\u200d\U0001f468\U0001f3fc\u200d\U0001f466\U0001f3fc", "Family - Woman: Medium-Light Skin Tone, Man: Medium-Light Skin Tone, Boy: Medium-Light Skin Tone" }, // 1f469-1f3fc-200d-1f468-1f3fc-200d-1f466-1f3fc
            { "\U0001f469\U0001f3fb\u200d\U0001f469\U0001f3fb\u200d\U0001f476\U0001f3fb", "Family - Woman: Light Skin Tone, Woman: Light Skin Tone, Baby: Light Skin Tone" }, // 1f469-1f3fb-200d-1f469-1f3fb-200d-1f476-1f3fb
            { "\U0001f469\U0001f3fb\u200d\U0001f469\U0001f3fb\u200d\U0001f467\U0001f3fb", "Family - Woman: Light Skin Tone, Woman: Light Skin Tone, Girl: Light Skin Tone" }, // 1f469-1f3fb-200d-1f469-1f3fb-200d-1f467-1f3fb
            { "\U0001f469\U0001f3fb\u200d\U0001f469\U0001f3fb\u200d\U0001f466\U0001f3fb", "Family - Woman: Light Skin Tone, Woman: Light Skin Tone, Boy: Light Skin Tone" }, // 1f469-1f3fb-200d-1f469-1f3fb-200d-1f466-1f3fb
            { "\U0001f469\U0001f3fb\u200d\U0001f468\U0001f3fb\u200d\U0001f476\U0001f3fb", "Family - Woman: Light Skin Tone, Man: Light Skin Tone, Baby: Light Skin Tone" }, // 1f469-1f3fb-200d-1f468-1f3fb-200d-1f476-1f3fb
            { "\U0001f469\U0001f3fb\u200d\U0001f468\U0001f3fb\u200d\U0001f467\U0001f3fb", "Family - Woman: Light Skin Tone, Man: Light Skin Tone, Girl: Light Skin Tone" }, // 1f469-1f3fb-200d-1f468-1f3fb-200d-1f467-1f3fb
            { "\U0001f469\U0001f3fb\u200d\U0001f468\U0001f3fb\u200d\U0001f466\U0001f3fb", "Family - Woman: Light Skin Tone, Man: Light Skin Tone, Boy: Light Skin Tone" }, // 1f469-1f3fb-200d-1f468-1f3fb-200d-1f466-1f3fb
            { "\U0001f468\U0001f3ff\u200d\U0001f469\U0001f3ff\u200d\U0001f476\U0001f3ff", "Family - Man: Dark Skin Tone, Woman: Dark Skin Tone, Baby: Dark Skin Tone" }, // 1f468-1f3ff-200d-1f469-1f3ff-200d-1f476-1f3ff
            { "\U0001f469\U0001f3fb\u200d\U0001f467\U0001f3fb\u200d\U0001f467\U0001f3fb", "Family - Woman: Light Skin Tone, Girl: Light Skin Tone, Girl: Light Skin Tone" }, // 1f469-1f3fb-200d-1f467-1f3fb-200d-1f467-1f3fb
            { "\U0001f469\U0001f3fb\u200d\U0001f467\U0001f3fb\u200d\U0001f466\U0001f3fb", "Family - Woman: Light Skin Tone, Girl: Light Skin Tone, Boy: Light Skin Tone" }, // 1f469-1f3fb-200d-1f467-1f3fb-200d-1f466-1f3fb
            { "\U0001f469\U0001f3fb\u200d\U0001f466\U0001f3fb\u200d\U0001f476\U0001f3fb", "Family - Woman: Light Skin Tone, Boy: Light Skin Tone, Baby: Light Skin Tone" }, // 1f469-1f3fb-200d-1f466-1f3fb-200d-1f476-1f3fb
            { "\U0001f469\U0001f3fb\u200d\U0001f466\U0001f3fb\u200d\U0001f467\U0001f3fb", "Family - Woman: Light Skin Tone, Boy: Light Skin Tone, Girl: Light Skin Tone" }, // 1f469-1f3fb-200d-1f466-1f3fb-200d-1f467-1f3fb
            { "\U0001f469\U0001f3fb\u200d\U0001f466\U0001f3fb\u200d\U0001f466\U0001f3fb", "Family - Woman: Light Skin Tone, Boy: Light Skin Tone, Boy: Light Skin Tone" }, // 1f469-1f3fb-200d-1f466-1f3fb-200d-1f466-1f3fb
            { "\U0001f468\U0001f3ff\u200d\U0001f476\U0001f3ff\u200d\U0001f476\U0001f3ff", "Family - Man: Dark Skin Tone, Baby: Dark Skin Tone, Baby: Dark Skin Tone" }, // 1f468-1f3ff-200d-1f476-1f3ff-200d-1f476-1f3ff
            { "\U0001f468\U0001f3ff\u200d\U0001f476\U0001f3ff\u200d\U0001f467\U0001f3ff", "Family - Man: Dark Skin Tone, Baby: Dark Skin Tone, Girl: Dark Skin Tone" }, // 1f468-1f3ff-200d-1f476-1f3ff-200d-1f467-1f3ff
            { "\U0001f468\U0001f3ff\u200d\U0001f476\U0001f3ff\u200d\U0001f466\U0001f3ff", "Family - Man: Dark Skin Tone, Baby: Dark Skin Tone, Boy: Dark Skin Tone" }, // 1f468-1f3ff-200d-1f476-1f3ff-200d-1f466-1f3ff
            { "\U0001f468\U0001f3ff\u200d\U0001f467\U0001f3ff\u200d\U0001f476\U0001f3ff", "Family - Man: Dark Skin Tone, Girl: Dark Skin Tone, Baby: Dark Skin Tone" }, // 1f468-1f3ff-200d-1f467-1f3ff-200d-1f476-1f3ff
            { "\U0001f468\U0001f3ff\u200d\U0001f467\U0001f3ff\u200d\U0001f467\U0001f3ff", "Family - Man: Dark Skin Tone, Girl: Dark Skin Tone, Girl: Dark Skin Tone" }, // 1f468-1f3ff-200d-1f467-1f3ff-200d-1f467-1f3ff
            { "\U0001f468\U0001f3ff\u200d\U0001f467\U0001f3ff\u200d\U0001f466\U0001f3ff", "Family - Man: Dark Skin Tone, Girl: Dark Skin Tone, Boy: Dark Skin Tone" }, // 1f468-1f3ff-200d-1f467-1f3ff-200d-1f466-1f3ff
            { "\U0001f468\U0001f3ff\u200d\U0001f466\U0001f3ff\u200d\U0001f476\U0001f3ff", "Family - Man: Dark Skin Tone, Boy: Dark Skin Tone, Baby: Dark Skin Tone" }, // 1f468-1f3ff-200d-1f466-1f3ff-200d-1f476-1f3ff
            { "\U0001f468\U0001f3ff\u200d\U0001f466\U0001f3ff\u200d\U0001f467\U0001f3ff", "Family - Man: Dark Skin Tone, Boy: Dark Skin Tone, Girl: Dark Skin Tone" }, // 1f468-1f3ff-200d-1f466-1f3ff-200d-1f467-1f3ff
            { "\U0001f468\U0001f3ff\u200d\U0001f466\U0001f3ff\u200d\U0001f466\U0001f3ff", "Family - Man: Dark Skin Tone, Boy: Dark Skin Tone, Boy: Dark Skin Tone" }, // 1f468-1f3ff-200d-1f466-1f3ff-200d-1f466-1f3ff
            { "\U0001f468\U0001f3fe\u200d\U0001f476\U0001f3fe\u200d\U0001f476\U0001f3fe", "Family - Man: Medium-Dark Skin Tone, Baby: Medium-Dark Skin Tone, Baby: Medium-Dark Skin Tone" }, // 1f468-1f3fe-200d-1f476-1f3fe-200d-1f476-1f3fe
            { "\U0001f468\U0001f3fe\u200d\U0001f476\U0001f3fe\u200d\U0001f467\U0001f3fe", "Family - Man: Medium-Dark Skin Tone, Baby: Medium-Dark Skin Tone, Girl: Medium-Dark Skin Tone" }, // 1f468-1f3fe-200d-1f476-1f3fe-200d-1f467-1f3fe
            { "\U0001f468\U0001f3fe\u200d\U0001f476\U0001f3fe\u200d\U0001f466\U0001f3fe", "Family - Man: Medium-Dark Skin Tone, Baby: Medium-Dark Skin Tone, Boy: Medium-Dark Skin Tone" }, // 1f468-1f3fe-200d-1f476-1f3fe-200d-1f466-1f3fe
            { "\U0001f468\U0001f3fe\u200d\U0001f467\U0001f3fe\u200d\U0001f476\U0001f3fe", "Family - Man: Medium-Dark Skin Tone, Girl: Medium-Dark Skin Tone, Baby: Medium-Dark Skin Tone" }, // 1f468-1f3fe-200d-1f467-1f3fe-200d-1f476-1f3fe
            { "\U0001f468\U0001f3fe\u200d\U0001f467\U0001f3fe\u200d\U0001f467\U0001f3fe", "Family - Man: Medium-Dark Skin Tone, Girl: Medium-Dark Skin Tone, Girl: Medium-Dark Skin Tone" }, // 1f468-1f3fe-200d-1f467-1f3fe-200d-1f467-1f3fe
            { "\U0001f468\U0001f3fe\u200d\U0001f467\U0001f3fe\u200d\U0001f466\U0001f3fe", "Family - Man: Medium-Dark Skin Tone, Girl: Medium-Dark Skin Tone, Boy: Medium-Dark Skin Tone" }, // 1f468-1f3fe-200d-1f467-1f3fe-200d-1f466-1f3fe
            { "\U0001f468\U0001f3fe\u200d\U0001f466\U0001f3fe\u200d\U0001f476\U0001f3fe", "Family - Man: Medium-Dark Skin Tone, Boy: Medium-Dark Skin Tone, Baby: Medium-Dark Skin Tone" }, // 1f468-1f3fe-200d-1f466-1f3fe-200d-1f476-1f3fe
            { "\U0001f468\U0001f3fe\u200d\U0001f466\U0001f3fe\u200d\U0001f467\U0001f3fe", "Family - Man: Medium-Dark Skin Tone, Boy: Medium-Dark Skin Tone, Girl: Medium-Dark Skin Tone" }, // 1f468-1f3fe-200d-1f466-1f3fe-200d-1f467-1f3fe
            { "\U0001f468\U0001f3fe\u200d\U0001f466\U0001f3fe\u200d\U0001f466\U0001f3fe", "Family - Man: Medium-Dark Skin Tone, Boy: Medium-Dark Skin Tone, Boy: Medium-Dark Skin Tone" }, // 1f468-1f3fe-200d-1f466-1f3fe-200d-1f466-1f3fe
            { "\U0001f468\U0001f3fd\u200d\U0001f476\U0001f3fd\u200d\U0001f476\U0001f3fd", "Family - Man: Medium Skin Tone, Baby: Medium Skin Tone, Baby: Medium Skin Tone" }, // 1f468-1f3fd-200d-1f476-1f3fd-200d-1f476-1f3fd
            { "\U0001f468\U0001f3fd\u200d\U0001f476\U0001f3fd\u200d\U0001f467\U0001f3fd", "Family - Man: Medium Skin Tone, Baby: Medium Skin Tone, Girl: Medium Skin Tone" }, // 1f468-1f3fd-200d-1f476-1f3fd-200d-1f467-1f3fd
            { "\U0001f468\U0001f3fd\u200d\U0001f476\U0001f3fd\u200d\U0001f466\U0001f3fd", "Family - Man: Medium Skin Tone, Baby: Medium Skin Tone, Boy: Medium Skin Tone" }, // 1f468-1f3fd-200d-1f476-1f3fd-200d-1f466-1f3fd
            { "\U0001f468\U0001f3fd\u200d\U0001f467\U0001f3fd\u200d\U0001f476\U0001f3fd", "Family - Man: Medium Skin Tone, Girl: Medium Skin Tone, Baby: Medium Skin Tone" }, // 1f468-1f3fd-200d-1f467-1f3fd-200d-1f476-1f3fd
            { "\U0001f468\U0001f3fd\u200d\U0001f467\U0001f3fd\u200d\U0001f467\U0001f3fd", "Family - Man: Medium Skin Tone, Girl: Medium Skin Tone, Girl: Medium Skin Tone" }, // 1f468-1f3fd-200d-1f467-1f3fd-200d-1f467-1f3fd
            { "\U0001f468\U0001f3fd\u200d\U0001f467\U0001f3fd\u200d\U0001f466\U0001f3fd", "Family - Man: Medium Skin Tone, Girl: Medium Skin Tone, Boy: Medium Skin Tone" }, // 1f468-1f3fd-200d-1f467-1f3fd-200d-1f466-1f3fd
            { "\U0001f468\U0001f3fd\u200d\U0001f466\U0001f3fd\u200d\U0001f476\U0001f3fd", "Family - Man: Medium Skin Tone, Boy: Medium Skin Tone, Baby: Medium Skin Tone" }, // 1f468-1f3fd-200d-1f466-1f3fd-200d-1f476-1f3fd
            { "\U0001f468\U0001f3fd\u200d\U0001f466\U0001f3fd\u200d\U0001f467\U0001f3fd", "Family - Man: Medium Skin Tone, Boy: Medium Skin Tone, Girl: Medium Skin Tone" }, // 1f468-1f3fd-200d-1f466-1f3fd-200d-1f467-1f3fd
            { "\U0001f468\U0001f3fd\u200d\U0001f466\U0001f3fd\u200d\U0001f466\U0001f3fd", "Family - Man: Medium Skin Tone, Boy: Medium Skin Tone, Boy: Medium Skin Tone" }, // 1f468-1f3fd-200d-1f466-1f3fd-200d-1f466-1f3fd
            { "\U0001f468\U0001f3fc\u200d\U0001f476\U0001f3fc\u200d\U0001f476\U0001f3fc", "Family - Man: Medium-Light Skin Tone, Baby: Medium-Light Skin Tone, Baby: Medium-Light Skin Tone" }, // 1f468-1f3fc-200d-1f476-1f3fc-200d-1f476-1f3fc
            { "\U0001f468\U0001f3fc\u200d\U0001f476\U0001f3fc\u200d\U0001f467\U0001f3fc", "Family - Man: Medium-Light Skin Tone, Baby: Medium-Light Skin Tone, Girl: Medium-Light Skin Tone" }, // 1f468-1f3fc-200d-1f476-1f3fc-200d-1f467-1f3fc
            { "\U0001f468\U0001f3fc\u200d\U0001f476\U0001f3fc\u200d\U0001f466\U0001f3fc", "Family - Man: Medium-Light Skin Tone, Baby: Medium-Light Skin Tone, Boy: Medium-Light Skin Tone" }, // 1f468-1f3fc-200d-1f476-1f3fc-200d-1f466-1f3fc
            { "\U0001f468\U0001f3fc\u200d\U0001f467\U0001f3fc\u200d\U0001f476\U0001f3fc", "Family - Man: Medium-Light Skin Tone, Girl: Medium-Light Skin Tone, Baby: Medium-Light Skin Tone" }, // 1f468-1f3fc-200d-1f467-1f3fc-200d-1f476-1f3fc
            { "\U0001f468\U0001f3fc\u200d\U0001f467\U0001f3fc\u200d\U0001f467\U0001f3fc", "Family - Man: Medium-Light Skin Tone, Girl: Medium-Light Skin Tone, Girl: Medium-Light Skin Tone" }, // 1f468-1f3fc-200d-1f467-1f3fc-200d-1f467-1f3fc
            { "\U0001f468\U0001f3fc\u200d\U0001f467\U0001f3fc\u200d\U0001f466\U0001f3fc", "Family - Man: Medium-Light Skin Tone, Girl: Medium-Light Skin Tone, Boy: Medium-Light Skin Tone" }, // 1f468-1f3fc-200d-1f467-1f3fc-200d-1f466-1f3fc
            { "\U0001f468\U0001f3fc\u200d\U0001f466\U0001f3fc\u200d\U0001f476\U0001f3fc", "Family - Man: Medium-Light Skin Tone, Boy: Medium-Light Skin Tone, Baby: Medium-Light Skin Tone" }, // 1f468-1f3fc-200d-1f466-1f3fc-200d-1f476-1f3fc
            { "\U0001f468\U0001f3fc\u200d\U0001f466\U0001f3fc\u200d\U0001f467\U0001f3fc", "Family - Man: Medium-Light Skin Tone, Boy: Medium-Light Skin Tone, Girl: Medium-Light Skin Tone" }, // 1f468-1f3fc-200d-1f466-1f3fc-200d-1f467-1f3fc
            { "\U0001f468\U0001f3fc\u200d\U0001f466\U0001f3fc\u200d\U0001f466\U0001f3fc", "Family - Man: Medium-Light Skin Tone, Boy: Medium-Light Skin Tone, Boy: Medium-Light Skin Tone" }, // 1f468-1f3fc-200d-1f466-1f3fc-200d-1f466-1f3fc
            { "\U0001f468\U0001f3fb\u200d\U0001f476\U0001f3fb\u200d\U0001f476\U0001f3fb", "Family - Man: Light Skin Tone, Baby: Light Skin Tone, Baby: Light Skin Tone" }, // 1f468-1f3fb-200d-1f476-1f3fb-200d-1f476-1f3fb
            { "\U0001f468\U0001f3fb\u200d\U0001f476\U0001f3fb\u200d\U0001f467\U0001f3fb", "Family - Man: Light Skin Tone, Baby: Light Skin Tone, Girl: Light Skin Tone" }, // 1f468-1f3fb-200d-1f476-1f3fb-200d-1f467-1f3fb
            { "\U0001f468\U0001f3fb\u200d\U0001f476\U0001f3fb\u200d\U0001f466\U0001f3fb", "Family - Man: Light Skin Tone, Baby: Light Skin Tone, Boy: Light Skin Tone" }, // 1f468-1f3fb-200d-1f476-1f3fb-200d-1f466-1f3fb
            { "\U0001f468\U0001f3fb\u200d\U0001f467\U0001f3fb\u200d\U0001f476\U0001f3fb", "Family - Man: Light Skin Tone, Girl: Light Skin Tone, Baby: Light Skin Tone" }, // 1f468-1f3fb-200d-1f467-1f3fb-200d-1f476-1f3fb
            { "\U0001f468\U0001f3fb\u200d\U0001f467\U0001f3fb\u200d\U0001f467\U0001f3fb", "Family - Man: Light Skin Tone, Girl: Light Skin Tone, Girl: Light Skin Tone" }, // 1f468-1f3fb-200d-1f467-1f3fb-200d-1f467-1f3fb
            { "\U0001f468\U0001f3fb\u200d\U0001f467\U0001f3fb\u200d\U0001f466\U0001f3fb", "Family - Man: Light Skin Tone, Girl: Light Skin Tone, Boy: Light Skin Tone" }, // 1f468-1f3fb-200d-1f467-1f3fb-200d-1f466-1f3fb
            { "\U0001f468\U0001f3fb\u200d\U0001f466\U0001f3fb\u200d\U0001f476\U0001f3fb", "Family - Man: Light Skin Tone, Boy: Light Skin Tone, Baby: Light Skin Tone" }, // 1f468-1f3fb-200d-1f466-1f3fb-200d-1f476-1f3fb
            { "\U0001f468\U0001f3fb\u200d\U0001f466\U0001f3fb\u200d\U0001f467\U0001f3fb", "Family - Man: Light Skin Tone, Boy: Light Skin Tone, Girl: Light Skin Tone" }, // 1f468-1f3fb-200d-1f466-1f3fb-200d-1f467-1f3fb
            { "\U0001f468\U0001f3fb\u200d\U0001f466\U0001f3fb\u200d\U0001f466\U0001f3fb", "Family - Man: Light Skin Tone, Boy: Light Skin Tone, Boy: Light Skin Tone" }, // 1f468-1f3fb-200d-1f466-1f3fb-200d-1f466-1f3fb
            { "\U0001f469\U0001f3ff\u200d\U0001f467\U0001f3ff", "Family - Woman: Dark Skin Tone, Girl: Dark Skin Tone" }, // 1f469-1f3ff-200d-1f467-1f3ff
            { "\U0001f469\U0001f3ff\u200d\U0001f466\U0001f3ff", "Family - Woman: Dark Skin Tone, Boy: Dark Skin Tone" }, // 1f469-1f3ff-200d-1f466-1f3ff
            { "\U0001f469\U0001f3fe\u200d\U0001f476\U0001f3fe", "Family - Woman: Medium-Dark Skin Tone, Baby: Medium-Dark Skin Tone" }, // 1f469-1f3fe-200d-1f476-1f3fe
            { "\U0001f469\U0001f3fe\u200d\U0001f467\U0001f3fe", "Family - Woman: Medium-Dark Skin Tone, Girl: Medium-Dark Skin Tone" }, // 1f469-1f3fe-200d-1f467-1f3fe
            { "\U0001f469\U0001f3fe\u200d\U0001f466\U0001f3fe", "Family - Woman: Medium-Dark Skin Tone, Boy: Medium-Dark Skin Tone" }, // 1f469-1f3fe-200d-1f466-1f3fe
            { "\U0001f469\U0001f3fd\u200d\U0001f476\U0001f3fd", "Family - Woman: Medium Skin Tone, Baby: Medium Skin Tone" }, // 1f469-1f3fd-200d-1f476-1f3fd
            { "\U0001f469\U0001f3fd\u200d\U0001f467\U0001f3fd", "Family - Woman: Medium Skin Tone, Girl: Medium Skin Tone" }, // 1f469-1f3fd-200d-1f467-1f3fd
            { "\U0001f469\U0001f3fd\u200d\U0001f466\U0001f3fd", "Family - Woman: Medium Skin Tone, Boy: Medium Skin Tone" }, // 1f469-1f3fd-200d-1f466-1f3fd
            { "\U0001f469\U0001f3fc\u200d\U0001f476\U0001f3fc", "Family - Woman: Medium-Light Skin Tone, Baby: Medium-Light Skin Tone" }, // 1f469-1f3fc-200d-1f476-1f3fc
            { "\U0001f469\U0001f3fc\u200d\U0001f467\U0001f3fc", "Family - Woman: Medium-Light Skin Tone, Girl: Medium-Light Skin Tone" }, // 1f469-1f3fc-200d-1f467-1f3fc
            { "\U0001f469\U0001f3fc\u200d\U0001f466\U0001f3fc", "Family - Woman: Medium-Light Skin Tone, Boy: Medium-Light Skin Tone" }, // 1f469-1f3fc-200d-1f466-1f3fc
            { "\U0001f468\U0001f3ff\u200d\U0001f467\U0001f3ff", "Family - Man: Dark Skin Tone, Girl: Dark Skin Tone" }, // 1f468-1f3ff-200d-1f467-1f3ff
            { "\U0001f468\U0001f3ff\u200d\U0001f466\U0001f3ff", "Family - Man: Dark Skin Tone, Boy: Dark Skin Tone" }, // 1f468-1f3ff-200d-1f466-1f3ff
            { "\U0001f468\U0001f3fe\u200d\U0001f476\U0001f3fe", "Family - Man: Medium-Dark Skin Tone, Baby: Medium-Dark Skin Tone" }, // 1f468-1f3fe-200d-1f476-1f3fe
            { "\U0001f468\U0001f3fe\u200d\U0001f467\U0001f3fe", "Family - Man: Medium-Dark Skin Tone, Girl: Medium-Dark Skin Tone" }, // 1f468-1f3fe-200d-1f467-1f3fe
            { "\U0001f468\U0001f3fe\u200d\U0001f466\U0001f3fe", "Family - Man: Medium-Dark Skin Tone, Boy: Medium-Dark Skin Tone" }, // 1f468-1f3fe-200d-1f466-1f3fe
            { "\U0001f468\U0001f3fd\u200d\U0001f476\U0001f3fd", "Family - Man: Medium Skin Tone, Baby: Medium Skin Tone" }, // 1f468-1f3fd-200d-1f476-1f3fd
            { "\U0001f468\U0001f3fd\u200d\U0001f467\U0001f3fd", "Family - Man: Medium Skin Tone, Girl: Medium Skin Tone" }, // 1f468-1f3fd-200d-1f467-1f3fd
            { "\U0001f468\U0001f3fd\u200d\U0001f466\U0001f3fd", "Family - Man: Medium Skin Tone, Boy: Medium Skin Tone" }, // 1f468-1f3fd-200d-1f466-1f3fd
            { "\U0001f468\U0001f3fc\u200d\U0001f476\U0001f3fc", "Family - Man: Medium-Light Skin Tone, Baby: Medium-Light Skin Tone" }, // 1f468-1f3fc-200d-1f476-1f3fc
            { "\U0001f468\U0001f3fc\u200d\U0001f467\U0001f3fc", "Family - Man: Medium-Light Skin Tone, Girl: Medium-Light Skin Tone" }, // 1f468-1f3fc-200d-1f467-1f3fc
            { "\U0001f468\U0001f3fc\u200d\U0001f466\U0001f3fc", "Family - Man: Medium-Light Skin Tone, Boy: Medium-Light Skin Tone" }, // 1f468-1f3fc-200d-1f466-1f3fc
            { "\U0001f468\U0001f3fb\u200d\U0001f476\U0001f3fb", "Family - Man: Light Skin Tone, Baby: Light Skin Tone" }, // 1f468-1f3fb-200d-1f476-1f3fb
            { "\U0001f468\U0001f3fb\u200d\U0001f467\U0001f3fb", "Family - Man: Light Skin Tone, Girl: Light Skin Tone" }, // 1f468-1f3fb-200d-1f467-1f3fb
            { "\U0001f468\U0001f3fb\u200d\U0001f466\U0001f3fb", "Family - Man: Light Skin Tone, Boy: Light Skin Tone" }, // 1f468-1f3fb-200d-1f466-1f3fb
            { "\U0001f468\U0001f3fe\u200d\U0001f469\U0001f3fe\u200d\U0001f476\U0001f3fe\u200d\U0001f476\U0001f3fe", "Family - Man: Medium-Dark Skin Tone, Woman: Medium-Dark Skin Tone, Baby: Medium-Dark Skin Tone, Baby: Medium-Dark Skin Tone" }, // 1f468-1f3fe-200d-1f469-1f3fe-200d-1f476-1f3fe-200d-1f476-1f3fe
            { "\U0001f468\U0001f3fe\u200d\U0001f469\U0001f3fe\u200d\U0001f476\U0001f3fe\u200d\U0001f467\U0001f3fe", "Family - Man: Medium-Dark Skin Tone, Woman: Medium-Dark Skin Tone, Baby: Medium-Dark Skin Tone, Girl: Medium-Dark Skin Tone" }, // 1f468-1f3fe-200d-1f469-1f3fe-200d-1f476-1f3fe-200d-1f467-1f3fe
            { "\U0001f468\U0001f3fe\u200d\U0001f469\U0001f3fe\u200d\U0001f476\U0001f3fe\u200d\U0001f466\U0001f3fe", "Family - Man: Medium-Dark Skin Tone, Woman: Medium-Dark Skin Tone, Baby: Medium-Dark Skin Tone, Boy: Medium-Dark Skin Tone" }, // 1f468-1f3fe-200d-1f469-1f3fe-200d-1f476-1f3fe-200d-1f466-1f3fe
            { "\U0001f468\U0001f3fe\u200d\U0001f469\U0001f3fe\u200d\U0001f467\U0001f3fe\u200d\U0001f476\U0001f3fe", "Family - Man: Medium-Dark Skin Tone, Woman: Medium-Dark Skin Tone, Girl: Medium-Dark Skin Tone, Baby: Medium-Dark Skin Tone" }, // 1f468-1f3fe-200d-1f469-1f3fe-200d-1f467-1f3fe-200d-1f476-1f3fe
            { "\U0001f468\U0001f3fe\u200d\U0001f469\U0001f3fe\u200d\U0001f467\U0001f3fe\u200d\U0001f467\U0001f3fe", "Family - Man: Medium-Dark Skin Tone, Woman: Medium-Dark Skin Tone, Girl: Medium-Dark Skin Tone, Girl: Medium-Dark Skin Tone" }, // 1f468-1f3fe-200d-1f469-1f3fe-200d-1f467-1f3fe-200d-1f467-1f3fe
            { "\U0001f468\U0001f3fe\u200d\U0001f469\U0001f3fe\u200d\U0001f466\U0001f3fe\u200d\U0001f476\U0001f3fe", "Family - Man: Medium-Dark Skin Tone, Woman: Medium-Dark Skin Tone, Boy: Medium-Dark Skin Tone, Baby: Medium-Dark Skin Tone" }, // 1f468-1f3fe-200d-1f469-1f3fe-200d-1f466-1f3fe-200d-1f476-1f3fe
            { "\U0001f468\U0001f3fe\u200d\U0001f469\U0001f3fe\u200d\U0001f466\U0001f3fe\u200d\U0001f467\U0001f3fe", "Family - Man: Medium-Dark Skin Tone, Woman: Medium-Dark Skin Tone, Boy: Medium-Dark Skin Tone, Girl: Medium-Dark Skin Tone" }, // 1f468-1f3fe-200d-1f469-1f3fe-200d-1f466-1f3fe-200d-1f467-1f3fe
            { "\U0001f468\U0001f3fe\u200d\U0001f469\U0001f3fe\u200d\U0001f466\U0001f3fe\u200d\U0001f466\U0001f3fe", "Family - Man: Medium-Dark Skin Tone, Woman: Medium-Dark Skin Tone, Boy: Medium-Dark Skin Tone, Boy: Medium-Dark Skin Tone" }, // 1f468-1f3fe-200d-1f469-1f3fe-200d-1f466-1f3fe-200d-1f466-1f3fe
            { "\U0001f468\U0001f3fe\u200d\U0001f468\U0001f3fe\u200d\U0001f476\U0001f3fe\u200d\U0001f476\U0001f3fe", "Family - Man: Medium-Dark Skin Tone, Man: Medium-Dark Skin Tone, Baby: Medium-Dark Skin Tone, Baby: Medium-Dark Skin Tone" }, // 1f468-1f3fe-200d-1f468-1f3fe-200d-1f476-1f3fe-200d-1f476-1f3fe
            { "\U0001f468\U0001f3fe\u200d\U0001f468\U0001f3fe\u200d\U0001f476\U0001f3fe\u200d\U0001f467\U0001f3fe", "Family - Man: Medium-Dark Skin Tone, Man: Medium-Dark Skin Tone, Baby: Medium-Dark Skin Tone, Girl: Medium-Dark Skin Tone" }, // 1f468-1f3fe-200d-1f468-1f3fe-200d-1f476-1f3fe-200d-1f467-1f3fe
            { "\U0001f468\U0001f3fe\u200d\U0001f468\U0001f3fe\u200d\U0001f476\U0001f3fe\u200d\U0001f466\U0001f3fe", "Family - Man: Medium-Dark Skin Tone, Man: Medium-Dark Skin Tone, Baby: Medium-Dark Skin Tone, Boy: Medium-Dark Skin Tone" }, // 1f468-1f3fe-200d-1f468-1f3fe-200d-1f476-1f3fe-200d-1f466-1f3fe
            { "\U0001f468\U0001f3fe\u200d\U0001f468\U0001f3fe\u200d\U0001f467\U0001f3fe\u200d\U0001f476\U0001f3fe", "Family - Man: Medium-Dark Skin Tone, Man: Medium-Dark Skin Tone, Girl: Medium-Dark Skin Tone, Baby: Medium-Dark Skin Tone" }, // 1f468-1f3fe-200d-1f468-1f3fe-200d-1f467-1f3fe-200d-1f476-1f3fe
            { "\U0001f468\U0001f3fe\u200d\U0001f468\U0001f3fe\u200d\U0001f467\U0001f3fe\u200d\U0001f467\U0001f3fe", "Family - Man: Medium-Dark Skin Tone, Man: Medium-Dark Skin Tone, Girl: Medium-Dark Skin Tone, Girl: Medium-Dark Skin Tone" }, // 1f468-1f3fe-200d-1f468-1f3fe-200d-1f467-1f3fe-200d-1f467-1f3fe
            { "\U0001f468\U0001f3fe\u200d\U0001f468\U0001f3fe\u200d\U0001f467\U0001f3fe\u200d\U0001f466\U0001f3fe", "Family - Man: Medium-Dark Skin Tone, Man: Medium-Dark Skin Tone, Girl: Medium-Dark Skin Tone, Boy: Medium-Dark Skin Tone" }, // 1f468-1f3fe-200d-1f468-1f3fe-200d-1f467-1f3fe-200d-1f466-1f3fe
            { "\U0001f468\U0001f3fe\u200d\U0001f468\U0001f3fe\u200d\U0001f466\U0001f3fe\u200d\U0001f476\U0001f3fe", "Family - Man: Medium-Dark Skin Tone, Man: Medium-Dark Skin Tone, Boy: Medium-Dark Skin Tone, Baby: Medium-Dark Skin Tone" }, // 1f468-1f3fe-200d-1f468-1f3fe-200d-1f466-1f3fe-200d-1f476-1f3fe
            { "\U0001f468\U0001f3fe\u200d\U0001f468\U0001f3fe\u200d\U0001f466\U0001f3fe\u200d\U0001f467\U0001f3fe", "Family - Man: Medium-Dark Skin Tone, Man: Medium-Dark Skin Tone, Boy: Medium-Dark Skin Tone, Girl: Medium-Dark Skin Tone" }, // 1f468-1f3fe-200d-1f468-1f3fe-200d-1f466-1f3fe-200d-1f467-1f3fe
            { "\U0001f468\U0001f3fe\u200d\U0001f468\U0001f3fe\u200d\U0001f466\U0001f3fe\u200d\U0001f466\U0001f3fe", "Family - Man: Medium-Dark Skin Tone, Man: Medium-Dark Skin Tone, Boy: Medium-Dark Skin Tone, Boy: Medium-Dark Skin Tone" }, // 1f468-1f3fe-200d-1f468-1f3fe-200d-1f466-1f3fe-200d-1f466-1f3fe
            { "\U0001f468\U0001f3fd\u200d\U0001f469\U0001f3fd\u200d\U0001f476\U0001f3fd\u200d\U0001f476\U0001f3fd", "Family - Man: Medium Skin Tone, Woman: Medium Skin Tone, Baby: Medium Skin Tone, Baby: Medium Skin Tone" }, // 1f468-1f3fd-200d-1f469-1f3fd-200d-1f476-1f3fd-200d-1f476-1f3fd
            { "\U0001f468\U0001f3fd\u200d\U0001f469\U0001f3fd\u200d\U0001f476\U0001f3fd\u200d\U0001f467\U0001f3fd", "Family - Man: Medium Skin Tone, Woman: Medium Skin Tone, Baby: Medium Skin Tone, Girl: Medium Skin Tone" }, // 1f468-1f3fd-200d-1f469-1f3fd-200d-1f476-1f3fd-200d-1f467-1f3fd
            { "\U0001f468\U0001f3fd\u200d\U0001f469\U0001f3fd\u200d\U0001f476\U0001f3fd\u200d\U0001f466\U0001f3fd", "Family - Man: Medium Skin Tone, Woman: Medium Skin Tone, Baby: Medium Skin Tone, Boy: Medium Skin Tone" }, // 1f468-1f3fd-200d-1f469-1f3fd-200d-1f476-1f3fd-200d-1f466-1f3fd
            { "\U0001f468\U0001f3fd\u200d\U0001f469\U0001f3fd\u200d\U0001f467\U0001f3fd\u200d\U0001f476\U0001f3fd", "Family - Man: Medium Skin Tone, Woman: Medium Skin Tone, Girl: Medium Skin Tone, Baby: Medium Skin Tone" }, // 1f468-1f3fd-200d-1f469-1f3fd-200d-1f467-1f3fd-200d-1f476-1f3fd
            { "\U0001f469\U0001f3ff\u200d\U0001f468\U0001f3ff\u200d\U0001f466\U0001f3ff\u200d\U0001f466\U0001f3ff", "Family - Woman: Dark Skin Tone, Man: Dark Skin Tone, Boy: Dark Skin Tone, Boy: Dark Skin Tone" }, // 1f469-1f3ff-200d-1f468-1f3ff-200d-1f466-1f3ff-200d-1f466-1f3ff
            { "\U0001f469\U0001f3fe\u200d\U0001f469\U0001f3fe\u200d\U0001f476\U0001f3fe\u200d\U0001f476\U0001f3fe", "Family - Woman: Medium-Dark Skin Tone, Woman: Medium-Dark Skin Tone, Baby: Medium-Dark Skin Tone, Baby: Medium-Dark Skin Tone" }, // 1f469-1f3fe-200d-1f469-1f3fe-200d-1f476-1f3fe-200d-1f476-1f3fe
            { "\U0001f469\U0001f3fe\u200d\U0001f469\U0001f3fe\u200d\U0001f476\U0001f3fe\u200d\U0001f467\U0001f3fe", "Family - Woman: Medium-Dark Skin Tone, Woman: Medium-Dark Skin Tone, Baby: Medium-Dark Skin Tone, Girl: Medium-Dark Skin Tone" }, // 1f469-1f3fe-200d-1f469-1f3fe-200d-1f476-1f3fe-200d-1f467-1f3fe
            { "\U0001f469\U0001f3fe\u200d\U0001f469\U0001f3fe\u200d\U0001f476\U0001f3fe\u200d\U0001f466\U0001f3fe", "Family - Woman: Medium-Dark Skin Tone, Woman: Medium-Dark Skin Tone, Baby: Medium-Dark Skin Tone, Boy: Medium-Dark Skin Tone" }, // 1f469-1f3fe-200d-1f469-1f3fe-200d-1f476-1f3fe-200d-1f466-1f3fe
            { "\U0001f469\U0001f3fe\u200d\U0001f469\U0001f3fe\u200d\U0001f467\U0001f3fe\u200d\U0001f476\U0001f3fe", "Family - Woman: Medium-Dark Skin Tone, Woman: Medium-Dark Skin Tone, Girl: Medium-Dark Skin Tone, Baby: Medium-Dark Skin Tone" }, // 1f469-1f3fe-200d-1f469-1f3fe-200d-1f467-1f3fe-200d-1f476-1f3fe
            { "\U0001f469\U0001f3fe\u200d\U0001f469\U0001f3fe\u200d\U0001f467\U0001f3fe\u200d\U0001f467\U0001f3fe", "Family - Woman: Medium-Dark Skin Tone, Woman: Medium-Dark Skin Tone, Girl: Medium-Dark Skin Tone, Girl: Medium-Dark Skin Tone" }, // 1f469-1f3fe-200d-1f469-1f3fe-200d-1f467-1f3fe-200d-1f467-1f3fe
            { "\U0001f469\U0001f3fe\u200d\U0001f469\U0001f3fe\u200d\U0001f467\U0001f3fe\u200d\U0001f466\U0001f3fe", "Family - Woman: Medium-Dark Skin Tone, Woman: Medium-Dark Skin Tone, Girl: Medium-Dark Skin Tone, Boy: Medium-Dark Skin Tone" }, // 1f469-1f3fe-200d-1f469-1f3fe-200d-1f467-1f3fe-200d-1f466-1f3fe
            { "\U0001f469\U0001f3fe\u200d\U0001f469\U0001f3fe\u200d\U0001f466\U0001f3fe\u200d\U0001f476\U0001f3fe", "Family - Woman: Medium-Dark Skin Tone, Woman: Medium-Dark Skin Tone, Boy: Medium-Dark Skin Tone, Baby: Medium-Dark Skin Tone" }, // 1f469-1f3fe-200d-1f469-1f3fe-200d-1f466-1f3fe-200d-1f476-1f3fe
            { "\U0001f469\U0001f3fe\u200d\U0001f469\U0001f3fe\u200d\U0001f466\U0001f3fe\u200d\U0001f467\U0001f3fe", "Family - Woman: Medium-Dark Skin Tone, Woman: Medium-Dark Skin Tone, Boy: Medium-Dark Skin Tone, Girl: Medium-Dark Skin Tone" }, // 1f469-1f3fe-200d-1f469-1f3fe-200d-1f466-1f3fe-200d-1f467-1f3fe
            { "\U0001f469\U0001f3fe\u200d\U0001f469\U0001f3fe\u200d\U0001f466\U0001f3fe\u200d\U0001f466\U0001f3fe", "Family - Woman: Medium-Dark Skin Tone, Woman: Medium-Dark Skin Tone, Boy: Medium-Dark Skin Tone, Boy: Medium-Dark Skin Tone" }, // 1f469-1f3fe-200d-1f469-1f3fe-200d-1f466-1f3fe-200d-1f466-1f3fe
            { "\U0001f469\U0001f3fe\u200d\U0001f468\U0001f3fe\u200d\U0001f476\U0001f3fe\u200d\U0001f476\U0001f3fe", "Family - Woman: Medium-Dark Skin Tone, Man: Medium-Dark Skin Tone, Baby: Medium-Dark Skin Tone, Baby: Medium-Dark Skin Tone" }, // 1f469-1f3fe-200d-1f468-1f3fe-200d-1f476-1f3fe-200d-1f476-1f3fe
            { "\U0001f469\U0001f3fe\u200d\U0001f468\U0001f3fe\u200d\U0001f476\U0001f3fe\u200d\U0001f467\U0001f3fe", "Family - Woman: Medium-Dark Skin Tone, Man: Medium-Dark Skin Tone, Baby: Medium-Dark Skin Tone, Girl: Medium-Dark Skin Tone" }, // 1f469-1f3fe-200d-1f468-1f3fe-200d-1f476-1f3fe-200d-1f467-1f3fe
            { "\U0001f469\U0001f3fe\u200d\U0001f468\U0001f3fe\u200d\U0001f476\U0001f3fe\u200d\U0001f466\U0001f3fe", "Family - Woman: Medium-Dark Skin Tone, Man: Medium-Dark Skin Tone, Baby: Medium-Dark Skin Tone, Boy: Medium-Dark Skin Tone" }, // 1f469-1f3fe-200d-1f468-1f3fe-200d-1f476-1f3fe-200d-1f466-1f3fe
            { "\U0001f469\U0001f3fe\u200d\U0001f468\U0001f3fe\u200d\U0001f467\U0001f3fe\u200d\U0001f467\U0001f3fe", "Family - Woman: Medium-Dark Skin Tone, Man: Medium-Dark Skin Tone, Girl: Medium-Dark Skin Tone, Girl: Medium-Dark Skin Tone" }, // 1f469-1f3fe-200d-1f468-1f3fe-200d-1f467-1f3fe-200d-1f467-1f3fe
            { "\U0001f469\U0001f3fe\u200d\U0001f468\U0001f3fe\u200d\U0001f467\U0001f3fe\u200d\U0001f466\U0001f3fe", "Family - Woman: Medium-Dark Skin Tone, Man: Medium-Dark Skin Tone, Girl: Medium-Dark Skin Tone, Boy: Medium-Dark Skin Tone" }, // 1f469-1f3fe-200d-1f468-1f3fe-200d-1f467-1f3fe-200d-1f466-1f3fe
            { "\U0001f469\U0001f3fe\u200d\U0001f468\U0001f3fe\u200d\U0001f466\U0001f3fe\u200d\U0001f476\U0001f3fe", "Family - Woman: Medium-Dark Skin Tone, Man: Medium-Dark Skin Tone, Boy: Medium-Dark Skin Tone, Baby: Medium-Dark Skin Tone" }, // 1f469-1f3fe-200d-1f468-1f3fe-200d-1f466-1f3fe-200d-1f476-1f3fe
            { "\U0001f469\U0001f3fe\u200d\U0001f468\U0001f3fe\u200d\U0001f466\U0001f3fe\u200d\U0001f467\U0001f3fe", "Family - Woman: Medium-Dark Skin Tone, Man: Medium-Dark Skin Tone, Boy: Medium-Dark Skin Tone, Girl: Medium-Dark Skin Tone" }, // 1f469-1f3fe-200d-1f468-1f3fe-200d-1f466-1f3fe-200d-1f467-1f3fe
            { "\U0001f469\U0001f3fe\u200d\U0001f468\U0001f3fe\u200d\U0001f466\U0001f3fe\u200d\U0001f466\U0001f3fe", "Family - Woman: Medium-Dark Skin Tone, Man: Medium-Dark Skin Tone, Boy: Medium-Dark Skin Tone, Boy: Medium-Dark Skin Tone" }, // 1f469-1f3fe-200d-1f468-1f3fe-200d-1f466-1f3fe-200d-1f466-1f3fe
            { "\U0001f469\U0001f3fd\u200d\U0001f469\U0001f3fd\u200d\U0001f476\U0001f3fd\u200d\U0001f476\U0001f3fd", "Family - Woman: Medium Skin Tone, Woman: Medium Skin Tone, Baby: Medium Skin Tone, Baby: Medium Skin Tone" }, // 1f469-1f3fd-200d-1f469-1f3fd-200d-1f476-1f3fd-200d-1f476-1f3fd
            { "\U0001f469\U0001f3fd\u200d\U0001f469\U0001f3fd\u200d\U0001f476\U0001f3fd\u200d\U0001f467\U0001f3fd", "Family - Woman: Medium Skin Tone, Woman: Medium Skin Tone, Baby: Medium Skin Tone, Girl: Medium Skin Tone" }, // 1f469-1f3fd-200d-1f469-1f3fd-200d-1f476-1f3fd-200d-1f467-1f3fd
            { "\U0001f469\U0001f3fd\u200d\U0001f469\U0001f3fd\u200d\U0001f476\U0001f3fd\u200d\U0001f466\U0001f3fd", "Family - Woman: Medium Skin Tone, Woman: Medium Skin Tone, Baby: Medium Skin Tone, Boy: Medium Skin Tone" }, // 1f469-1f3fd-200d-1f469-1f3fd-200d-1f476-1f3fd-200d-1f466-1f3fd
            { "\U0001f469\U0001f3fd\u200d\U0001f469\U0001f3fd\u200d\U0001f467\U0001f3fd\u200d\U0001f476\U0001f3fd", "Family - Woman: Medium Skin Tone, Woman: Medium Skin Tone, Girl: Medium Skin Tone, Baby: Medium Skin Tone" }, // 1f469-1f3fd-200d-1f469-1f3fd-200d-1f467-1f3fd-200d-1f476-1f3fd
            { "\U0001f469\U0001f3fd\u200d\U0001f469\U0001f3fd\u200d\U0001f467\U0001f3fd\u200d\U0001f467\U0001f3fd", "Family - Woman: Medium Skin Tone, Woman: Medium Skin Tone, Girl: Medium Skin Tone, Girl: Medium Skin Tone" }, // 1f469-1f3fd-200d-1f469-1f3fd-200d-1f467-1f3fd-200d-1f467-1f3fd
            { "\U0001f469\U0001f3fd\u200d\U0001f469\U0001f3fd\u200d\U0001f467\U0001f3fd\u200d\U0001f466\U0001f3fd", "Family - Woman: Medium Skin Tone, Woman: Medium Skin Tone, Girl: Medium Skin Tone, Boy: Medium Skin Tone" }, // 1f469-1f3fd-200d-1f469-1f3fd-200d-1f467-1f3fd-200d-1f466-1f3fd
            { "\U0001f469\U0001f3fd\u200d\U0001f469\U0001f3fd\u200d\U0001f466\U0001f3fd\u200d\U0001f476\U0001f3fd", "Family - Woman: Medium Skin Tone, Woman: Medium Skin Tone, Boy: Medium Skin Tone, Baby: Medium Skin Tone" }, // 1f469-1f3fd-200d-1f469-1f3fd-200d-1f466-1f3fd-200d-1f476-1f3fd
            { "\U0001f469\U0001f3fd\u200d\U0001f469\U0001f3fd\u200d\U0001f466\U0001f3fd\u200d\U0001f467\U0001f3fd", "Family - Woman: Medium Skin Tone, Woman: Medium Skin Tone, Boy: Medium Skin Tone, Girl: Medium Skin Tone" }, // 1f469-1f3fd-200d-1f469-1f3fd-200d-1f466-1f3fd-200d-1f467-1f3fd
            { "\U0001f469\U0001f3fd\u200d\U0001f469\U0001f3fd\u200d\U0001f466\U0001f3fd\u200d\U0001f466\U0001f3fd", "Family - Woman: Medium Skin Tone, Woman: Medium Skin Tone, Boy: Medium Skin Tone, Boy: Medium Skin Tone" }, // 1f469-1f3fd-200d-1f469-1f3fd-200d-1f466-1f3fd-200d-1f466-1f3fd
            { "\U0001f469\U0001f3fd\u200d\U0001f468\U0001f3fd\u200d\U0001f476\U0001f3fd\u200d\U0001f476\U0001f3fd", "Family - Woman: Medium Skin Tone, Man: Medium Skin Tone, Baby: Medium Skin Tone, Baby: Medium Skin Tone" }, // 1f469-1f3fd-200d-1f468-1f3fd-200d-1f476-1f3fd-200d-1f476-1f3fd
            { "\U0001f469\U0001f3fd\u200d\U0001f468\U0001f3fd\u200d\U0001f476\U0001f3fd\u200d\U0001f467\U0001f3fd", "Family - Woman: Medium Skin Tone, Man: Medium Skin Tone, Baby: Medium Skin Tone, Girl: Medium Skin Tone" }, // 1f469-1f3fd-200d-1f468-1f3fd-200d-1f476-1f3fd-200d-1f467-1f3fd
            { "\U0001f469\U0001f3fd\u200d\U0001f468\U0001f3fd\u200d\U0001f476\U0001f3fd\u200d\U0001f466\U0001f3fd", "Family - Woman: Medium Skin Tone, Man: Medium Skin Tone, Baby: Medium Skin Tone, Boy: Medium Skin Tone" }, // 1f469-1f3fd-200d-1f468-1f3fd-200d-1f476-1f3fd-200d-1f466-1f3fd
            { "\U0001f469\U0001f3fd\u200d\U0001f468\U0001f3fd\u200d\U0001f467\U0001f3fd\u200d\U0001f476\U0001f3fd", "Family - Woman: Medium Skin Tone, Man: Medium Skin Tone, Girl: Medium Skin Tone, Baby: Medium Skin Tone" }, // 1f469-1f3fd-200d-1f468-1f3fd-200d-1f467-1f3fd-200d-1f476-1f3fd
            { "\U0001f469\U0001f3fd\u200d\U0001f468\U0001f3fd\u200d\U0001f467\U0001f3fd\u200d\U0001f467\U0001f3fd", "Family - Woman: Medium Skin Tone, Man: Medium Skin Tone, Girl: Medium Skin Tone, Girl: Medium Skin Tone" }, // 1f469-1f3fd-200d-1f468-1f3fd-200d-1f467-1f3fd-200d-1f467-1f3fd
            { "\U0001f469\U0001f3fd\u200d\U0001f468\U0001f3fd\u200d\U0001f467\U0001f3fd\u200d\U0001f466\U0001f3fd", "Family - Woman: Medium Skin Tone, Man: Medium Skin Tone, Girl: Medium Skin Tone, Boy: Medium Skin Tone" }, // 1f469-1f3fd-200d-1f468-1f3fd-200d-1f467-1f3fd-200d-1f466-1f3fd
            { "\U0001f469\U0001f3fd\u200d\U0001f468\U0001f3fd\u200d\U0001f466\U0001f3fd\u200d\U0001f476\U0001f3fd", "Family - Woman: Medium Skin Tone, Man: Medium Skin Tone, Boy: Medium Skin Tone, Baby: Medium Skin Tone" }, // 1f469-1f3fd-200d-1f468-1f3fd-200d-1f466-1f3fd-200d-1f476-1f3fd
            { "\U0001f469\U0001f3fd\u200d\U0001f468\U0001f3fd\u200d\U0001f466\U0001f3fd\u200d\U0001f467\U0001f3fd", "Family - Woman: Medium Skin Tone, Man: Medium Skin Tone, Boy: Medium Skin Tone, Girl: Medium Skin Tone" }, // 1f469-1f3fd-200d-1f468-1f3fd-200d-1f466-1f3fd-200d-1f467-1f3fd
            { "\U0001f469\U0001f3fd\u200d\U0001f468\U0001f3fd\u200d\U0001f466\U0001f3fd\u200d\U0001f466\U0001f3fd", "Family - Woman: Medium Skin Tone, Man: Medium Skin Tone, Boy: Medium Skin Tone, Boy: Medium Skin Tone" }, // 1f469-1f3fd-200d-1f468-1f3fd-200d-1f466-1f3fd-200d-1f466-1f3fd
            { "\U0001f469\U0001f3fc\u200d\U0001f469\U0001f3fc\u200d\U0001f476\U0001f3fc\u200d\U0001f476\U0001f3fc", "Family - Woman: Medium-Light Skin Tone, Woman: Medium-Light Skin Tone, Baby: Medium-Light Skin Tone, Baby: Medium-Light Skin Tone" }, // 1f469-1f3fc-200d-1f469-1f3fc-200d-1f476-1f3fc-200d-1f476-1f3fc
            { "\U0001f469\U0001f3fc\u200d\U0001f469\U0001f3fc\u200d\U0001f476\U0001f3fc\u200d\U0001f467\U0001f3fc", "Family - Woman: Medium-Light Skin Tone, Woman: Medium-Light Skin Tone, Baby: Medium-Light Skin Tone, Girl: Medium-Light Skin Tone" }, // 1f469-1f3fc-200d-1f469-1f3fc-200d-1f476-1f3fc-200d-1f467-1f3fc
            { "\U0001f469\U0001f3fc\u200d\U0001f469\U0001f3fc\u200d\U0001f476\U0001f3fc\u200d\U0001f466\U0001f3fc", "Family - Woman: Medium-Light Skin Tone, Woman: Medium-Light Skin Tone, Baby: Medium-Light Skin Tone, Boy: Medium-Light Skin Tone" }, // 1f469-1f3fc-200d-1f469-1f3fc-200d-1f476-1f3fc-200d-1f466-1f3fc
            { "\U0001f469\U0001f3fc\u200d\U0001f469\U0001f3fc\u200d\U0001f467\U0001f3fc\u200d\U0001f476\U0001f3fc", "Family - Woman: Medium-Light Skin Tone, Woman: Medium-Light Skin Tone, Girl: Medium-Light Skin Tone, Baby: Medium-Light Skin Tone" }, // 1f469-1f3fc-200d-1f469-1f3fc-200d-1f467-1f3fc-200d-1f476-1f3fc
            { "\U0001f469\U0001f3fc\u200d\U0001f469\U0001f3fc\u200d\U0001f467\U0001f3fc\u200d\U0001f467\U0001f3fc", "Family - Woman: Medium-Light Skin Tone, Woman: Medium-Light Skin Tone, Girl: Medium-Light Skin Tone, Girl: Medium-Light Skin Tone" }, // 1f469-1f3fc-200d-1f469-1f3fc-200d-1f467-1f3fc-200d-1f467-1f3fc
            { "\U0001f469\U0001f3fc\u200d\U0001f469\U0001f3fc\u200d\U0001f467\U0001f3fc\u200d\U0001f466\U0001f3fc", "Family - Woman: Medium-Light Skin Tone, Woman: Medium-Light Skin Tone, Girl: Medium-Light Skin Tone, Boy: Medium-Light Skin Tone" }, // 1f469-1f3fc-200d-1f469-1f3fc-200d-1f467-1f3fc-200d-1f466-1f3fc
            { "\U0001f469\U0001f3fc\u200d\U0001f469\U0001f3fc\u200d\U0001f466\U0001f3fc\u200d\U0001f476\U0001f3fc", "Family - Woman: Medium-Light Skin Tone, Woman: Medium-Light Skin Tone, Boy: Medium-Light Skin Tone, Baby: Medium-Light Skin Tone" }, // 1f469-1f3fc-200d-1f469-1f3fc-200d-1f466-1f3fc-200d-1f476-1f3fc
            { "\U0001f469\U0001f3fc\u200d\U0001f469\U0001f3fc\u200d\U0001f466\U0001f3fc\u200d\U0001f467\U0001f3fc", "Family - Woman: Medium-Light Skin Tone, Woman: Medium-Light Skin Tone, Boy: Medium-Light Skin Tone, Girl: Medium-Light Skin Tone" }, // 1f469-1f3fc-200d-1f469-1f3fc-200d-1f466-1f3fc-200d-1f467-1f3fc
            { "\U0001f469\U0001f3fc\u200d\U0001f469\U0001f3fc\u200d\U0001f466\U0001f3fc\u200d\U0001f466\U0001f3fc", "Family - Woman: Medium-Light Skin Tone, Woman: Medium-Light Skin Tone, Boy: Medium-Light Skin Tone, Boy: Medium-Light Skin Tone" }, // 1f469-1f3fc-200d-1f469-1f3fc-200d-1f466-1f3fc-200d-1f466-1f3fc
            { "\U0001f468\U0001f3fc\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3ff", "Couple With Heart - Man: Medium-Light Skin Tone, Man: Dark Skin Tone" }, // 1f468-1f3fc-200d-2764-fe0f-200d-1f468-1f3ff
            { "\U0001f468\U0001f3fb\u200d\U0001f469\U0001f3fb\u200d\U0001f466\U0001f3fb\u200d\U0001f467\U0001f3fb", "Family - Man: Light Skin Tone, Woman: Light Skin Tone, Boy: Light Skin Tone, Girl: Light Skin Tone" }, // 1f468-1f3fb-200d-1f469-1f3fb-200d-1f466-1f3fb-200d-1f467-1f3fb
            { "\U0001f468\U0001f3fb\u200d\U0001f469\U0001f3fb\u200d\U0001f466\U0001f3fb\u200d\U0001f466\U0001f3fb", "Family - Man: Light Skin Tone, Woman: Light Skin Tone, Boy: Light Skin Tone, Boy: Light Skin Tone" }, // 1f468-1f3fb-200d-1f469-1f3fb-200d-1f466-1f3fb-200d-1f466-1f3fb
            { "\U0001f468\U0001f3fb\u200d\U0001f468\U0001f3fb\u200d\U0001f476\U0001f3fb\u200d\U0001f476\U0001f3fb", "Family - Man: Light Skin Tone, Man: Light Skin Tone, Baby: Light Skin Tone, Baby: Light Skin Tone" }, // 1f468-1f3fb-200d-1f468-1f3fb-200d-1f476-1f3fb-200d-1f476-1f3fb
            { "\U0001f468\U0001f3fb\u200d\U0001f468\U0001f3fb\u200d\U0001f476\U0001f3fb\u200d\U0001f467\U0001f3fb", "Family - Man: Light Skin Tone, Man: Light Skin Tone, Baby: Light Skin Tone, Girl: Light Skin Tone" }, // 1f468-1f3fb-200d-1f468-1f3fb-200d-1f476-1f3fb-200d-1f467-1f3fb
            { "\U0001f468\U0001f3fb\u200d\U0001f468\U0001f3fb\u200d\U0001f476\U0001f3fb\u200d\U0001f466\U0001f3fb", "Family - Man: Light Skin Tone, Man: Light Skin Tone, Baby: Light Skin Tone, Boy: Light Skin Tone" }, // 1f468-1f3fb-200d-1f468-1f3fb-200d-1f476-1f3fb-200d-1f466-1f3fb
            { "\U0001f468\U0001f3fb\u200d\U0001f468\U0001f3fb\u200d\U0001f467\U0001f3fb\u200d\U0001f476\U0001f3fb", "Family - Man: Light Skin Tone, Man: Light Skin Tone, Girl: Light Skin Tone, Baby: Light Skin Tone" }, // 1f468-1f3fb-200d-1f468-1f3fb-200d-1f467-1f3fb-200d-1f476-1f3fb
            { "\U0001f468\U0001f3fb\u200d\U0001f468\U0001f3fb\u200d\U0001f467\U0001f3fb\u200d\U0001f467\U0001f3fb", "Family - Man: Light Skin Tone, Man: Light Skin Tone, Girl: Light Skin Tone, Girl: Light Skin Tone" }, // 1f468-1f3fb-200d-1f468-1f3fb-200d-1f467-1f3fb-200d-1f467-1f3fb
            { "\U0001f468\U0001f3fb\u200d\U0001f468\U0001f3fb\u200d\U0001f467\U0001f3fb\u200d\U0001f466\U0001f3fb", "Family - Man: Light Skin Tone, Man: Light Skin Tone, Girl: Light Skin Tone, Boy: Light Skin Tone" }, // 1f468-1f3fb-200d-1f468-1f3fb-200d-1f467-1f3fb-200d-1f466-1f3fb
            { "\U0001f468\U0001f3fb\u200d\U0001f468\U0001f3fb\u200d\U0001f466\U0001f3fb\u200d\U0001f476\U0001f3fb", "Family - Man: Light Skin Tone, Man: Light Skin Tone, Boy: Light Skin Tone, Baby: Light Skin Tone" }, // 1f468-1f3fb-200d-1f468-1f3fb-200d-1f466-1f3fb-200d-1f476-1f3fb
            { "\U0001f468\U0001f3fb\u200d\U0001f468\U0001f3fb\u200d\U0001f466\U0001f3fb\u200d\U0001f467\U0001f3fb", "Family - Man: Light Skin Tone, Man: Light Skin Tone, Boy: Light Skin Tone, Girl: Light Skin Tone" }, // 1f468-1f3fb-200d-1f468-1f3fb-200d-1f466-1f3fb-200d-1f467-1f3fb
            { "\U0001f468\U0001f3fb\u200d\U0001f468\U0001f3fb\u200d\U0001f466\U0001f3fb\u200d\U0001f466\U0001f3fb", "Family - Man: Light Skin Tone, Man: Light Skin Tone, Boy: Light Skin Tone, Boy: Light Skin Tone" }, // 1f468-1f3fb-200d-1f468-1f3fb-200d-1f466-1f3fb-200d-1f466-1f3fb
            { "\U0001f469\u200d\U0001f468\u200d\U0001f467", "Family: Woman, Man, Girl" }, // 1f469-200d-1f468-200d-1f467
            { "\U0001f469\U0001f3fc\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3ff", "Couple With Heart - Woman: Medium-Light Skin Tone, Woman: Dark Skin Tone" }, // 1f469-1f3fc-200d-2764-fe0f-200d-1f469-1f3ff
            { "\U0001f469\u200d\U0001f468\u200d\U0001f466", "Family: Woman, Man, Boy" }, // 1f469-200d-1f468-200d-1f466
            { "\U0001f469\U0001f3fe\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3ff", "Couple With Heart - Woman: Medium-Dark Skin Tone, Man: Dark Skin Tone" }, // 1f469-1f3fe-200d-2764-fe0f-200d-1f468-1f3ff
            { "\U0001f468\U0001f3fe\u200d\U0001f469\U0001f3fe\u200d\U0001f466\U0001f3fe", "Family - Man: Medium-Dark Skin Tone, Woman: Medium-Dark Skin Tone, Boy: Medium-Dark Skin Tone" }, // 1f468-1f3fe-200d-1f469-1f3fe-200d-1f466-1f3fe
            { "\U0001f468\U0001f3fe\u200d\U0001f468\U0001f3fe\u200d\U0001f476\U0001f3fe", "Family - Man: Medium-Dark Skin Tone, Man: Medium-Dark Skin Tone, Baby: Medium-Dark Skin Tone" }, // 1f468-1f3fe-200d-1f468-1f3fe-200d-1f476-1f3fe
            { "\U0001f468\U0001f3fe\u200d\U0001f468\U0001f3fe\u200d\U0001f467\U0001f3fe", "Family - Man: Medium-Dark Skin Tone, Man: Medium-Dark Skin Tone, Girl: Medium-Dark Skin Tone" }, // 1f468-1f3fe-200d-1f468-1f3fe-200d-1f467-1f3fe
            { "\U0001f468\U0001f3fe\u200d\U0001f468\U0001f3fe\u200d\U0001f466\U0001f3fe", "Family - Man: Medium-Dark Skin Tone, Man: Medium-Dark Skin Tone, Boy: Medium-Dark Skin Tone" }, // 1f468-1f3fe-200d-1f468-1f3fe-200d-1f466-1f3fe
            { "\U0001f468\U0001f3fd\u200d\U0001f469\U0001f3fd\u200d\U0001f476\U0001f3fd", "Family - Man: Medium Skin Tone, Woman: Medium Skin Tone, Baby: Medium Skin Tone" }, // 1f468-1f3fd-200d-1f469-1f3fd-200d-1f476-1f3fd
            { "\U0001f468\U0001f3fd\u200d\U0001f469\U0001f3fd\u200d\U0001f467\U0001f3fd", "Family - Man: Medium Skin Tone, Woman: Medium Skin Tone, Girl: Medium Skin Tone" }, // 1f468-1f3fd-200d-1f469-1f3fd-200d-1f467-1f3fd
            { "\U0001f468\U0001f3fd\u200d\U0001f469\U0001f3fd\u200d\U0001f466\U0001f3fd", "Family - Man: Medium Skin Tone, Woman: Medium Skin Tone, Boy: Medium Skin Tone" }, // 1f468-1f3fd-200d-1f469-1f3fd-200d-1f466-1f3fd
            { "\U0001f468\U0001f3fd\u200d\U0001f468\U0001f3fd\u200d\U0001f476\U0001f3fd", "Family - Man: Medium Skin Tone, Man: Medium Skin Tone, Baby: Medium Skin Tone" }, // 1f468-1f3fd-200d-1f468-1f3fd-200d-1f476-1f3fd
            { "\U0001f468\U0001f3fd\u200d\U0001f468\U0001f3fd\u200d\U0001f467\U0001f3fd", "Family - Man: Medium Skin Tone, Man: Medium Skin Tone, Girl: Medium Skin Tone" }, // 1f468-1f3fd-200d-1f468-1f3fd-200d-1f467-1f3fd
            { "\U0001f468\U0001f3fd\u200d\U0001f468\U0001f3fd\u200d\U0001f466\U0001f3fd", "Family - Man: Medium Skin Tone, Man: Medium Skin Tone, Boy: Medium Skin Tone" }, // 1f468-1f3fd-200d-1f468-1f3fd-200d-1f466-1f3fd
            { "\U0001f468\U0001f3fc\u200d\U0001f469\U0001f3fc\u200d\U0001f476\U0001f3fc", "Family - Man: Medium-Light Skin Tone, Woman: Medium-Light Skin Tone, Baby: Medium-Light Skin Tone" }, // 1f468-1f3fc-200d-1f469-1f3fc-200d-1f476-1f3fc
            { "\U0001f468\U0001f3fc\u200d\U0001f469\U0001f3fc\u200d\U0001f467\U0001f3fc", "Family - Man: Medium-Light Skin Tone, Woman: Medium-Light Skin Tone, Girl: Medium-Light Skin Tone" }, // 1f468-1f3fc-200d-1f469-1f3fc-200d-1f467-1f3fc
            { "\U0001f468\U0001f3fc\u200d\U0001f469\U0001f3fc\u200d\U0001f466\U0001f3fc", "Family - Man: Medium-Light Skin Tone, Woman: Medium-Light Skin Tone, Boy: Medium-Light Skin Tone" }, // 1f468-1f3fc-200d-1f469-1f3fc-200d-1f466-1f3fc
            { "\U0001f468\U0001f3fc\u200d\U0001f468\U0001f3fc\u200d\U0001f476\U0001f3fc", "Family - Man: Medium-Light Skin Tone, Man: Medium-Light Skin Tone, Baby: Medium-Light Skin Tone" }, // 1f468-1f3fc-200d-1f468-1f3fc-200d-1f476-1f3fc
            { "\U0001f468\U0001f3fc\u200d\U0001f468\U0001f3fc\u200d\U0001f467\U0001f3fc", "Family - Man: Medium-Light Skin Tone, Man: Medium-Light Skin Tone, Girl: Medium-Light Skin Tone" }, // 1f468-1f3fc-200d-1f468-1f3fc-200d-1f467-1f3fc
            { "\U0001f469\U0001f3fc\u200d\U0001f467\U0001f3fc\u200d\U0001f476\U0001f3fc", "Family - Woman: Medium-Light Skin Tone, Girl: Medium-Light Skin Tone, Baby: Medium-Light Skin Tone" }, // 1f469-1f3fc-200d-1f467-1f3fc-200d-1f476-1f3fc
            { "\U0001f469\U0001f3fc\u200d\U0001f467\U0001f3fc\u200d\U0001f467\U0001f3fc", "Family - Woman: Medium-Light Skin Tone, Girl: Medium-Light Skin Tone, Girl: Medium-Light Skin Tone" }, // 1f469-1f3fc-200d-1f467-1f3fc-200d-1f467-1f3fc
            { "\U0001f469\U0001f3fc\u200d\U0001f467\U0001f3fc\u200d\U0001f466\U0001f3fc", "Family - Woman: Medium-Light Skin Tone, Girl: Medium-Light Skin Tone, Boy: Medium-Light Skin Tone" }, // 1f469-1f3fc-200d-1f467-1f3fc-200d-1f466-1f3fc
            { "\U0001f469\U0001f3fc\u200d\U0001f466\U0001f3fc\u200d\U0001f476\U0001f3fc", "Family - Woman: Medium-Light Skin Tone, Boy: Medium-Light Skin Tone, Baby: Medium-Light Skin Tone" }, // 1f469-1f3fc-200d-1f466-1f3fc-200d-1f476-1f3fc
            { "\U0001f469\U0001f3fc\u200d\U0001f466\U0001f3fc\u200d\U0001f467\U0001f3fc", "Family - Woman: Medium-Light Skin Tone, Boy: Medium-Light Skin Tone, Girl: Medium-Light Skin Tone" }, // 1f469-1f3fc-200d-1f466-1f3fc-200d-1f467-1f3fc
            { "\U0001f469\U0001f3fc\u200d\U0001f466\U0001f3fc\u200d\U0001f466\U0001f3fc", "Family - Woman: Medium-Light Skin Tone, Boy: Medium-Light Skin Tone, Boy: Medium-Light Skin Tone" }, // 1f469-1f3fc-200d-1f466-1f3fc-200d-1f466-1f3fc
            { "\U0001f469\U0001f3fb\u200d\U0001f476\U0001f3fb\u200d\U0001f476\U0001f3fb", "Family - Woman: Light Skin Tone, Baby: Light Skin Tone, Baby: Light Skin Tone" }, // 1f469-1f3fb-200d-1f476-1f3fb-200d-1f476-1f3fb
            { "\U0001f469\U0001f3fb\u200d\U0001f476\U0001f3fb\u200d\U0001f467\U0001f3fb", "Family - Woman: Light Skin Tone, Baby: Light Skin Tone, Girl: Light Skin Tone" }, // 1f469-1f3fb-200d-1f476-1f3fb-200d-1f467-1f3fb
            { "\U0001f469\U0001f3fb\u200d\U0001f476\U0001f3fb\u200d\U0001f466\U0001f3fb", "Family - Woman: Light Skin Tone, Baby: Light Skin Tone, Boy: Light Skin Tone" }, // 1f469-1f3fb-200d-1f476-1f3fb-200d-1f466-1f3fb
            { "\U0001f468\U0001f3fc\u200d\U0001f469\U0001f3fc\u200d\U0001f476\U0001f3fc\u200d\U0001f466\U0001f3fc", "Family - Man: Medium-Light Skin Tone, Woman: Medium-Light Skin Tone, Baby: Medium-Light Skin Tone, Boy: Medium-Light Skin Tone" }, // 1f468-1f3fc-200d-1f469-1f3fc-200d-1f476-1f3fc-200d-1f466-1f3fc
            { "\U0001f468\U0001f3fc\u200d\U0001f469\U0001f3fc\u200d\U0001f467\U0001f3fc\u200d\U0001f476\U0001f3fc", "Family - Man: Medium-Light Skin Tone, Woman: Medium-Light Skin Tone, Girl: Medium-Light Skin Tone, Baby: Medium-Light Skin Tone" }, // 1f468-1f3fc-200d-1f469-1f3fc-200d-1f467-1f3fc-200d-1f476-1f3fc
            { "\U0001f468\U0001f3fc\u200d\U0001f469\U0001f3fc\u200d\U0001f467\U0001f3fc\u200d\U0001f467\U0001f3fc", "Family - Man: Medium-Light Skin Tone, Woman: Medium-Light Skin Tone, Girl: Medium-Light Skin Tone, Girl: Medium-Light Skin Tone" }, // 1f468-1f3fc-200d-1f469-1f3fc-200d-1f467-1f3fc-200d-1f467-1f3fc
            { "\U0001f468\U0001f3fc\u200d\U0001f469\U0001f3fc\u200d\U0001f467\U0001f3fc\u200d\U0001f466\U0001f3fc", "Family - Man: Medium-Light Skin Tone, Woman: Medium-Light Skin Tone, Girl: Medium-Light Skin Tone, Boy: Medium-Light Skin Tone" }, // 1f468-1f3fc-200d-1f469-1f3fc-200d-1f467-1f3fc-200d-1f466-1f3fc
            { "\U0001f468\U0001f3fc\u200d\U0001f469\U0001f3fc\u200d\U0001f466\U0001f3fc\u200d\U0001f476\U0001f3fc", "Family - Man: Medium-Light Skin Tone, Woman: Medium-Light Skin Tone, Boy: Medium-Light Skin Tone, Baby: Medium-Light Skin Tone" }, // 1f468-1f3fc-200d-1f469-1f3fc-200d-1f466-1f3fc-200d-1f476-1f3fc
            { "\U0001f468\U0001f3fc\u200d\U0001f469\U0001f3fc\u200d\U0001f466\U0001f3fc\u200d\U0001f467\U0001f3fc", "Family - Man: Medium-Light Skin Tone, Woman: Medium-Light Skin Tone, Boy: Medium-Light Skin Tone, Girl: Medium-Light Skin Tone" }, // 1f468-1f3fc-200d-1f469-1f3fc-200d-1f466-1f3fc-200d-1f467-1f3fc
            { "\U0001f468\U0001f3fc\u200d\U0001f469\U0001f3fc\u200d\U0001f466\U0001f3fc\u200d\U0001f466\U0001f3fc", "Family - Man: Medium-Light Skin Tone, Woman: Medium-Light Skin Tone, Boy: Medium-Light Skin Tone, Boy: Medium-Light Skin Tone" }, // 1f468-1f3fc-200d-1f469-1f3fc-200d-1f466-1f3fc-200d-1f466-1f3fc
            { "\U0001f469\U0001f3fb\u200d\U0001f468\U0001f3fb\u200d\U0001f467\U0001f3fb\u200d\U0001f476\U0001f3fb", "Family - Woman: Light Skin Tone, Man: Light Skin Tone, Girl: Light Skin Tone, Baby: Light Skin Tone" }, // 1f469-1f3fb-200d-1f468-1f3fb-200d-1f467-1f3fb-200d-1f476-1f3fb
            { "\U0001f469\U0001f3fb\u200d\U0001f468\U0001f3fb\u200d\U0001f467\U0001f3fb\u200d\U0001f467\U0001f3fb", "Family - Woman: Light Skin Tone, Man: Light Skin Tone, Girl: Light Skin Tone, Girl: Light Skin Tone" }, // 1f469-1f3fb-200d-1f468-1f3fb-200d-1f467-1f3fb-200d-1f467-1f3fb
            { "\U0001f469\U0001f3fb\u200d\U0001f468\U0001f3fb\u200d\U0001f467\U0001f3fb\u200d\U0001f466\U0001f3fb", "Family - Woman: Light Skin Tone, Man: Light Skin Tone, Girl: Light Skin Tone, Boy: Light Skin Tone" }, // 1f469-1f3fb-200d-1f468-1f3fb-200d-1f467-1f3fb-200d-1f466-1f3fb
            { "\U0001f468\U0001f3fd\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3ff", "Kiss - Man: Medium Skin Tone, Man: Dark Skin Tone" }, // 1f468-1f3fd-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3ff
            { "\U0001f468\U0001f3ff\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3fd", "Couple With Heart - Man: Dark Skin Tone, Woman: Medium Skin Tone" }, // 1f468-1f3ff-200d-2764-fe0f-200d-1f469-1f3fd
            { "\U0001f468\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3fe", "Couple With Heart - Man, Woman: Medium-Dark Skin Tone" }, // 1f468-200d-2764-fe0f-200d-1f469-1f3fe
            { "\U0001f468\U0001f3fc\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3fb", "Couple With Heart - Man: Medium-Light Skin Tone, Man: Light Skin Tone" }, // 1f468-1f3fc-200d-2764-fe0f-200d-1f468-1f3fb
            { "\U0001f469\U0001f3fb\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3ff", "Kiss - Woman: Light Skin Tone, Woman: Dark Skin Tone" }, // 1f469-1f3fb-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3ff
            { "\U0001f469\U0001f3ff\u200d\U0001f469\U0001f3ff\u200d\U0001f476\U0001f3ff\u200d\U0001f466\U0001f3ff", "Family - Woman: Dark Skin Tone, Woman: Dark Skin Tone, Baby: Dark Skin Tone, Boy: Dark Skin Tone" }, // 1f469-1f3ff-200d-1f469-1f3ff-200d-1f476-1f3ff-200d-1f466-1f3ff
            { "\U0001f469\U0001f3ff\u200d\U0001f469\U0001f3ff\u200d\U0001f467\U0001f3ff\u200d\U0001f476\U0001f3ff", "Family - Woman: Dark Skin Tone, Woman: Dark Skin Tone, Girl: Dark Skin Tone, Baby: Dark Skin Tone" }, // 1f469-1f3ff-200d-1f469-1f3ff-200d-1f467-1f3ff-200d-1f476-1f3ff
            { "\U0001f469\U0001f3ff\u200d\U0001f469\U0001f3ff\u200d\U0001f467\U0001f3ff\u200d\U0001f467\U0001f3ff", "Family - Woman: Dark Skin Tone, Woman: Dark Skin Tone, Girl: Dark Skin Tone, Girl: Dark Skin Tone" }, // 1f469-1f3ff-200d-1f469-1f3ff-200d-1f467-1f3ff-200d-1f467-1f3ff
            { "\U0001f469\U0001f3ff\u200d\U0001f469\U0001f3ff\u200d\U0001f467\U0001f3ff\u200d\U0001f466\U0001f3ff", "Family - Woman: Dark Skin Tone, Woman: Dark Skin Tone, Girl: Dark Skin Tone, Boy: Dark Skin Tone" }, // 1f469-1f3ff-200d-1f469-1f3ff-200d-1f467-1f3ff-200d-1f466-1f3ff
            { "\U0001f469\U0001f3ff\u200d\U0001f469\U0001f3ff\u200d\U0001f466\U0001f3ff\u200d\U0001f476\U0001f3ff", "Family - Woman: Dark Skin Tone, Woman: Dark Skin Tone, Boy: Dark Skin Tone, Baby: Dark Skin Tone" }, // 1f469-1f3ff-200d-1f469-1f3ff-200d-1f466-1f3ff-200d-1f476-1f3ff
            { "\U0001f469\U0001f3ff\u200d\U0001f469\U0001f3ff\u200d\U0001f466\U0001f3ff\u200d\U0001f467\U0001f3ff", "Family - Woman: Dark Skin Tone, Woman: Dark Skin Tone, Boy: Dark Skin Tone, Girl: Dark Skin Tone" }, // 1f469-1f3ff-200d-1f469-1f3ff-200d-1f466-1f3ff-200d-1f467-1f3ff
            { "\U0001f469\U0001f3ff\u200d\U0001f469\U0001f3ff\u200d\U0001f466\U0001f3ff\u200d\U0001f466\U0001f3ff", "Family - Woman: Dark Skin Tone, Woman: Dark Skin Tone, Boy: Dark Skin Tone, Boy: Dark Skin Tone" }, // 1f469-1f3ff-200d-1f469-1f3ff-200d-1f466-1f3ff-200d-1f466-1f3ff
            { "\U0001f469\U0001f3ff\u200d\U0001f468\U0001f3ff\u200d\U0001f476\U0001f3ff\u200d\U0001f476\U0001f3ff", "Family - Woman: Dark Skin Tone, Man: Dark Skin Tone, Baby: Dark Skin Tone, Baby: Dark Skin Tone" }, // 1f469-1f3ff-200d-1f468-1f3ff-200d-1f476-1f3ff-200d-1f476-1f3ff
            { "\U0001f469\U0001f3ff\u200d\U0001f468\U0001f3ff\u200d\U0001f476\U0001f3ff\u200d\U0001f467\U0001f3ff", "Family - Woman: Dark Skin Tone, Man: Dark Skin Tone, Baby: Dark Skin Tone, Girl: Dark Skin Tone" }, // 1f469-1f3ff-200d-1f468-1f3ff-200d-1f476-1f3ff-200d-1f467-1f3ff
            { "\U0001f469\U0001f3ff\u200d\U0001f468\U0001f3ff\u200d\U0001f476\U0001f3ff\u200d\U0001f466\U0001f3ff", "Family - Woman: Dark Skin Tone, Man: Dark Skin Tone, Baby: Dark Skin Tone, Boy: Dark Skin Tone" }, // 1f469-1f3ff-200d-1f468-1f3ff-200d-1f476-1f3ff-200d-1f466-1f3ff
            { "\U0001f469\U0001f3ff\u200d\U0001f468\U0001f3ff\u200d\U0001f467\U0001f3ff\u200d\U0001f476\U0001f3ff", "Family - Woman: Dark Skin Tone, Man: Dark Skin Tone, Girl: Dark Skin Tone, Baby: Dark Skin Tone" }, // 1f469-1f3ff-200d-1f468-1f3ff-200d-1f467-1f3ff-200d-1f476-1f3ff
            { "\U0001f469\U0001f3ff\u200d\U0001f468\U0001f3ff\u200d\U0001f467\U0001f3ff\u200d\U0001f467\U0001f3ff", "Family - Woman: Dark Skin Tone, Man: Dark Skin Tone, Girl: Dark Skin Tone, Girl: Dark Skin Tone" }, // 1f469-1f3ff-200d-1f468-1f3ff-200d-1f467-1f3ff-200d-1f467-1f3ff
            { "\U0001f469\U0001f3ff\u200d\U0001f468\U0001f3ff\u200d\U0001f467\U0001f3ff\u200d\U0001f466\U0001f3ff", "Family - Woman: Dark Skin Tone, Man: Dark Skin Tone, Girl: Dark Skin Tone, Boy: Dark Skin Tone" }, // 1f469-1f3ff-200d-1f468-1f3ff-200d-1f467-1f3ff-200d-1f466-1f3ff
            { "\U0001f469\U0001f3ff\u200d\U0001f468\U0001f3ff\u200d\U0001f466\U0001f3ff\u200d\U0001f476\U0001f3ff", "Family - Woman: Dark Skin Tone, Man: Dark Skin Tone, Boy: Dark Skin Tone, Baby: Dark Skin Tone" }, // 1f469-1f3ff-200d-1f468-1f3ff-200d-1f466-1f3ff-200d-1f476-1f3ff
            { "\U0001f469\U0001f3ff\u200d\U0001f468\U0001f3ff\u200d\U0001f466\U0001f3ff\u200d\U0001f467\U0001f3ff", "Family - Woman: Dark Skin Tone, Man: Dark Skin Tone, Boy: Dark Skin Tone, Girl: Dark Skin Tone" }, // 1f469-1f3ff-200d-1f468-1f3ff-200d-1f466-1f3ff-200d-1f467-1f3ff
            { "\U0001f468\U0001f3fe\u200d\U0001f469\U0001f3fe\u200d\U0001f467\U0001f3fe\u200d\U0001f466\U0001f3fe", "Family - Man: Medium-Dark Skin Tone, Woman: Medium-Dark Skin Tone, Girl: Medium-Dark Skin Tone, Boy: Medium-Dark Skin Tone" }, // 1f468-1f3fe-200d-1f469-1f3fe-200d-1f467-1f3fe-200d-1f466-1f3fe
            { "\U0001f469\U0001f3fc\u200d\U0001f468\U0001f3fc\u200d\U0001f476\U0001f3fc\u200d\U0001f476\U0001f3fc", "Family - Woman: Medium-Light Skin Tone, Man: Medium-Light Skin Tone, Baby: Medium-Light Skin Tone, Baby: Medium-Light Skin Tone" }, // 1f469-1f3fc-200d-1f468-1f3fc-200d-1f476-1f3fc-200d-1f476-1f3fc
            { "\U0001f469\U0001f3fc\u200d\U0001f468\U0001f3fc\u200d\U0001f476\U0001f3fc\u200d\U0001f467\U0001f3fc", "Family - Woman: Medium-Light Skin Tone, Man: Medium-Light Skin Tone, Baby: Medium-Light Skin Tone, Girl: Medium-Light Skin Tone" }, // 1f469-1f3fc-200d-1f468-1f3fc-200d-1f476-1f3fc-200d-1f467-1f3fc
            { "\U0001f469\U0001f3fc\u200d\U0001f468\U0001f3fc\u200d\U0001f476\U0001f3fc\u200d\U0001f466\U0001f3fc", "Family - Woman: Medium-Light Skin Tone, Man: Medium-Light Skin Tone, Baby: Medium-Light Skin Tone, Boy: Medium-Light Skin Tone" }, // 1f469-1f3fc-200d-1f468-1f3fc-200d-1f476-1f3fc-200d-1f466-1f3fc
            { "\U0001f469\U0001f3fc\u200d\U0001f468\U0001f3fc\u200d\U0001f467\U0001f3fc\u200d\U0001f476\U0001f3fc", "Family - Woman: Medium-Light Skin Tone, Man: Medium-Light Skin Tone, Girl: Medium-Light Skin Tone, Baby: Medium-Light Skin Tone" }, // 1f469-1f3fc-200d-1f468-1f3fc-200d-1f467-1f3fc-200d-1f476-1f3fc
            { "\U0001f469\U0001f3fc\u200d\U0001f468\U0001f3fc\u200d\U0001f467\U0001f3fc\u200d\U0001f467\U0001f3fc", "Family - Woman: Medium-Light Skin Tone, Man: Medium-Light Skin Tone, Girl: Medium-Light Skin Tone, Girl: Medium-Light Skin Tone" }, // 1f469-1f3fc-200d-1f468-1f3fc-200d-1f467-1f3fc-200d-1f467-1f3fc
            { "\U0001f469\U0001f3fc\u200d\U0001f468\U0001f3fc\u200d\U0001f467\U0001f3fc\u200d\U0001f466\U0001f3fc", "Family - Woman: Medium-Light Skin Tone, Man: Medium-Light Skin Tone, Girl: Medium-Light Skin Tone, Boy: Medium-Light Skin Tone" }, // 1f469-1f3fc-200d-1f468-1f3fc-200d-1f467-1f3fc-200d-1f466-1f3fc
            { "\U0001f469\U0001f3fc\u200d\U0001f468\U0001f3fc\u200d\U0001f466\U0001f3fc\u200d\U0001f476\U0001f3fc", "Family - Woman: Medium-Light Skin Tone, Man: Medium-Light Skin Tone, Boy: Medium-Light Skin Tone, Baby: Medium-Light Skin Tone" }, // 1f469-1f3fc-200d-1f468-1f3fc-200d-1f466-1f3fc-200d-1f476-1f3fc
            { "\U0001f469\U0001f3fc\u200d\U0001f468\U0001f3fc\u200d\U0001f466\U0001f3fc\u200d\U0001f467\U0001f3fc", "Family - Woman: Medium-Light Skin Tone, Man: Medium-Light Skin Tone, Boy: Medium-Light Skin Tone, Girl: Medium-Light Skin Tone" }, // 1f469-1f3fc-200d-1f468-1f3fc-200d-1f466-1f3fc-200d-1f467-1f3fc
            { "\U0001f469\U0001f3fc\u200d\U0001f468\U0001f3fc\u200d\U0001f466\U0001f3fc\u200d\U0001f466\U0001f3fc", "Family - Woman: Medium-Light Skin Tone, Man: Medium-Light Skin Tone, Boy: Medium-Light Skin Tone, Boy: Medium-Light Skin Tone" }, // 1f469-1f3fc-200d-1f468-1f3fc-200d-1f466-1f3fc-200d-1f466-1f3fc
            { "\U0001f469\U0001f3fb\u200d\U0001f469\U0001f3fb\u200d\U0001f476\U0001f3fb\u200d\U0001f476\U0001f3fb", "Family - Woman: Light Skin Tone, Woman: Light Skin Tone, Baby: Light Skin Tone, Baby: Light Skin Tone" }, // 1f469-1f3fb-200d-1f469-1f3fb-200d-1f476-1f3fb-200d-1f476-1f3fb
            { "\U0001f469\U0001f3fd\u200d\U0001f469\U0001f3fd\u200d\U0001f476\U0001f3fd", "Family - Woman: Medium Skin Tone, Woman: Medium Skin Tone, Baby: Medium Skin Tone" }, // 1f469-1f3fd-200d-1f469-1f3fd-200d-1f476-1f3fd
            { "\U0001f469\u200d\U0001f476", "Family: Woman, Baby" }, // 1f469-200d-1f476
            { "\U0001f468\u200d\U0001f476\u200d\U0001f476", "Family: Man, Baby, Baby" }, // 1f468-200d-1f476-200d-1f476
            { "\U0001f468\u200d\U0001f476\u200d\U0001f466", "Family: Man, Baby, Boy" }, // 1f468-200d-1f476-200d-1f466
            { "\U0001f468\u200d\U0001f476\u200d\U0001f467", "Family: Man, Baby, Girl" }, // 1f468-200d-1f476-200d-1f467
            { "\U0001f469\u200d\U0001f476\u200d\U0001f467", "Family: Woman, Baby, Girl" }, // 1f469-200d-1f476-200d-1f467
            { "\U0001f469\u200d\U0001f476\u200d\U0001f466", "Family: Woman, Baby, Boy" }, // 1f469-200d-1f476-200d-1f466
            { "\U0001f469\u200d\U0001f476\u200d\U0001f476", "Family: Woman, Baby, Baby" }, // 1f469-200d-1f476-200d-1f476
            { "\U0001f469\u200d\U0001f466\u200d\U0001f467", "Family: Woman, Boy, Girl" }, // 1f469-200d-1f466-200d-1f467
            { "\U0001f469\U0001f3fc\u200d\u2764\ufe0f\u200d\U0001f469", "Couple With Heart - Woman: Medium-Light Skin Tone, Woman" }, // 1f469-1f3fc-200d-2764-fe0f-200d-1f469
            { "\U0001f469\U0001f3ff\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3ff", "Couple With Heart - Woman: Dark Skin Tone, Woman: Dark Skin Tone" }, // 1f469-1f3ff-200d-2764-fe0f-200d-1f469-1f3ff
            { "\U0001f469\U0001f3fe\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3ff", "Kiss - Woman: Medium-Dark Skin Tone, Man: Dark Skin Tone" }, // 1f469-1f3fe-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3ff
            { "\U0001f468\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3fb", "Kiss - Man, Woman: Light Skin Tone" }, // 1f468-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3fb
            { "\U0001f468\U0001f3ff\u200d\u2764\ufe0f\u200d\U0001f468", "Couple With Heart - Man: Dark Skin Tone, Man" }, // 1f468-1f3ff-200d-2764-fe0f-200d-1f468
            { "\U0001f469\U0001f3fe\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3fd", "Kiss - Woman: Medium-Dark Skin Tone, Man: Medium Skin Tone" }, // 1f469-1f3fe-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3fd
            { "\U0001f469\U0001f3ff\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3fd", "Couple With Heart - Woman: Dark Skin Tone, Woman: Medium Skin Tone" }, // 1f469-1f3ff-200d-2764-fe0f-200d-1f469-1f3fd
            { "\U0001f469\U0001f3fc\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3fb", "Couple With Heart - Woman: Medium-Light Skin Tone, Man: Light Skin Tone" }, // 1f469-1f3fc-200d-2764-fe0f-200d-1f468-1f3fb
            { "\U0001f469\U0001f3fb\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3fc", "Kiss - Woman: Light Skin Tone, Man: Medium-Light Skin Tone" }, // 1f469-1f3fb-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3fc
            { "\U0001f469\u200d\U0001f468\u200d\U0001f476\u200d\U0001f466", "Family: Woman, Man, Baby, Boy" }, // 1f469-200d-1f468-200d-1f476-200d-1f466
            { "\U0001f469\U0001f3fe\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3fe", "Couple With Heart - Woman: Medium-Dark Skin Tone, Man: Medium-Dark Skin Tone" }, // 1f469-1f3fe-200d-2764-fe0f-200d-1f468-1f3fe
            { "\U0001f469\U0001f3ff\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468", "Kiss - Woman: Dark Skin Tone, Man" }, // 1f469-1f3ff-200d-2764-fe0f-200d-1f48b-200d-1f468
            { "\U0001f468\U0001f3fd\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3ff", "Kiss - Man: Medium Skin Tone, Woman: Dark Skin Tone" }, // 1f468-1f3fd-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3ff
            { "\U0001f468\U0001f3ff\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3ff", "Couple With Heart - Man: Dark Skin Tone, Man: Dark Skin Tone" }, // 1f468-1f3ff-200d-2764-fe0f-200d-1f468-1f3ff
            { "\U0001f468\U0001f3ff\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3ff", "Kiss - Man: Dark Skin Tone, Man: Dark Skin Tone" }, // 1f468-1f3ff-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3ff
            { "\U0001f468\U0001f3ff\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3ff", "Couple With Heart - Man: Dark Skin Tone, Woman: Dark Skin Tone" }, // 1f468-1f3ff-200d-2764-fe0f-200d-1f469-1f3ff
            { "\U0001f468\U0001f3ff\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3ff", "Kiss - Man: Dark Skin Tone, Woman: Dark Skin Tone" }, // 1f468-1f3ff-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3ff
            { "\U0001f469\U0001f3fb\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3ff", "Kiss - Woman: Light Skin Tone, Man: Dark Skin Tone" }, // 1f469-1f3fb-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3ff
            { "\U0001f469\U0001f3ff\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469", "Kiss - Woman: Dark Skin Tone, Woman" }, // 1f469-1f3ff-200d-2764-fe0f-200d-1f48b-200d-1f469
            { "\U0001f468\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3ff", "Couple With Heart - Man, Woman: Dark Skin Tone" }, // 1f468-200d-2764-fe0f-200d-1f469-1f3ff
            { "\U0001f469\u200d\U0001f468\u200d\U0001f476\u200d\U0001f467", "Family: Woman, Man, Baby, Girl" }, // 1f469-200d-1f468-200d-1f476-200d-1f467
            { "\U0001f469\U0001f3fc\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3fc", "Couple With Heart - Woman: Medium-Light Skin Tone, Man: Medium-Light Skin Tone" }, // 1f469-1f3fc-200d-2764-fe0f-200d-1f468-1f3fc
            { "\U0001f469\U0001f3fc\u200d\u2764\ufe0f\u200d\U0001f468", "Couple With Heart - Woman: Medium-Light Skin Tone, Man" }, // 1f469-1f3fc-200d-2764-fe0f-200d-1f468
            { "\U0001f469\U0001f3ff\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3ff", "Couple With Heart - Woman: Dark Skin Tone, Man: Dark Skin Tone" }, // 1f469-1f3ff-200d-2764-fe0f-200d-1f468-1f3ff
            { "\U0001f468\U0001f3fc\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3fc", "Couple With Heart - Man: Medium-Light Skin Tone, Man: Medium-Light Skin Tone" }, // 1f468-1f3fc-200d-2764-fe0f-200d-1f468-1f3fc
            { "\U0001f468\U0001f3fe\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3fc", "Couple With Heart - Man: Medium-Dark Skin Tone, Woman: Medium-Light Skin Tone" }, // 1f468-1f3fe-200d-2764-fe0f-200d-1f469-1f3fc
            { "\U0001f468\U0001f3fc\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3fc", "Kiss - Man: Medium-Light Skin Tone, Woman: Medium-Light Skin Tone" }, // 1f468-1f3fc-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3fc
            { "\U0001f469\U0001f3fe\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3fc", "Couple With Heart - Woman: Medium-Dark Skin Tone, Woman: Medium-Light Skin Tone" }, // 1f469-1f3fe-200d-2764-fe0f-200d-1f469-1f3fc
            { "\U0001f469\U0001f3fb\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3fe", "Kiss - Woman: Light Skin Tone, Woman: Medium-Dark Skin Tone" }, // 1f469-1f3fb-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3fe
            { "\U0001f469\U0001f3ff\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3fe", "Couple With Heart - Woman: Dark Skin Tone, Woman: Medium-Dark Skin Tone" }, // 1f469-1f3ff-200d-2764-fe0f-200d-1f469-1f3fe
            { "\U0001f469\U0001f3fe\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3fe", "Kiss - Woman: Medium-Dark Skin Tone, Man: Medium-Dark Skin Tone" }, // 1f469-1f3fe-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3fe
            { "\U0001f468\U0001f3ff\u200d\u2764\ufe0f\u200d\U0001f469", "Couple With Heart - Man: Dark Skin Tone, Woman" }, // 1f468-1f3ff-200d-2764-fe0f-200d-1f469
            { "\U0001f468\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3fc", "Kiss - Man, Woman: Medium-Light Skin Tone" }, // 1f468-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3fc
            { "\U0001f468\U0001f3fc\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3fe", "Couple With Heart - Man: Medium-Light Skin Tone, Woman: Medium-Dark Skin Tone" }, // 1f468-1f3fc-200d-2764-fe0f-200d-1f469-1f3fe
            { "\U0001f468\U0001f3fc\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3fe", "Kiss - Man: Medium-Light Skin Tone, Man: Medium-Dark Skin Tone" }, // 1f468-1f3fc-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3fe
            { "\U0001f468\U0001f3fe\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3fe", "Couple With Heart - Man: Medium-Dark Skin Tone, Man: Medium-Dark Skin Tone" }, // 1f468-1f3fe-200d-2764-fe0f-200d-1f468-1f3fe
            { "\U0001f468\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3fb", "Couple With Heart - Man, Man: Light Skin Tone" }, // 1f468-200d-2764-fe0f-200d-1f468-1f3fb
            { "\U0001f468\u200d\U0001f468\u200d\U0001f467\u200d\U0001f476", "Family: Man, Man, Girl, Baby" }, // 1f468-200d-1f468-200d-1f467-200d-1f476
            { "\U0001f469\U0001f3fb\u200d\u2764\ufe0f\u200d\U0001f468", "Couple With Heart - Woman: Light Skin Tone, Man" }, // 1f469-1f3fb-200d-2764-fe0f-200d-1f468
            { "\U0001f468\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3ff", "Couple With Heart - Man, Man: Dark Skin Tone" }, // 1f468-200d-2764-fe0f-200d-1f468-1f3ff
            { "\U0001f469\U0001f3fe\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468", "Kiss - Woman: Medium-Dark Skin Tone, Man" }, // 1f469-1f3fe-200d-2764-fe0f-200d-1f48b-200d-1f468
            { "\U0001f469\U0001f3fc\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3fc", "Couple With Heart - Woman: Medium-Light Skin Tone, Woman: Medium-Light Skin Tone" }, // 1f469-1f3fc-200d-2764-fe0f-200d-1f469-1f3fc
            { "\U0001f468\U0001f3ff\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3fc", "Couple With Heart - Man: Dark Skin Tone, Man: Medium-Light Skin Tone" }, // 1f468-1f3ff-200d-2764-fe0f-200d-1f468-1f3fc
            { "\U0001f468\U0001f3ff\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3fc", "Kiss - Man: Dark Skin Tone, Man: Medium-Light Skin Tone" }, // 1f468-1f3ff-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3fc
            { "\U0001f469\U0001f3fb\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3fe", "Kiss - Woman: Light Skin Tone, Man: Medium-Dark Skin Tone" }, // 1f469-1f3fb-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3fe
            { "\U0001f468\U0001f3fd\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3fe", "Kiss - Man: Medium Skin Tone, Woman: Medium-Dark Skin Tone" }, // 1f468-1f3fd-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3fe
            { "\U0001f469\U0001f3fe\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3fc", "Couple With Heart - Woman: Medium-Dark Skin Tone, Man: Medium-Light Skin Tone" }, // 1f469-1f3fe-200d-2764-fe0f-200d-1f468-1f3fc
            { "\U0001f469\u200d\U0001f468\u200d\U0001f467\u200d\U0001f476", "Family: Woman, Man, Girl, Baby" }, // 1f469-200d-1f468-200d-1f467-200d-1f476
            { "\U0001f468\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3fd", "Kiss - Man, Man: Medium Skin Tone" }, // 1f468-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3fd
            { "\U0001f469\U0001f3fb\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3fd", "Kiss - Woman: Light Skin Tone, Woman: Medium Skin Tone" }, // 1f469-1f3fb-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3fd
            { "\U0001f469\U0001f3fe\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3fb", "Kiss - Woman: Medium-Dark Skin Tone, Woman: Light Skin Tone" }, // 1f469-1f3fe-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3fb
            { "\U0001f469\U0001f3fe\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3fb", "Couple With Heart - Woman: Medium-Dark Skin Tone, Woman: Light Skin Tone" }, // 1f469-1f3fe-200d-2764-fe0f-200d-1f469-1f3fb
            { "\U0001f469\U0001f3ff\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3fb", "Kiss - Woman: Dark Skin Tone, Woman: Light Skin Tone" }, // 1f469-1f3ff-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3fb
            { "\U0001f469\U0001f3fd\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3fd", "Kiss - Woman: Medium Skin Tone, Man: Medium Skin Tone" }, // 1f469-1f3fd-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3fd
            { "\U0001f468\U0001f3fe\u200d\u2764\ufe0f\u200d\U0001f469", "Couple With Heart - Man: Medium-Dark Skin Tone, Woman" }, // 1f468-1f3fe-200d-2764-fe0f-200d-1f469
            { "\U0001f469\U0001f3ff\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3fb", "Couple With Heart - Woman: Dark Skin Tone, Man: Light Skin Tone" }, // 1f469-1f3ff-200d-2764-fe0f-200d-1f468-1f3fb
            { "\U0001f468\u200d\U0001f468\u200d\U0001f476\u200d\U0001f476", "Family: Man, Man, Baby, Baby" }, // 1f468-200d-1f468-200d-1f476-200d-1f476
            { "\U0001f469\U0001f3fe\u200d\u2764\ufe0f\u200d\U0001f469", "Couple With Heart - Woman: Medium-Dark Skin Tone, Woman" }, // 1f469-1f3fe-200d-2764-fe0f-200d-1f469
            { "\U0001f469\U0001f3fe\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3fd", "Couple With Heart - Woman: Medium-Dark Skin Tone, Man: Medium Skin Tone" }, // 1f469-1f3fe-200d-2764-fe0f-200d-1f468-1f3fd
            { "\U0001f469\U0001f3fb\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3fb", "Kiss - Woman: Light Skin Tone, Man: Light Skin Tone" }, // 1f469-1f3fb-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3fb
            { "\U0001f469\U0001f3fc\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3fd", "Couple With Heart - Woman: Medium-Light Skin Tone, Woman: Medium Skin Tone" }, // 1f469-1f3fc-200d-2764-fe0f-200d-1f469-1f3fd
            { "\U0001f469\U0001f3fe\u200d\u2764\ufe0f\u200d\U0001f468", "Couple With Heart - Woman: Medium-Dark Skin Tone, Man" }, // 1f469-1f3fe-200d-2764-fe0f-200d-1f468
            { "\U0001f468\U0001f3fe\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3fb", "Couple With Heart - Man: Medium-Dark Skin Tone, Woman: Light Skin Tone" }, // 1f468-1f3fe-200d-2764-fe0f-200d-1f469-1f3fb
            { "\U0001f469\U0001f3ff\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3fc", "Couple With Heart - Woman: Dark Skin Tone, Man: Medium-Light Skin Tone" }, // 1f469-1f3ff-200d-2764-fe0f-200d-1f468-1f3fc
            { "\U0001f468\U0001f3fc\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3fb", "Kiss - Man: Medium-Light Skin Tone, Woman: Light Skin Tone" }, // 1f468-1f3fc-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3fb
            { "\U0001f468\U0001f3fe\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3fd", "Kiss - Man: Medium-Dark Skin Tone, Man: Medium Skin Tone" }, // 1f468-1f3fe-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3fd
            { "\U0001f468\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3fc", "Couple With Heart - Man, Woman: Medium-Light Skin Tone" }, // 1f468-200d-2764-fe0f-200d-1f469-1f3fc
            { "\U0001f468\U0001f3ff\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3fb", "Kiss - Man: Dark Skin Tone, Woman: Light Skin Tone" }, // 1f468-1f3ff-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3fb
            { "\U0001f468\U0001f3fd\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3fd", "Kiss - Man: Medium Skin Tone, Man: Medium Skin Tone" }, // 1f468-1f3fd-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3fd
            { "\U0001f468\u200d\U0001f468\u200d\U0001f466\u200d\U0001f476", "Family: Man, Man, Boy, Baby" }, // 1f468-200d-1f468-200d-1f466-200d-1f476
            { "\U0001f469\U0001f3fe\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3fb", "Kiss - Woman: Medium-Dark Skin Tone, Man: Light Skin Tone" }, // 1f469-1f3fe-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3fb
            { "\U0001f468\u200d\U0001f468\u200d\U0001f476\u200d\U0001f467", "Family: Man, Man, Baby, Girl" }, // 1f468-200d-1f468-200d-1f476-200d-1f467
            { "\U0001f468\U0001f3fb\u200d\u2764\ufe0f\u200d\U0001f468", "Couple With Heart - Man: Light Skin Tone, Man" }, // 1f468-1f3fb-200d-2764-fe0f-200d-1f468
            { "\U0001f469\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3ff", "Couple With Heart - Woman, Man: Dark Skin Tone" }, // 1f469-200d-2764-fe0f-200d-1f468-1f3ff
            { "\U0001f468\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3ff", "Kiss - Man, Man: Dark Skin Tone" }, // 1f468-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3ff
            { "\U0001f469\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3fc", "Couple With Heart - Woman, Man: Medium-Light Skin Tone" }, // 1f469-200d-2764-fe0f-200d-1f468-1f3fc
            { "\U0001f469\u200d\U0001f469\u200d\U0001f476", "Family: Woman, Woman, Baby" }, // 1f469-200d-1f469-200d-1f476
            { "\U0001f469\U0001f3fd\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3fb", "Kiss - Woman: Medium Skin Tone, Woman: Light Skin Tone" }, // 1f469-1f3fd-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3fb
            { "\U0001f469\U0001f3ff\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3fe", "Kiss - Woman: Dark Skin Tone, Woman: Medium-Dark Skin Tone" }, // 1f469-1f3ff-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3fe
            { "\U0001f468\U0001f3fe\u200d\u2764\ufe0f\u200d\U0001f468", "Couple With Heart - Man: Medium-Dark Skin Tone, Man" }, // 1f468-1f3fe-200d-2764-fe0f-200d-1f468
            { "\U0001f469\U0001f3fd\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3fe", "Kiss - Woman: Medium Skin Tone, Man: Medium-Dark Skin Tone" }, // 1f469-1f3fd-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3fe
            { "\U0001f469\U0001f3ff\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3fc", "Kiss - Woman: Dark Skin Tone, Woman: Medium-Light Skin Tone" }, // 1f469-1f3ff-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3fc
            { "\U0001f468\U0001f3fb\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3fc", "Kiss - Man: Light Skin Tone, Woman: Medium-Light Skin Tone" }, // 1f468-1f3fb-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3fc
            { "\U0001f468\U0001f3fd\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3fe", "Couple With Heart - Man: Medium Skin Tone, Man: Medium-Dark Skin Tone" }, // 1f468-1f3fd-200d-2764-fe0f-200d-1f468-1f3fe
            { "\U0001f468\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469", "Kiss - Man, Woman" }, // 1f468-200d-2764-fe0f-200d-1f48b-200d-1f469
            { "\U0001f469\u200d\U0001f469\u200d\U0001f476\u200d\U0001f466", "Family: Woman, Woman, Baby, Boy" }, // 1f469-200d-1f469-200d-1f476-200d-1f466
            { "\U0001f468\U0001f3fe\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3fc", "Kiss - Man: Medium-Dark Skin Tone, Man: Medium-Light Skin Tone" }, // 1f468-1f3fe-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3fc
            { "\U0001f468\U0001f3fd\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3fd", "Kiss - Man: Medium Skin Tone, Woman: Medium Skin Tone" }, // 1f468-1f3fd-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3fd
            { "\U0001f468\U0001f3fb\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469", "Kiss - Man: Light Skin Tone, Woman" }, // 1f468-1f3fb-200d-2764-fe0f-200d-1f48b-200d-1f469
            { "\U0001f468\U0001f3ff\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3fb", "Kiss - Man: Dark Skin Tone, Man: Light Skin Tone" }, // 1f468-1f3ff-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3fb
            { "\U0001f468\U0001f3ff\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3fb", "Couple With Heart - Man: Dark Skin Tone, Man: Light Skin Tone" }, // 1f468-1f3ff-200d-2764-fe0f-200d-1f468-1f3fb
            { "\U0001f469\U0001f3fe\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3ff", "Kiss - Woman: Medium-Dark Skin Tone, Woman: Dark Skin Tone" }, // 1f469-1f3fe-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3ff
            { "\U0001f469\U0001f3ff\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3fd", "Kiss - Woman: Dark Skin Tone, Woman: Medium Skin Tone" }, // 1f469-1f3ff-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3fd
            { "\U0001f469\u200d\U0001f468\u200d\U0001f467\u200d\U0001f466", "Family: Woman, Man, Girl, Boy" }, // 1f469-200d-1f468-200d-1f467-200d-1f466
            { "\U0001f469\u200d\U0001f467\u200d\U0001f476", "Family: Woman, Girl, Baby" }, // 1f469-200d-1f467-200d-1f476
            { "\U0001f469\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3fd", "Kiss - Woman, Woman: Medium Skin Tone" }, // 1f469-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3fd
            { "\U0001f468\U0001f3ff\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3fd", "Couple With Heart - Man: Dark Skin Tone, Man: Medium Skin Tone" }, // 1f468-1f3ff-200d-2764-fe0f-200d-1f468-1f3fd
            { "\U0001f468\U0001f3ff\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3fd", "Kiss - Man: Dark Skin Tone, Man: Medium Skin Tone" }, // 1f468-1f3ff-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3fd
            { "\U0001f468\U0001f3fd\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3fb", "Kiss - Man: Medium Skin Tone, Woman: Light Skin Tone" }, // 1f468-1f3fd-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3fb
            { "\U0001f468\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3fe", "Couple With Heart - Man, Man: Medium-Dark Skin Tone" }, // 1f468-200d-2764-fe0f-200d-1f468-1f3fe
            { "\U0001f468\U0001f3fc\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3fb", "Couple With Heart - Man: Medium-Light Skin Tone, Woman: Light Skin Tone" }, // 1f468-1f3fc-200d-2764-fe0f-200d-1f469-1f3fb
            { "\U0001f469\u200d\U0001f468\u200d\U0001f466\u200d\U0001f476", "Family: Woman, Man, Boy, Baby" }, // 1f469-200d-1f468-200d-1f466-200d-1f476
            { "\U0001f468\U0001f3fe\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3fb", "Couple With Heart - Man: Medium-Dark Skin Tone, Man: Light Skin Tone" }, // 1f468-1f3fe-200d-2764-fe0f-200d-1f468-1f3fb
            { "\U0001f469\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3ff", "Kiss - Woman, Man: Dark Skin Tone" }, // 1f469-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3ff
            { "\U0001f468\U0001f3fc\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3fb", "Kiss - Man: Medium-Light Skin Tone, Man: Light Skin Tone" }, // 1f468-1f3fc-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3fb
            { "\U0001f468\U0001f3fc\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468", "Kiss - Man: Medium-Light Skin Tone, Man" }, // 1f468-1f3fc-200d-2764-fe0f-200d-1f48b-200d-1f468
            { "\U0001f469\U0001f3fb\u200d\u2764\ufe0f\u200d\U0001f469", "Couple With Heart - Woman: Light Skin Tone, Woman" }, // 1f469-1f3fb-200d-2764-fe0f-200d-1f469
            { "\U0001f468\U0001f3fb\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3ff", "Couple With Heart - Man: Light Skin Tone, Man: Dark Skin Tone" }, // 1f468-1f3fb-200d-2764-fe0f-200d-1f468-1f3ff
            { "\U0001f468\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3fb", "Kiss - Man, Man: Light Skin Tone" }, // 1f468-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3fb
            { "\U0001f468\u200d\U0001f468\u200d\U0001f466\u200d\U0001f467", "Family: Man, Man, Boy, Girl" }, // 1f468-200d-1f468-200d-1f466-200d-1f467
            { "\U0001f469\U0001f3ff\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3fd", "Couple With Heart - Woman: Dark Skin Tone, Man: Medium Skin Tone" }, // 1f469-1f3ff-200d-2764-fe0f-200d-1f468-1f3fd
            { "\U0001f469\U0001f3fc\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469", "Kiss - Woman: Medium-Light Skin Tone, Woman" }, // 1f469-1f3fc-200d-2764-fe0f-200d-1f48b-200d-1f469
            { "\U0001f469\U0001f3fe\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3fd", "Kiss - Woman: Medium-Dark Skin Tone, Woman: Medium Skin Tone" }, // 1f469-1f3fe-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3fd
            { "\U0001f469\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3fb", "Couple With Heart - Woman, Woman: Light Skin Tone" }, // 1f469-200d-2764-fe0f-200d-1f469-1f3fb
            { "\U0001f469\U0001f3fc\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3fb", "Couple With Heart - Woman: Medium-Light Skin Tone, Woman: Light Skin Tone" }, // 1f469-1f3fc-200d-2764-fe0f-200d-1f469-1f3fb
            { "\U0001f469\U0001f3fe\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3fb", "Couple With Heart - Woman: Medium-Dark Skin Tone, Man: Light Skin Tone" }, // 1f469-1f3fe-200d-2764-fe0f-200d-1f468-1f3fb
            { "\U0001f469\u200d\U0001f468\u200d\U0001f476", "Family: Woman, Man, Baby" }, // 1f469-200d-1f468-200d-1f476
            { "\U0001f469\U0001f3fb\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3fd", "Kiss - Woman: Light Skin Tone, Man: Medium Skin Tone" }, // 1f469-1f3fb-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3fd
            { "\U0001f469\u200d\U0001f469\u200d\U0001f476\u200d\U0001f467", "Family: Woman, Woman, Baby, Girl" }, // 1f469-200d-1f469-200d-1f476-200d-1f467
            { "\U0001f468\U0001f3fd\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3fd", "Couple With Heart - Man: Medium Skin Tone, Man: Medium Skin Tone" }, // 1f468-1f3fd-200d-2764-fe0f-200d-1f468-1f3fd
            { "\U0001f468\U0001f3fb\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3fb", "Kiss - Man: Light Skin Tone, Woman: Light Skin Tone" }, // 1f468-1f3fb-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3fb
            { "\U0001f469\U0001f3fe\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3fe", "Kiss - Woman: Medium-Dark Skin Tone, Woman: Medium-Dark Skin Tone" }, // 1f469-1f3fe-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3fe
            { "\U0001f468\U0001f3fb\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3fd", "Couple With Heart - Man: Light Skin Tone, Woman: Medium Skin Tone" }, // 1f468-1f3fb-200d-2764-fe0f-200d-1f469-1f3fd
            { "\U0001f469\U0001f3ff\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3fe", "Couple With Heart - Woman: Dark Skin Tone, Man: Medium-Dark Skin Tone" }, // 1f469-1f3ff-200d-2764-fe0f-200d-1f468-1f3fe
            { "\U0001f468\U0001f3fe\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3ff", "Kiss - Man: Medium-Dark Skin Tone, Woman: Dark Skin Tone" }, // 1f468-1f3fe-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3ff
            { "\U0001f468\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3fc", "Kiss - Man, Man: Medium-Light Skin Tone" }, // 1f468-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3fc
            { "\U0001f469\U0001f3fb\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3fc", "Couple With Heart - Woman: Light Skin Tone, Man: Medium-Light Skin Tone" }, // 1f469-1f3fb-200d-2764-fe0f-200d-1f468-1f3fc
            { "\U0001f469\U0001f3fd\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3fc", "Couple With Heart - Woman: Medium Skin Tone, Woman: Medium-Light Skin Tone" }, // 1f469-1f3fd-200d-2764-fe0f-200d-1f469-1f3fc
            { "\U0001f469\U0001f3fc\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3fc", "Kiss - Woman: Medium-Light Skin Tone, Man: Medium-Light Skin Tone" }, // 1f469-1f3fc-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3fc
            { "\U0001f469\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3fe", "Kiss - Woman, Man: Medium-Dark Skin Tone" }, // 1f469-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3fe
            { "\U0001f468\U0001f3fe\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3fb", "Kiss - Man: Medium-Dark Skin Tone, Woman: Light Skin Tone" }, // 1f468-1f3fe-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3fb
            { "\U0001f468\U0001f3fb\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3fd", "Couple With Heart - Man: Light Skin Tone, Man: Medium Skin Tone" }, // 1f468-1f3fb-200d-2764-fe0f-200d-1f468-1f3fd
            { "\U0001f468\U0001f3fc\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469", "Kiss - Man: Medium-Light Skin Tone, Woman" }, // 1f468-1f3fc-200d-2764-fe0f-200d-1f48b-200d-1f469
            { "\U0001f468\U0001f3fd\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3fd", "Couple With Heart - Man: Medium Skin Tone, Woman: Medium Skin Tone" }, // 1f468-1f3fd-200d-2764-fe0f-200d-1f469-1f3fd
            { "\U0001f468\U0001f3fb\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3fb", "Kiss - Man: Light Skin Tone, Man: Light Skin Tone" }, // 1f468-1f3fb-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3fb
            { "\U0001f469\U0001f3fc\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3ff", "Kiss - Woman: Medium-Light Skin Tone, Man: Dark Skin Tone" }, // 1f469-1f3fc-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3ff
            { "\U0001f469\U0001f3fd\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3ff", "Couple With Heart - Woman: Medium Skin Tone, Woman: Dark Skin Tone" }, // 1f469-1f3fd-200d-2764-fe0f-200d-1f469-1f3ff
            { "\U0001f469\U0001f3fb\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3ff", "Couple With Heart - Woman: Light Skin Tone, Man: Dark Skin Tone" }, // 1f469-1f3fb-200d-2764-fe0f-200d-1f468-1f3ff
            { "\U0001f468\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3fc", "Couple With Heart - Man, Man: Medium-Light Skin Tone" }, // 1f468-200d-2764-fe0f-200d-1f468-1f3fc
            { "\U0001f468\U0001f3fe\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3fd", "Couple With Heart - Man: Medium-Dark Skin Tone, Man: Medium Skin Tone" }, // 1f468-1f3fe-200d-2764-fe0f-200d-1f468-1f3fd
            { "\U0001f468\U0001f3fc\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3fd", "Kiss - Man: Medium-Light Skin Tone, Man: Medium Skin Tone" }, // 1f468-1f3fc-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3fd
            { "\U0001f469\U0001f3fd\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3ff", "Kiss - Woman: Medium Skin Tone, Woman: Dark Skin Tone" }, // 1f469-1f3fd-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3ff
            { "\U0001f468\U0001f3fc\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3fd", "Couple With Heart - Man: Medium-Light Skin Tone, Woman: Medium Skin Tone" }, // 1f468-1f3fc-200d-2764-fe0f-200d-1f469-1f3fd
            { "\U0001f468\U0001f3fc\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3ff", "Couple With Heart - Man: Medium-Light Skin Tone, Woman: Dark Skin Tone" }, // 1f468-1f3fc-200d-2764-fe0f-200d-1f469-1f3ff
            { "\U0001f469\u200d\U0001f466\u200d\U0001f476", "Family: Woman, Boy, Baby" }, // 1f469-200d-1f466-200d-1f476
            { "\U0001f469\U0001f3fd\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3ff", "Kiss - Woman: Medium Skin Tone, Man: Dark Skin Tone" }, // 1f469-1f3fd-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3ff
            { "\U0001f469\u200d\U0001f468\u200d\U0001f466\u200d\U0001f466", "Family: Woman, Man, Boy, Boy" }, // 1f469-200d-1f468-200d-1f466-200d-1f466
            { "\U0001f468\U0001f3fc\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3ff", "Kiss - Man: Medium-Light Skin Tone, Man: Dark Skin Tone" }, // 1f468-1f3fc-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3ff
            { "\U0001f468\U0001f3fe\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3ff", "Couple With Heart - Man: Medium-Dark Skin Tone, Man: Dark Skin Tone" }, // 1f468-1f3fe-200d-2764-fe0f-200d-1f468-1f3ff
            { "\U0001f469\U0001f3fe\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3fc", "Kiss - Woman: Medium-Dark Skin Tone, Woman: Medium-Light Skin Tone" }, // 1f469-1f3fe-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3fc
            { "\U0001f469\U0001f3fe\u200d\U0001f468\U0001f3fe\u200d\U0001f467\U0001f3fe\u200d\U0001f476\U0001f3fe", "Family - Woman: Medium-Dark Skin Tone, Man: Medium-Dark Skin Tone, Girl: Medium-Dark Skin Tone, Baby: Medium-Dark Skin Tone" }, // 1f469-1f3fe-200d-1f468-1f3fe-200d-1f467-1f3fe-200d-1f476-1f3fe
            { "\U0001f468\U0001f3ff\u200d\U0001f476\U0001f3ff", "Family - Man: Dark Skin Tone, Baby: Dark Skin Tone" }, // 1f468-1f3ff-200d-1f476-1f3ff
            { "\U0001f469\U0001f3fb\u200d\U0001f466\U0001f3fb", "Family - Woman: Light Skin Tone, Boy: Light Skin Tone" }, // 1f469-1f3fb-200d-1f466-1f3fb
            { "\U0001f469\U0001f3fb\u200d\U0001f467\U0001f3fb", "Family - Woman: Light Skin Tone, Girl: Light Skin Tone" }, // 1f469-1f3fb-200d-1f467-1f3fb
            { "\U0001f469\U0001f3fb\u200d\U0001f476\U0001f3fb", "Family - Woman: Light Skin Tone, Baby: Light Skin Tone" }, // 1f469-1f3fb-200d-1f476-1f3fb
            { "\U0001f469\U0001f3ff\u200d\U0001f476\U0001f3ff", "Family - Woman: Dark Skin Tone, Baby: Dark Skin Tone" }, // 1f469-1f3ff-200d-1f476-1f3ff
            { "\U0001f468\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3fe", "Kiss - Man, Man: Medium-Dark Skin Tone" }, // 1f468-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3fe
            { "\U0001f469\u200d\U0001f468\u200d\U0001f466\u200d\U0001f467", "Family: Woman, Man, Boy, Girl" }, // 1f469-200d-1f468-200d-1f466-200d-1f467
            { "\U0001f469\U0001f3fe\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469", "Kiss - Woman: Medium-Dark Skin Tone, Woman" }, // 1f469-1f3fe-200d-2764-fe0f-200d-1f48b-200d-1f469
            { "\U0001f468\U0001f3fc\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3fc", "Kiss - Man: Medium-Light Skin Tone, Man: Medium-Light Skin Tone" }, // 1f468-1f3fc-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3fc
            { "\U0001f468\U0001f3fe\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3fc", "Couple With Heart - Man: Medium-Dark Skin Tone, Man: Medium-Light Skin Tone" }, // 1f468-1f3fe-200d-2764-fe0f-200d-1f468-1f3fc
            { "\U0001f468\U0001f3fc\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3fc", "Couple With Heart - Man: Medium-Light Skin Tone, Woman: Medium-Light Skin Tone" }, // 1f468-1f3fc-200d-2764-fe0f-200d-1f469-1f3fc
            { "\U0001f468\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3fd", "Couple With Heart - Man, Man: Medium Skin Tone" }, // 1f468-200d-2764-fe0f-200d-1f468-1f3fd
            { "\U0001f468\U0001f3fd\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f469\U0001f3fc", "Kiss - Man: Medium Skin Tone, Woman: Medium-Light Skin Tone" }, // 1f468-1f3fd-200d-2764-fe0f-200d-1f48b-200d-1f469-1f3fc
            { "\U0001f468\U0001f3ff\u200d\u2764\ufe0f\u200d\U0001f48b\u200d\U0001f468\U0001f3fe", "Kiss - Man: Dark Skin Tone, Man: Medium-Dark Skin Tone" }, // 1f468-1f3ff-200d-2764-fe0f-200d-1f48b-200d-1f468-1f3fe
            { "\U0001f468\U0001f3ff\u200d\u2764\ufe0f\u200d\U0001f468\U0001f3fe", "Couple With Heart - Man: Dark Skin Tone, Man: Medium-Dark Skin Tone" }, // 1f468-1f3ff-200d-2764-fe0f-200d-1f468-1f3fe
            { "\U0001f468\u200d\u2764\ufe0f\u200d\U0001f469\U0001f3fd", "Couple With Heart - Man, Woman: Medium Skin Tone" }, // 1f468-200d-2764-fe0f-200d-1f469-1f3fd
            { "\U0001f469\u200d\U0001f468\u200d\U0001f467\u200d\U0001f467", "Family: Woman, Man, Girl, Girl" }, // 1f469-200d-1f468-200d-1f467-200d-1f467

        };
    }
}

