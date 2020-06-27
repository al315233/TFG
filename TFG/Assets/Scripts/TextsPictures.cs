using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextsPictures : MonoBehaviour
{
    public Base controller;

    string[] annM = new string[3]; //El número se refiere al número de strings que aparecerán. Los cuales están almacenados en un array
    string[] KatieB = new string[3];
    string[] KatieBB = new string[10];
    string[] AnnMB = new string[8];
    string[] WACB = new string[3];
    string[] maryJ = new string[4];
    string[] katherineJ = new string[2];
    string[] dorothyB = new string[3];



    // Start is called before the first frame update
    void Start()
    {
        sentencesOfAnnM();
        sentencesOfKatieB();
        katieBBiography(); //Función de la biografía de Katie
        AnnMBiography();
        WACBiography();
        sentencesOfMaryJ();
        sentencesOfKatherineJ();
        sentencesOfDorothyB();


        controller.texts.Add(annM); //Añade a la lista el array de strings que tienen que ver con  la foto de AnnM
        controller.texts.Add(KatieB);
        controller.texts.Add(KatieBB); //Añade a la lista el array de strings que tienen que ver con la biografía de KatieB
        controller.texts.Add(AnnMB);

        controller.texts.Add(WACB);
        controller.texts.Add(maryJ);
        controller.texts.Add(katherineJ);
        controller.texts.Add(dorothyB);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void sentencesOfAnnM()
    {
        annM[0] = "Ann Masokinski.";
        annM[1] = "She is both an inventor and an artist.";
        annM[2] = "Why is she famous for? She creaed the Hollow Flashlight. This device works with body heat, so it didn’t need any type of electricity.";
    }

    void sentencesOfKatieB()
    {
        KatieB[0] = "Katie Bouman.";
        KatieB[1] = "Why is she famous for? She developed an algorithm that made possible the first picture visualization of a black hole using the Event Horizon Telescope.";
        KatieB[2] = "Press 'Q' to play the Katie Bouman minigame";
    }

    void katieBBiography()
    {
        KatieBB[0] = "This is Katie Bouman. Katie is an imaging scientist. She was born in Indiana, United States in 1989. She was interested in science from a very young age, she did imaging research with Purdue University professors while at high school.";
        KatieBB[1] = "She then enrolled at the University of Michigan and graduated summa cum laude from Michigan with a Bachelor’s degree in electrical engineering.";
        KatieBB[2] = "Her master’s thesis, Estimating Material Properties of Fabric through the Observation of Motion, was rewarded with a prestigious award for the best Master’s Thesis in electrical engineering.";
        KatieBB[3] = "She also completed her doctorate from the Massachusetts Institute of Technology in 2017.";
        KatieBB[4] = "Her Ph.D. dissertation, Extreme imaging via physical model inversion: seeing around corners and imaging black holes, was supervised by a prestigious doctor of Electrical Engineering and Computer Science.";
        KatieBB[5] = "After earning her doctorate, Bouman joined Harvard University as a postdoctoral fellow on the Event Horizon Telescope Imaging team. She led the development of an algorithm for imaging black holes.";
        KatieBB[6] = "The first images of a black hole were published on 10 april 2019.";
        KatieBB[7] = "Bouman played a significant role in the project by verifying images, selecting parameters for filtering images taken by the Event Horizon Telescope,";
        KatieBB[8] = "and participating in the development of a robust imaging framework that compared the results of different image reconstruction techniques.";
        KatieBB[9] = "She joined the California Institute of Technology as an assistant professor in June 2019, where she plans to work on new systems for computational imaging using computer vision and machine learning.";
    }

    void AnnMBiography()
    {
        AnnMB[0] = "This is Ann Masokinski. Ann was born in Canada the 3rd of October 1997. Her mother is from Philippines and her father is from Poland. She is both an inventor and an artist.";
        AnnMB[1] = "When she was 15, during her frequent visits to her mother's homeland in the Philippines, she saw her friends failing at high school because they didn't have enough light to study at night, so she invented a flashlight that works only with body heat.";
        AnnMB[2] = "This device was called Hollow Flashlight.";
        AnnMB[3] = "The flashlight’s technology comes from the Peltier-Seebeck effect, which makes possible the creation of electricity from the difference of temperature between two surfaces.";
        AnnMB[4] = "The Hollow Flashlight allowed her to stand out in the Google Science Fair, as well as  in the Intel International Science and Engineering Fair.";
        AnnMB[5] = "She also invented a mug that uses the excess temperature to charge phones and music devices. This project was named e-Drink.";
        AnnMB[6] = "Ann confessed that all her inventions wouldn’t have been possible if she didn’t mix her science passion with her art skills. Now she is working in a new version of her flashlight while also taking care of her english literature studies at British Columbia University.";
        AnnMB[7] = "She confessed that, for her, science is as important as art. She studies arts at university, but, when she gets home, she works in her science projects.";
    }

    void WACBiography()
    {
        WACB[0] = "From left to right, Dorothy Vaughan, Katherine Johnson, Mary Jackson.";
        WACB[1] = "Why are they famous for? They were the first black mathematician women that worked for the NASA";
        WACB[2] = "The West Computers were an exclusive group of African American female mathematicians who worked for NACA(who will turn NASA) between the years 1943 and 1958. Their job was as human computers.";
    }

    void sentencesOfMaryJ()
    {
        maryJ[0] = "Mary Jackson was an aerospace engineer and a mathematician. She worked in the segregated West Area Computing Section under Dorothy Vaughan.";
        maryJ[1] = "Facing the opportunity to work in the Supersonic Pressure Tunnel, Mary volunteered. This invention was used to study forces on a model by generating winds at almost twice the speed of sound.";
        maryJ[2] = "The director of the project encouraged her to train so she could become an engineer. There was an offer in a night program by the University of Virginia, but she was a black woman so she had to make a request to the City of Hampton to allow her to attend the classes.";
        maryJ[3] = "She became NASA’s first black female engineer.";
    }

    void sentencesOfKatherineJ()
    {
        katherineJ[0] = "Katherine Johnson worked as a computer assigned to the West Area Computer section supervised by Dorothy Vaughan, and then reassigned to the Guidance and Control Division of Langley’s Flight Research Division(for spatial flights).";
        katherineJ[1] = "She calculated a lot of space flights, even John Glenn, the astronaut of the Friendship 7 flight, asked for her specifically and refused to fly until Katherine verified the calculations.";
    }

    void sentencesOfDorothyB()
    {
        dorothyB[0] = "She worked, with other black women, at The West Area Computers section for the NASA, but, when the NASA bought the first IBM computer, she learned the programming language(Fortran) the computers used to apply it to the spacial travels";
        dorothyB[1] = "Before this the IBM computer was used exclusively to business.";
        dorothyB[2] = "After this she taught how to use it to her corworkers.";
    }
}


/*

“Combining art and science is very important to me. I try to live like this: I study arts and then, at home, I work in my science projects”, she said.

*/