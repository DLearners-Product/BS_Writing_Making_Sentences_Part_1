using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class EnablerCmtsDB
{
    public string welcome;
    public string brain_gym_the_owl;
    public string introduction_revision_of_phrases;
    public string introduction_to_sentences;
    public string activity1;
    public string brain_gym_airplane_pose;
    public string activity2;
    public string lb_activity1;
    public string goodbye;

    public EnablerCmtsDB()
    {
        welcome = Main_Blended.OBJ_main_blended.enablerComments[0];
        brain_gym_the_owl = Main_Blended.OBJ_main_blended.enablerComments[1];
        introduction_revision_of_phrases = Main_Blended.OBJ_main_blended.enablerComments[2];
        introduction_to_sentences = Main_Blended.OBJ_main_blended.enablerComments[3];
        activity1 = Main_Blended.OBJ_main_blended.enablerComments[4];
        brain_gym_airplane_pose = Main_Blended.OBJ_main_blended.enablerComments[5];
        activity2 = Main_Blended.OBJ_main_blended.enablerComments[6];
        lb_activity1 = Main_Blended.OBJ_main_blended.enablerComments[7];
        goodbye = Main_Blended.OBJ_main_blended.enablerComments[8];
    }
}