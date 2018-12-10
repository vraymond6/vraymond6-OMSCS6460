using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelManager : MonoBehaviour
{
    public Text text;
    public GameObject canvas;
    public GameObject button;
    public Camera main;

    private VerificationManager vManager;
    private UnlockManager uManager;
    private NodeManager nManager;

    private List<Text> current_text;
    private List<Text> lesson_text;

    private int index;
	// Use this for initialization
	void Start ()
    {
        index = 0;

        vManager = GameObject.Find("Manager").GetComponent<VerificationManager>();
        uManager = GameObject.Find("Manager").GetComponent<UnlockManager>();
        nManager = GameObject.Find("Manager").GetComponent<NodeManager>();

        current_text = new List<Text>();
        lesson_text = new List<Text>();

        LoadLevel(0);
	}

    void Update()
    {
        if(lesson_text.Count > 0)
        {
            if (Input.GetKeyDown("right") && index < lesson_text.Count-1)
            {
                nManager.ClearNodes();
                lesson_text[index].transform.localScale = new Vector3(0, 0, 0);
                index++;
                lesson_text[index].transform.localScale = new Vector3(1, 1, 1);

                if(lesson_text[index].text.Contains("Challenge"))
                {
                    lesson_text[index].transform.localScale = new Vector3(0, 0, 0);
                    vManager.CreateChallenge(lesson_text[index].text.Split(' ')[1]);
                }
                else if(lesson_text[index].text.Contains("Unlock"))
                {
                    lesson_text[index].transform.localScale = new Vector3(0, 0, 0);
                    uManager.Unlock(lesson_text[index].text.Substring(8));
                    index--;
                    lesson_text[index].transform.localScale = new Vector3(1, 1, 1);
                }
            }
            else if (Input.GetKeyDown("left") && index > 0)
            {
                nManager.ClearNodes();
                lesson_text[index].transform.localScale = new Vector3(0, 0, 0);
                index--;
                lesson_text[index].transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }
    public void LoadLevel(int level)
    {
        index = 0;
        RemoveText();
        nManager.ClearNodes();
        string input = "";
        if(level == 0)
        {
            input = "Welcome to Circuit Tree! This program is meant to be used as a learning tool for Digital Logic and Computer Architecture. In other words, you will be learning how a computer works at the most basic level! Use the right and left arrow keys to jump between slides.";
            lesson_text.Add(CreateText(input));

            input = "The game is divided into three chapters which each contain multiple lessons and challenges. To begin select the first lesson in the first chapter.";
            lesson_text.Add(CreateText(input));
        }
        else if(level == 1)
        {
            input = "The first topic we will cover is Logic Gates. Logic Gates are the most basic logical component of a computer. They consist of three main parts: 1.Inputs 2.Logic 3.Outputs.";
            lesson_text.Add(CreateText(input));
            input = "Inputs are electronic signals that are connected to the logic gate. They are usually represented as 1s and 0s. A 1 means that a high voltage signal is being sent, while 0 means no voltage/low voltage is being sent.";
            lesson_text.Add(CreateText(input));
            input = "The logic gate then performs a basic operation on the inputs and sends more electronic signals as outputs. The output of one gate can be connected to the inputs of another to create complex circuits such as a computer's CPU";
            lesson_text.Add(CreateText(input));
            input = "Select the next lesson to learn about Truth Tables and how we represent Logic Gates.";
            lesson_text.Add(CreateText(input));
            input = "Unlock: Truth Tables";
            lesson_text.Add(CreateText(input));

        }
        else if (level == 2)
        {
            input = "In the last lesson, we learned about the basics of Logic Gates. We can represent Logic Gates with Truth Tables.";
            lesson_text.Add(CreateText(input));
            input = "Truth Tables are tables showing all possible permutations for a logic gate. In the next slide we will look at the Truth Table for the Nand Gate where X and Y represent the two inputs and O represents the output. ";
            lesson_text.Add(CreateText(input));
            input = "Nand Gate\n X | Y | O \n--------------\n0 | 0 | 1\n0 | 1 | 1\n1 | 0 | 1\n1 | 1 | 0";
            lesson_text.Add(CreateText(input));
            input = "The Nand Gate outputs a high electric signal in all cases except when it has two high input signals.";
            lesson_text.Add(CreateText(input));
            input = "In the next lesson, we will expolore the Nand Gate furthur.";
            lesson_text.Add(CreateText(input));
            input = "Unlock: Nand Gate";
            lesson_text.Add(CreateText(input));
        }
        else if (level == 3)
        {
            input = "For our curriculum, the Nand Gate, or the Not-And Gate, is the most fundamental Logic Gate. It can be used to create all of the remaining logic gates and circuits.";
            lesson_text.Add(CreateText(input));
            input = "This is also commonly true in the real world, as the Nand Gate is one of the cheapest to produce.";
            lesson_text.Add(CreateText(input));
            input = "To create a Nand Gate, select Basic under the Create menu and then select Nand. This same process will be used for the other basic gates in this chapter.";
            lesson_text.Add(CreateText(input));
            input = "Right now the Nand Gate is the only Logic Gate that you can create, but as you proceed through the lessons, you will be able to create more.  ";
            lesson_text.Add(CreateText(input));
            input = "Select the next lesson to begin the first challenge and create the And Gate.";
            lesson_text.Add(CreateText(input));
            input = "Unlock: And Gate";
            lesson_text.Add(CreateText(input));
        }
        else if (level == 4)
        {
            input = "The And Gate is the first gate that we will create. It is the opisite of the Nand Gate and will output a high signal when it has two high inputs.";
            lesson_text.Add(CreateText(input));

            input = "And Gate\n X | Y | O \n--------------\n0 | 0 | 0\n0 | 1 | 0\n1 | 0 | 0\n1 | 1 | 1";
            lesson_text.Add(CreateText(input));

            input = "Challenge: And";
            lesson_text.Add(CreateText(input));

        }
        else if (level == 5)
        {
            input = "The Not Gate is the next gate on the list. Unlike the Nand and And gates, it only has one input. It takes in one input electronic signal and outputs the opossite.";
            lesson_text.Add(CreateText(input));

            input = "For example, if the input is 0, the output will be 1.";
            lesson_text.Add(CreateText(input));

            input = "Not Gate\n X | O \n--------------\n0 | 1\n1 | 0";
            lesson_text.Add(CreateText(input));

            input = "Challenge: Not";
            lesson_text.Add(CreateText(input));
           
        }
        else if (level == 6)
        {
            input = "The Or Gate is different from the logic gates that we have looked at so far. The And Gate and Nand Gate both change their output when the inputs are the same value.";
            lesson_text.Add(CreateText(input));

            input = "The Or Gate outputs a high value when at least one inputs are high. Thats why its called the \"Or\" gate! ";
            lesson_text.Add(CreateText(input));

            input = "Or Gate\n X | Y | O \n--------------\n0 | 0 | 0\n0 | 1 | 1\n1 | 0 | 1\n1 | 1 | 1";
            lesson_text.Add(CreateText(input));

            input = "Challenge: Or";
            lesson_text.Add(CreateText(input));
        }
        else if (level == 7)
        {
            input = "Much like the Nand Gate is the opposite of the And gate, the Nor Gate is the opposite of the Or gate.";
            lesson_text.Add(CreateText(input));

            input = "The Or Gate outputs a high value when at least one inputs are high. Thats why its called the \"Or\" gate! ";
            lesson_text.Add(CreateText(input));

            input = "Nor Gate\n X | Y | O \n--------------\n0 | 0 | 1\n0 | 1 | 0\n1 | 0 | 0\n1 | 1 | 0";
            lesson_text.Add(CreateText(input));

            input = "Challenge: Nor";
            lesson_text.Add(CreateText(input));
        }
        else if (level == 8)
        {
            input = "The Xor Gate is the final basic logic gate that we will build in this section. The Xor Gate, or Exclusive-Or Gate is a special case of the Or gate.";
            lesson_text.Add(CreateText(input));

            input = "The Xor Gate outputs a high value only when exactly one input is high. Unlike the Or gate, if both inputs are high, the output is low.";
            lesson_text.Add(CreateText(input));

            input = "Xor Gate\n X | Y | O \n--------------\n0 | 0 | 0\n0 | 1 | 1\n1 | 0 | 1\n1 | 1 | 0";
            lesson_text.Add(CreateText(input));

            input = "Challenge: Xor";
            lesson_text.Add(CreateText(input));
        }
        else if (level == 9)
        {
            input = "Congratulations on completing the first chapter. Now you have a tool set of logic gates that you can use to build more complex circuits.";
            lesson_text.Add(CreateText(input));

            input = "This type of circuit is called a Combinational Circuit because it is contains more than one logic gate.";
            lesson_text.Add(CreateText(input));

            input = "Additionally, a combinational circuit's output only relies on its input. Therefore it is like the logic gates that we have looked at so far, its output will always be the same no matter the state its in.";
            lesson_text.Add(CreateText(input));

            input = "Before we begin building combinational circuits, we must first learn about the binary number system. Continue to the next lesson to learn more.";
            lesson_text.Add(CreateText(input));

            input = "Unlock: Binary";
            lesson_text.Add(CreateText(input));
        }
        else if (level == 10)
        {
            input = "Binary is the number system of computers. When you hear people refer to computers as \"1s and 0s\" binary is what they are reffering to.";
            lesson_text.Add(CreateText(input));

            input = "In the binary number system, there are only two digits: 0 and 1. This is different from our base 10 number system which has 10 digits 0-9.";
            lesson_text.Add(CreateText(input));

            input = "Counting in binary, 1 is 00000001, 2 is 00000010, and three is 00000011.";
            lesson_text.Add(CreateText(input));

            input = "You may notice that we included 8 place values in out binary numbers. Each of these place values is a bit and 8 bits together is a byte. You may have heard the term byte before when referring to computer memory size.";
            lesson_text.Add(CreateText(input));

            input = "1, 2, 4, and 8 bytes are commonly used when doing math with binary numbers and is used by computers for this same purpose.";
            lesson_text.Add(CreateText(input));

            input = "Unlock: Binary Math";
            lesson_text.Add(CreateText(input));
        }
        else if (level == 11)
        {
            input = "We can do math with binary numbers much like we can with base 10 numbers. We will start by adding two binary numbers. In a later lesson, you will build a circuit which follows the same process.";
            lesson_text.Add(CreateText(input));

            input = "First lets look at how we add two base 10 numbers. We will add 16 and 35. \n-----\n 16\n+35\n-----\n 51\n To add these numbers we start on the right side with the ones place. Since 5+6 is greater than the number of digits that we have to work with we must carry a 1 over to the tens place.";
            lesson_text.Add(CreateText(input));

            input = "Now lets look at this same operation in binary. 16 is 00010000 and 35 is 00100011.\n-------------\n 00010000\n+00100011\n-------------\n 00110011\n We do the same process in binary, just with two digits instead of 10.";
            lesson_text.Add(CreateText(input));

            input = "Now with that behind us, we will build our first Combinational Circuit, the MUX Gate.";
            lesson_text.Add(CreateText(input));


            input = "Unlock: MUX";
            lesson_text.Add(CreateText(input));
        }
        if (lesson_text.Count > 0)
        {
            lesson_text[0].transform.localScale = new Vector3(1, 1, 1);
        }
    }
    public Text CreateText(string input)
    {
        Text output = Instantiate(text, new Vector3(0, 0, 0), Quaternion.identity);
        output.transform.localScale = new Vector3(0, 0, 0);
        output.transform.SetParent(canvas.transform, false);
        output.alignment = TextAnchor.MiddleCenter;
        output.fontSize = 24;
        output.text = input;

        current_text.Add(output);
        return output;
    }
    public void RemoveText()
    {
        for(int x=0;x<current_text.Count;x++)
        {
            Destroy(current_text[x].gameObject);
        }
        current_text.Clear();

        for(int x=0;x<lesson_text.Count;x++)
        {
            Destroy(lesson_text[x].gameObject);
        }
        lesson_text.Clear();
    }

}
