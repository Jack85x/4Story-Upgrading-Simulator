namespace _4Story_Upgrading_Simulator
{
    public partial class Form1 : Form
    {
        int upgrade = 0;
        int pozioneFelicitaX2 = 200;
        int pozioneFelicitaX25 = 250;
        int pozioneFelicitaX3 = 300;
        int pergamenaMaestroVal = 3;
        int pergamenaRiflessioneVal = 1;
        int upgradeMAX = 24;
        bool tintura = false;
        int pergameneMaestro = 250;
        int tinture = 50;
        int pozionix2 = 250;
        int pozionix25 = 20;
        int pozionix3 = 10;
        int riflessioni = 250;
        int pozioneUsata = 1;
        int pergamenaUsata = 0;
        bool ready = true;
        int pozioniUtilizzate = 0;
        int pozionix25Utilizzate = 0;
        int pozionix3Utilizzate = 0;
        int pergameneMaestroUtilizzate = 0;
        int tintureUtilizzate = 0;
        int riflessioniUtilizzate = 0;
        int balestra = 0;
        int verga = 0;
        int soldi = 0;
        bool result = false;
        int version = 0;

        System.Media.SoundPlayer cash = new System.Media.SoundPlayer(Directory.GetCurrentDirectory() + @"\sounds\cash.wav");
        System.Media.SoundPlayer loading = new System.Media.SoundPlayer(Directory.GetCurrentDirectory() + @"\sounds\loading.wav");
        System.Media.SoundPlayer up = new System.Media.SoundPlayer(Directory.GetCurrentDirectory() + @"\sounds\up.wav");
        System.Media.SoundPlayer fail = new System.Media.SoundPlayer(Directory.GetCurrentDirectory() + @"\sounds\fail.wav");
        System.Media.SoundPlayer select = new System.Media.SoundPlayer(Directory.GetCurrentDirectory() + @"\sounds\select.wav");

        public Form1()
        {
            InitializeComponent();
            label15.Text = upgrade.ToString();
            label10.Text = tinture.ToString();
            label11.Text = pozionix2.ToString();
            label15.Text = pergameneMaestro.ToString();
            label12.Text = pozionix25.ToString();
            label13.Text = pozionix3.ToString();
            label14.Text = riflessioni.ToString();
            label7.Text = "Money spent: " + soldi + " euros"; label7.Update();
            label20.Text = "Server: "+name_server(version);

            for (int i = 0; i < 6; i++)
             aggiornaContatori(i);
            
        }

        private string name_server(int version)
        {
            switch (version)
            {
                case 0: return "4Classic";
                case 1: return "4Ancient";
                case 2: return "4Story Official";
                default: return "";
            }
        }

        private string upgrading(int pozione, int pergamena, int up, int bRand, float bProb)
        {


            string risultato = "";

            if (pergamena == pergamenaRiflessioneVal && upgrade > 0)
            {
                upgrade--;
                if (pictureBox19.Visible == true)
                    balestra = upgrade;
                else
                    verga = upgrade;

                pictureBox12.Visible = true;
                pictureBox13.Visible = true;

                if (riflessioni == 0)
                    pictureBox20.Visible = false;

                label9.Visible = true;
                label9.Text = show_upgrade(0, upgrade, up, 0);
                label9.Update();



            }
            else if (pergamena == pergamenaMaestroVal && upgrade < 24)
            {

                if (bRand < bProb)
                {
                    Random rand2 = new Random();

                    up = pergamena == 3 ? (rand2.Next(0, 99) % 3) + 1 : 1;
                    upgrade += up;

                    if (upgrade > upgradeMAX)
                        upgrade = upgradeMAX;

                    if (pictureBox19.Visible == true)
                        balestra = upgrade;
                    else
                        verga = upgrade;


                    pictureBox12.Visible = true;
                    pictureBox13.Visible = true;
                    label9.Visible = true;

                    label9.Text = show_upgrade(1, upgrade, up, 0);
                    label9.Update();
                }
                else
                {
                    if (tintura == true)
                    {
                        int bLevelGuard = 11;
                        int bDownProb = 0;
                        int bDownGrade = 0;
                        Random rand3 = new Random();

                        if (upgrade <= bLevelGuard)
                            bDownProb = 0;
                        else
                            bDownProb = rand3.Next(0, 99) % 100;

                        if (bDownProb < 20)
                            bDownGrade = 0;
                        else if (bDownProb < 55)
                            bDownGrade = 1;
                        else
                            bDownGrade = 2;

                        if (upgrade > bLevelGuard && upgrade - bDownGrade < bLevelGuard)
                            bDownGrade = upgrade - bLevelGuard;

                        upgrade = upgrade - bDownGrade;

                        if (pictureBox19.Visible == true)
                            balestra = upgrade;
                        else
                            verga = upgrade;

                        tintura = false;
                        pictureBox21.Visible = false;
                        label9.Text = upgrade.ToString();
                        label9.Update();


                        pictureBox16.Visible = true;
                        pictureBox15.Visible = true;
                        label9.Text = show_upgrade(2, upgrade, up, bDownGrade);
                        label9.Update();
                    }
                    else
                    {
                        upgrade = 0;
                        if (pictureBox19.Visible == true)
                            balestra = upgrade;
                        else
                            verga = upgrade;


                        tintura = false;
                        //label5.Text = upgrade.ToString();
                        //label5.Update();
                        pictureBox16.Visible = true;
                        pictureBox15.Visible = true;

                        label9.Text = show_upgrade(3, upgrade, up, 0);
                        label9.Update();
                    }

                }


                if (pozioneUsata == pozioneFelicitaX2)
                    pictureBox22.Visible = false;
                else if (pozioneUsata == pozioneFelicitaX25)
                    pictureBox23.Visible = false;
                else if (pozioneUsata == pozioneFelicitaX3)
                    pictureBox24.Visible = false;


                pozioneUsata = 1;

                if (pergameneMaestro == 0)
                    pictureBox6.Visible = false;

                label16.Text = show_success_chance();
                label16.Update();


            }


            label18.Text = "+"+verga.ToString();
            label19.Text = "+" + balestra.ToString();
            return risultato;
        }

        public float check_prob_official(int val)
        {
            float prob = 0;
            switch (val)
            {
                case 0: prob = 100; break;
                case 1: prob = 100; break;
                case 2: prob = 100; break;
                case 3: prob = 75; break;
                case 4: prob = 100; break;
                case 5: prob = 45; break;
                case 6: prob = 90; break;
                case 7: prob = 30; break;
                case 8: prob = 75; break;
                case 9: prob = 15; break;
                case 10: prob = 45; break;
                case 11: prob = 38; break;
                case 12: prob = 8; break;
                case 13: prob = 30; break;
                case 14: prob = 8; break;
                case 15: prob = 23; break;
                case 16: prob = 5; break;
                case 17: prob = 15; break;
                case 18: prob = 5; break;
                case 19: prob = 12; break;
                case 20: prob = 3; break;
                case 21: prob = 9; break;
                case 22: prob = 3; break;
                case 23: prob = 8; break;
                case 24: prob = 0; break;
                default: prob = 0; break;

            }

            return prob;
        }
        public float check_prob_ancient(int val)
        {
            float prob = 0;
            switch (val)
            {
                case 0: prob = 100; break;
                case 1: prob = 100; break;
                case 2: prob = 100; break;
                case 3: prob = 100; break;
                case 4: prob = 100; break;
                case 5: prob = 100; break;
                case 6: prob = 100; break;
                case 7: prob = 100; break;
                case 8: prob = 91; break;
                case 9: prob = 80; break;
                case 10: prob = 50; break;
                case 11: prob = 65; break;
                case 12: prob = 15; break;
                case 13: prob = 35; break;
                case 14: prob = 9; break;
                case 15: prob = 10; break;
                case 16: prob = 7; break;
                case 17: prob = 6; break;
                case 18: prob = 3; break;
                case 19: prob = 1; break;
                case 20: prob = 1; break;
                case 21: prob = 1; break;
                case 22: prob = 1; break;
                case 23: prob = 2; break;
                case 24: prob = 0; break;
                default: prob = 0; break;

            }

            return prob;
        }

        public float check_prob(int val)
        {
            float prob = 0;
            switch (val)
            {
                case 0: prob = 100; break;
                case 1: prob = 100; break;
                case 2: prob = 100; break;
                case 3: prob = 100; break;
                case 4: prob = 100; break;
                case 5: prob = 100; break;
                case 6: prob = 100; break;
                case 7: prob = 100; break;
                case 8: prob = 100; break;
                case 9: prob = 100; break;
                case 10: prob = 100; break;
                case 11: prob = 60; break;
                case 12: prob = 20; break;
                case 13: prob = 35; break;
                case 14: prob = 13; break;
                case 15: prob = 12; break;
                case 16: prob = 5; break;
                case 17: prob = 7; break;
                case 18: prob = 3.50f; break;
                case 19: prob = 1; break;
                case 20: prob = 0.50f; break;
                case 21: prob = 0.80f; break;
                case 22: prob = 0.50f; break;
                case 23: prob = 0.60f; break;
                case 24: prob = 0; break;
                default: prob = 0; break;

            }

            return prob;
        }

        public float CalcProb(float bBaseProb, int pozione)
        {
            float wAddProb = 0;
            if (bBaseProb >= 100 || pozione == 1)
                wAddProb = bBaseProb;
            else
                wAddProb = bBaseProb * pozione / 100;

            if (wAddProb > 100)
                wAddProb = 100;

            return wAddProb;
        }


        private string show_numbers(int bRand, float bProb)
        {
            label17.Visible = true;
            return "Random number: " + bRand + "  Chance: " + bProb + "%";
        }

        private string show_success_chance()
        {
            label16.Visible = true;

            switch (version)
            {
                case 0: return "Success chance: " + CalcProb(check_prob(upgrade), pozioneUsata) + "%";
                case 1: return "Success chance: " + CalcProb(check_prob_ancient(upgrade), pozioneUsata) + "%";
                case 2: return "Success chance: " + CalcProb(check_prob_official(upgrade), pozioneUsata) + "%";
                default: return "";
            }

        }

        private string show_upgrade(int result, int upgrade, int up, int bDownGrade)
        {
            label9.Visible = true;

            if (pictureBox19.Visible == true)
                label8.Text = "Dragon Hunter's Crossbow +" + balestra;
            else
                label8.Text = "Sepira Rod +" + verga;

            //label8.Visible = true;

            int oldlevel = upgrade + 1;
            int down = upgrade + bDownGrade;
            switch (result)
            {
                case 0: return "[4S] An Item has been succesfully deleveled from level +" + oldlevel + " to +" + upgrade;
                case 1: return "[4S] An Item has been succesfully improved to level +" + upgrade + ". Increased by " + up;
                case 2: return "[4S] An Item failed from level +" + down + ". Decreased by " + bDownGrade;
                case 3: return "[4S] An Item has been broken because you didn't use a tinture";
                default: return "";
            }
        }

        private void aggiornaContatori(int val)
        {
            switch (val)
            {
                case 0: label2.Text = "Serendipity Potion used: " + pozioniUtilizzate; label2.Update(); break;
                case 1: label1.Text = "Tinture used: " + tintureUtilizzate; label1.Update(); break;
                case 2: label5.Text = "Reflections used: " + riflessioniUtilizzate; label5.Update(); break;
                case 3: label6.Text = "Master formula used: " + pergameneMaestroUtilizzate; label6.Update(); break;
                case 4: label3.Text = "Serendipity Potion 250% used: " + pozionix25Utilizzate; label3.Update(); break;
                case 5: label4.Text = "Serendipity Potion 300% used: " + pozionix3Utilizzate; label4.Update(); break;
            }

        }
        private async void CountDown()
        {
            int timeToComplete = 100; //Time in seconds
            try
            {
                if (File.Exists(Directory.GetCurrentDirectory() + @"\sounds\loading.wav"))
                    loading.Play();
            }
            catch (FileNotFoundException)
            {

            }
            progressBar1.Minimum = 0;
            progressBar1.Maximum = timeToComplete;
            progressBar1.Value = 0;

            for (int i = 1; i <= timeToComplete; i++) //cicla su tutti gli elementi trovati
            {

                progressBar1.Value = i;
                progressBar1.Value = i - 1;
                System.Threading.Thread.Sleep(1);
            }
            progressBar1.Value = 100;


            if (result == true)
            {
                try
                {
                    if (File.Exists(Directory.GetCurrentDirectory() + @"\sounds\up.wav"))
                        up.Play();
                }
                catch (FileNotFoundException)
                {

                }
            }
            else
            {
                try
                {
                    if (File.Exists(Directory.GetCurrentDirectory() + @"\sounds\fail.wav"))
                        fail.Play();
                }
                catch (FileNotFoundException)
                {

                }
            }

        }


        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            //select.Play();
            pictureBox12.Visible = false;
            pictureBox13.Visible = false;
            ready = true;
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            //select.Play();
            pictureBox15.Visible = false;
            pictureBox16.Visible = false;
            ready = true;
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            if ((pictureBox17.Visible == true || pictureBox19.Visible == true) && (pergamenaUsata > 0 && ready == true && pictureBox12.Visible == false && pictureBox16.Visible == false))
            {
                
                bool ok = false;
                Random rand = new Random();
                int number = rand.Next(0, 99); //returns random number between 0-99
                int bRand = number % 100;
                float bProb = 0;

                if (pergamenaUsata == pergamenaRiflessioneVal)
                {

                    if (upgrade > 0)
                    {
                        try
                        {
                            if (File.Exists(Directory.GetCurrentDirectory() + @"\sounds\select.wav"))
                                select.Play();
                        }
                        catch (FileNotFoundException)
                        {

                        }

                        switch (version)
                        {
                            case 0: bProb = CalcProb(check_prob(upgrade), pozioneUsata); break;
                            case 1: bProb = CalcProb(check_prob_ancient(upgrade), pozioneUsata); break;
                            case 2: bProb = CalcProb(check_prob_official(upgrade), pozioneUsata); break;
                            default: break;
                        }

                        //label17.Text = show_numbers(bRand, bProb);

                        if (bRand < bProb)
                            result = true;
                        else
                            result = false;

                        result = true;
                        ready = false;
                        progressBar1.Enabled = true;
                        progressBar1.Visible = true;
                        CountDown();

                        riflessioniUtilizzate++;
                        riflessioni--;
                        ok = true;
                    }
                }
                else
                {
                    try
                    {
                        if (File.Exists(Directory.GetCurrentDirectory() + @"\sounds\select.wav"))
                            select.Play();
                    }
                    catch (FileNotFoundException)
                    {

                    }
                    switch (version)
                    {
                        case 0: bProb = CalcProb(check_prob(upgrade), pozioneUsata);  break;
                        case 1: bProb = CalcProb(check_prob_ancient(upgrade), pozioneUsata); break;
                        case 2: bProb = CalcProb(check_prob_official(upgrade), pozioneUsata); break;
                        default: break;
                    }
                    label17.Text = show_numbers(bRand, bProb);
                    
                    if (bRand < bProb)
                        result = true;
                    else
                        result = false;

                    if (pozioneUsata == pozioneFelicitaX2)
                    {
                        pozionix2--;
                        pozioniUtilizzate++;
                        aggiornaContatori(0);
                        label11.Text = pozionix2.ToString();
                    }
                    else if (pozioneUsata == pozioneFelicitaX25)
                    {
                        pozionix25--;
                        pozionix25Utilizzate++;
                        aggiornaContatori(4);
                        label12.Text = pozionix25.ToString();
                    }
                    else if (pozioneUsata == pozioneFelicitaX3)
                    {
                        pozionix3--;
                        pozionix3Utilizzate++;
                        aggiornaContatori(5);
                        label13.Text = pozionix3.ToString();
                    }

                    ready = false;
                    progressBar1.Enabled = true;
                    progressBar1.Visible = true;
                    CountDown();
                    pergameneMaestroUtilizzate++;
                    pergameneMaestro--;
                    ok = true;
                }

                if (ok == true)
                {

                    for (int i = 0; i < 6; i++)
                        aggiornaContatori(i);

                    progressBar1.Value = 0;
                    upgrading(pozioneUsata, pergamenaUsata, upgrade, bRand, bProb).ToString();
                    //label5.Update();
                    label15.Text = pergameneMaestro.ToString();
                    label9.Update();
                    label11.Update();
                    label14.Text = riflessioni.ToString();
                    progressBar1.Enabled = false;
                    progressBar1.Visible = false;

                    if (pergameneMaestro == 0 || riflessioni == 0)
                        pergamenaUsata = 0;
                }
            }
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        
            try
            {
                if (File.Exists(Directory.GetCurrentDirectory() + @"\sounds\cash.wav"))
                    cash.Play();
            }
            catch (FileNotFoundException)
            {
                
            }


            System.Threading.Thread.Sleep(600);
            pergameneMaestro += 100;
            tinture += 50;
            pozionix2 += 100;
            pozionix25 += 20;
            pozionix3 += 10;
            riflessioni += 100;
            soldi += 50;
            label14.Text = riflessioni.ToString();
            label11.Text = pozionix2.ToString();
            label10.Text = tinture.ToString();
            label15.Text = pergameneMaestro.ToString();
            label12.Text = pozionix25.ToString();
            label13.Text = pozionix3.ToString();
            label7.Text = "Money spent: " + soldi + " euros"; label7.Update();

            for (int i = 0; i < 6; i++)
                aggiornaContatori(i);

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (pictureBox12.Visible == false && pictureBox16.Visible == false && pictureBox22.Visible == false)
            {
                if (pozionix2 > 0)
                {
                    //select.Play();
                    pozioneUsata = pozioneFelicitaX2;
                    label11.Text = pozionix2.ToString();
                    pictureBox22.Visible = true;
                    pictureBox23.Visible = false;
                    pictureBox24.Visible = false;
                    if (pictureBox20.Visible == false)
                    {
                        label16.Visible = true;
                        label16.Text = show_success_chance();
                        label16.Update();
                    }
                }
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (pictureBox12.Visible == false && pictureBox16.Visible == false && pictureBox21.Visible == false)
            {
                if (tinture > 0)
                {
                    //select.Play();
                    tinture--;
                    tintureUtilizzate++;
                    aggiornaContatori(1);
                    label10.Text = tinture.ToString();
                    tintura = true;
                    pictureBox21.Visible = true;
                }
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
            if (pictureBox12.Visible == false && pictureBox16.Visible == false && pictureBox21.Visible == false)
            {
                if (tinture > 0)
                {
                    //select.Play();
                    tinture--;
                    tintureUtilizzate++;
                    aggiornaContatori(1);
                    label10.Text = tinture.ToString();
                    tintura = true;
                    pictureBox21.Visible = true;
                }
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            if (pictureBox12.Visible == false && pictureBox16.Visible == false && pictureBox22.Visible == false)
            {
                if (pozionix2 > 0)
                {
                    //select.Play();
                    pozioneUsata = pozioneFelicitaX2;
                    label11.Text = pozionix2.ToString();
                    pictureBox22.Visible = true;
                    pictureBox23.Visible = false;
                    pictureBox24.Visible = false;
                    if (pictureBox20.Visible == false)
                    {
                        label16.Visible = true;
                        label16.Text = show_success_chance();
                        label16.Update();
                    }
                }
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (pictureBox12.Visible == false && pictureBox16.Visible == false && pictureBox23.Visible == false)
            {
                if (pozionix25 > 0)
                {
                    //select.Play();
                    pozioneUsata = pozioneFelicitaX25;
                    label12.Text = pozionix25.ToString();
                    pictureBox22.Visible = false;
                    pictureBox23.Visible = true;
                    pictureBox24.Visible = false;
                    if (pictureBox20.Visible == false)
                    {
                        label16.Visible = true;
                        label16.Text = show_success_chance();
                        label16.Update();
                    }
                }
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {
            if (pictureBox12.Visible == false && pictureBox16.Visible == false && pictureBox23.Visible == false)
            {
                if (pozionix25 > 0)
                {
                    //select.Play();
                    pozioneUsata = pozioneFelicitaX25;
                    label12.Text = pozionix25.ToString();
                    pictureBox22.Visible = false;
                    pictureBox23.Visible = true;
                    pictureBox24.Visible = false;
                    if (pictureBox20.Visible == false)
                    {
                        label16.Visible = true;
                        label16.Text = show_success_chance();
                        label16.Update();
                    }
                }
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (pictureBox12.Visible == false && pictureBox16.Visible == false && pictureBox24.Visible == false)
            {
                if (pozionix3 > 0)
                {
                    //select.Play();
                    pozioneUsata = pozioneFelicitaX3;
                    label13.Text = pozionix3.ToString();
                    pictureBox22.Visible = false;
                    pictureBox23.Visible = false;
                    pictureBox24.Visible = true;
                    if (pictureBox20.Visible == false)
                    {
                        label16.Visible = true;
                        label16.Text = show_success_chance();
                        label16.Update();
                    }
                }
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {
            if (pictureBox12.Visible == false && pictureBox16.Visible == false && pictureBox24.Visible == false)
            {
                if (pozionix3 > 0)
                {
                   // select.Play();
                    pozioneUsata = pozioneFelicitaX3;
                    label13.Text = pozionix3.ToString();
                    pictureBox22.Visible = false;
                    pictureBox23.Visible = false;
                    pictureBox24.Visible = true;
                    if (pictureBox20.Visible == false)
                    {
                        label16.Visible = true;
                        label16.Text = show_success_chance();
                        label16.Update();
                    }
                }
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {
            if (pictureBox12.Visible == false && pictureBox16.Visible == false && pictureBox18.Visible == false)
            {
                if (pergameneMaestro > 0)
                {
                    //select.Play();
                    pictureBox18.Visible = true;
                    pictureBox20.Visible = false;
                    label17.Visible = false;
                    pergamenaUsata = pergamenaMaestroVal;
                    label16.Text = show_success_chance();
                }
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            if (pictureBox12.Visible == false && pictureBox16.Visible == false && pictureBox18.Visible == false)
            {
                if (pergameneMaestro > 0)
                {
                    //select.Play();
                    pictureBox18.Visible = true;
                    pictureBox20.Visible = false;
                    label17.Visible = false;
                    pergamenaUsata = pergamenaMaestroVal;
                    label16.Visible = true;
                    label16.Text = show_success_chance();
                }
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (pictureBox12.Visible == false && pictureBox16.Visible == false && pictureBox20.Visible == false)
            {
                if (riflessioni > 0)
                {
                    //select.Play();
                    pictureBox18.Visible = false;
                    pictureBox20.Visible = true;
                    label17.Visible = false;
                    label16.Visible = false;
                    pergamenaUsata = pergamenaRiflessioneVal;
                }
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {
            if (pictureBox12.Visible == false && pictureBox16.Visible == false && pictureBox20.Visible == false)
            {
                if (riflessioni > 0)
                {
                    //select.Play();
                    pictureBox18.Visible = false;
                    pictureBox20.Visible = true;
                    label17.Visible = false;
                    label16.Visible = false;
                    pergamenaUsata = pergamenaRiflessioneVal;
                }
            }
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            if (pictureBox12.Visible == false && pictureBox16.Visible == false && pictureBox19.Visible == false)
            {
                //select.Play();
                pictureBox19.Visible = true;
                pictureBox17.Visible = false;
                upgrade = balestra;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            if (pictureBox12.Visible == false && pictureBox16.Visible == false && pictureBox17.Visible == false)
            {
                //select.Play();
                pictureBox17.Visible = true;
                pictureBox19.Visible = false;
                upgrade = verga;
            }
        }

        private void label19_Click(object sender, EventArgs e)
        {
            if (pictureBox12.Visible == false && pictureBox16.Visible == false && pictureBox19.Visible == false)
            {
                //select.Play();
                pictureBox19.Visible = true;
                pictureBox17.Visible = false;
                upgrade = balestra;
            }
        }

        private void label18_Click(object sender, EventArgs e)
        {
            if (pictureBox12.Visible == false && pictureBox16.Visible == false && pictureBox17.Visible == false)
            {
                //select.Play();
                pictureBox17.Visible = true;
                pictureBox19.Visible = false;
                upgrade = verga;
            }
        }

        private void change_server(int val)
        {
            switch (val)
            {
                case 0: MessageBox.Show("4Classic Upgrading rates has been added"); break;
                case 1: MessageBox.Show("4Ancient Upgrading rates has been added"); break;
                case 2: MessageBox.Show("4Story Official Upgrading rates has been added"); break;
                default: break;
            }


        }
        private void pictureBox25_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(Directory.GetCurrentDirectory() + @"\sounds\select.wav"))
                    select.Play();
            }
            catch (FileNotFoundException)
            {

            }
            upgrade = 0;
            balestra = 0;
            verga = 0;
            pozioneFelicitaX2 = 200;
            pozioneFelicitaX25 = 250;
            pozioneFelicitaX3 = 300;
            pergamenaMaestroVal = 3;
            pergamenaRiflessioneVal = 1;
            upgradeMAX = 24;
            tintura = false;
            pergameneMaestro = 250;
            tinture = 50;
            pozionix2 = 250;
            pozionix25 = 20;
            pozionix3 = 10;
            riflessioni = 250;
            pozioneUsata = 1;
            pergamenaUsata = 0;
            ready = true;
            pozioniUtilizzate = 0;
            pozionix25Utilizzate = 0;
            pozionix3Utilizzate = 0;
            pergameneMaestroUtilizzate = 0;
            tintureUtilizzate = 0;
            riflessioniUtilizzate = 0;
            balestra = 0;
            verga = 0;
            soldi = 0;
            result = false;
            version = 0;
            pictureBox12.Visible = false;
            pictureBox13.Visible = false;
            pictureBox15.Visible = false;
            pictureBox16.Visible = false;
            pictureBox17.Visible = false;
            pictureBox18.Visible = false;
            pictureBox19.Visible = false;
            pictureBox20.Visible = false;
            pictureBox21.Visible = false;
            pictureBox22.Visible = false;
            pictureBox23.Visible = false;
            pictureBox24.Visible = false;
            label9.Visible = false;
            label15.Text = pergameneMaestro.ToString();
            label14.Text = riflessioni.ToString();
            label11.Text = pozionix2.ToString();
            label10.Text = tinture.ToString();
            label12.Text = pozionix25.ToString();
            label13.Text = pozionix3.ToString();
            label7.Text = "Money spent: 0 euros";
            label16.Visible = false;
            label16.Update();
            label17.Visible = false;
            label17.Update();
            label18.Text = "+0";
            label19.Text = "+0";

            for (int i = 0; i < 6; i++)
                aggiornaContatori(i);

            //change_server(0);
            label20.Text = name_server(version);
        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(Directory.GetCurrentDirectory() + @"\sounds\select.wav"))
                    select.Play();
            }
            catch (FileNotFoundException)
            {

            }
            upgrade = 0;
            balestra = 0;
            verga = 0;
            pozioneFelicitaX2 = 200;
            pozioneFelicitaX25 = 250;
            pozioneFelicitaX3 = 300;
            pergamenaMaestroVal = 3;
            pergamenaRiflessioneVal = 1;
            upgradeMAX = 24;
            tintura = false;
            pergameneMaestro = 250;
            tinture = 50;
            pozionix2 = 250;
            pozionix25 = 20;
            pozionix3 = 10;
            riflessioni = 250;
            pozioneUsata = 1;
            pergamenaUsata = 0;
            ready = true;
            pozioniUtilizzate = 0;
            pozionix25Utilizzate = 0;
            pozionix3Utilizzate = 0;
            pergameneMaestroUtilizzate = 0;
            tintureUtilizzate = 0;
            riflessioniUtilizzate = 0;
            balestra = 0;
            verga = 0;
            soldi = 0;
            result = false;
            version = 1;
            pictureBox12.Visible = false;
            pictureBox13.Visible = false;
            pictureBox15.Visible = false;
            pictureBox16.Visible = false;
            pictureBox17.Visible = false;
            pictureBox18.Visible = false;
            pictureBox19.Visible = false;
            pictureBox20.Visible = false;
            pictureBox21.Visible = false;
            pictureBox22.Visible = false;
            pictureBox23.Visible = false;
            pictureBox24.Visible = false;
            label9.Visible = false;
            label15.Text = pergameneMaestro.ToString();
            label14.Text = riflessioni.ToString();
            label11.Text = pozionix2.ToString();
            label10.Text = tinture.ToString();
            label12.Text = pozionix25.ToString();
            label13.Text = pozionix3.ToString();
            label7.Text = "Money spent: 0 euros";
            label16.Visible = false;
            label16.Update();
            label17.Visible = false;
            label17.Update();
            label18.Text = "+0";
            label19.Text = "+0";

            for (int i = 0; i < 6; i++)
                aggiornaContatori(i);

            //change_server(1);
            label20.Text = name_server(version);
        }

        private void pictureBox27_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(Directory.GetCurrentDirectory() + @"\sounds\select.wav"))
                    select.Play();
            }
            catch (FileNotFoundException)
            {

            }
            upgrade = 0;
            balestra = 0;
            verga = 0;
            pozioneFelicitaX2 = 200;
            pozioneFelicitaX25 = 250;
            pozioneFelicitaX3 = 300;
            pergamenaMaestroVal = 3;
            pergamenaRiflessioneVal = 1;
            upgradeMAX = 24;
            tintura = false;
            pergameneMaestro = 250;
            tinture = 50;
            pozionix2 = 250;
            pozionix25 = 20;
            pozionix3 = 10;
            riflessioni = 250;
            pozioneUsata = 1;
            pergamenaUsata = 0;
            ready = true;
            pozioniUtilizzate = 0;
            pozionix25Utilizzate = 0;
            pozionix3Utilizzate = 0;
            pergameneMaestroUtilizzate = 0;
            tintureUtilizzate = 0;
            riflessioniUtilizzate = 0;
            balestra = 0;
            verga = 0;
            soldi = 0;
            result = false;
            version = 2;
            pictureBox12.Visible = false;
            pictureBox13.Visible = false;
            pictureBox15.Visible = false;
            pictureBox16.Visible = false;
            pictureBox17.Visible = false;
            pictureBox18.Visible = false;
            pictureBox19.Visible = false;
            pictureBox20.Visible = false;
            pictureBox21.Visible = false;
            pictureBox22.Visible = false;
            pictureBox23.Visible = false;
            pictureBox24.Visible = false;
            label9.Visible = false;
            label15.Text = pergameneMaestro.ToString();
            label14.Text = riflessioni.ToString();
            label11.Text = pozionix2.ToString();
            label10.Text = tinture.ToString();
            label12.Text = pozionix25.ToString();
            label13.Text = pozionix3.ToString();
            label7.Text = "Money spent: 0 euros";
            label16.Visible = false;
            label16.Update();
            label17.Visible = false;
            label17.Update();
            label18.Text = "+0";
            label19.Text = "+0";

            for (int i = 0; i < 6; i++)
                aggiornaContatori(i);

            //change_server(2);
            label20.Text = name_server(version);
        }
    }
}