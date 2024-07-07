﻿using System;

namespace Assets.NeuralNet
{
    public static class ZValue
    {
        static double[,] values;


        /// <summary>
        /// Returns the percentage of values to the right/left of the given Z value
        /// </summary>
        /// <param name="ZValue"></param>
        /// <returns></returns>
        public static double GetPercentile(double ZValue)
        {
            if (values == null)
            {
                InitValues();
            }

            var roundedValue = Math.Abs(Math.Round(ZValue, 2));
            
            if (roundedValue > 4.09)
            {
                return 1;
            }

            var roundedValueStr = roundedValue.ToString("0.00").ToCharArray();

            short digit1 = short.Parse(roundedValueStr[0].ToString());
            short digit2 = short.Parse(roundedValueStr[2].ToString());
            short digit3 = short.Parse(roundedValueStr[3].ToString());

            int index1 = digit1 * 10 + digit2;

            return values[index1, digit3];
        }

        private static void InitValues()
        {
            values = new double[43, 10];


            values[0, 0] = 0.5;
            values[0, 1] = 0.5039893563;
            values[0, 2] = 0.5079783137;
            values[0, 3] = 0.5119664734;
            values[0, 4] = 0.5159534369;
            values[0, 5] = 0.5199388058;
            values[0, 6] = 0.5239221827;
            values[0, 7] = 0.5279031702;
            values[0, 8] = 0.531881372;
            values[0, 9] = 0.5358563926;

            values[1, 0] = 0.5398278373;
            values[1, 1] = 0.5437953125;
            values[1, 2] = 0.547758426;
            values[1, 3] = 0.5517167867;
            values[1, 4] = 0.5556700048;
            values[1, 5] = 0.5596176924;
            values[1, 6] = 0.5635594629;
            values[1, 7] = 0.5674949317;
            values[1, 8] = 0.5714237159;
            values[1, 9] = 0.5753454347;

            values[2, 0] = 0.5792597094;
            values[2, 1] = 0.5831661635;
            values[2, 2] = 0.5870644226;
            values[2, 3] = 0.5909541151;
            values[2, 4] = 0.5948348717;
            values[2, 5] = 0.5987063257;
            values[2, 6] = 0.6025681132;
            values[2, 7] = 0.6064198732;
            values[2, 8] = 0.6102612476;
            values[2, 9] = 0.6140918812;

            values[3, 0] = 0.6179114222;
            values[3, 1] = 0.6217195218;
            values[3, 2] = 0.6255158347;
            values[3, 3] = 0.6293000189;
            values[3, 4] = 0.633071736;
            values[3, 5] = 0.6368306512;
            values[3, 6] = 0.6405764332;
            values[3, 7] = 0.6443087548;
            values[3, 8] = 0.6480272924;
            values[3, 9] = 0.6517317265;

            values[4, 0] = 0.6554217416;
            values[4, 1] = 0.6590970262;
            values[4, 2] = 0.6627572732;
            values[4, 3] = 0.6664021794;
            values[4, 4] = 0.6700314463;
            values[4, 5] = 0.6736447797;
            values[4, 6] = 0.6772418897;
            values[4, 7] = 0.6808224912;
            values[4, 8] = 0.6843863035;
            values[4, 9] = 0.6879330506;

            values[5, 0] = 0.6914624613;
            values[5, 1] = 0.6949742691;
            values[5, 2] = 0.6984682125;
            values[5, 3] = 0.7019440346;
            values[5, 4] = 0.7054014838;
            values[5, 5] = 0.7088403132;
            values[5, 6] = 0.7122602812;
            values[5, 7] = 0.715661151;
            values[5, 8] = 0.7190426911;
            values[5, 9] = 0.7224046752;

            values[6, 0] = 0.7257468822;
            values[6, 1] = 0.7290690962;
            values[6, 2] = 0.7323711065;
            values[6, 3] = 0.7356527079;
            values[6, 4] = 0.7389137003;
            values[6, 5] = 0.7421538892;
            values[6, 6] = 0.7453730853;
            values[6, 7] = 0.7485711049;
            values[6, 8] = 0.7517477695;
            values[6, 9] = 0.7549029063;

            values[7, 0] = 0.7580363478;
            values[7, 1] = 0.7611479319;
            values[7, 2] = 0.7642375022;
            values[7, 3] = 0.7673049077;
            values[7, 4] = 0.7703500028;
            values[7, 5] = 0.7733726476;
            values[7, 6] = 0.7763727076;
            values[7, 7] = 0.7793500537;
            values[7, 8] = 0.7823045624;
            values[7, 9] = 0.7852361158;

            values[8, 0] = 0.7881446014;
            values[8, 1] = 0.7910299121;
            values[8, 2] = 0.7938919464;
            values[8, 3] = 0.7967306082;
            values[8, 4] = 0.7995458067;
            values[8, 5] = 0.8023374569;
            values[8, 6] = 0.8051054787;
            values[8, 7] = 0.8078497979;
            values[8, 8] = 0.8105703452;
            values[8, 9] = 0.813267057;

            values[9, 0] = 0.8159398747;
            values[9, 1] = 0.8185887451;
            values[9, 2] = 0.8212136204;
            values[9, 3] = 0.8238144578;
            values[9, 4] = 0.8263912197;
            values[9, 5] = 0.8289438737;
            values[9, 6] = 0.8314723925;
            values[9, 7] = 0.8339767539;
            values[9, 8] = 0.8364569407;
            values[9, 9] = 0.8389129405;

            values[10, 0] = 0.8413447461;
            values[10, 1] = 0.843752355;
            values[10, 2] = 0.8461357696;
            values[10, 3] = 0.8484949972;
            values[10, 4] = 0.8508300497;
            values[10, 5] = 0.8531409436;
            values[10, 6] = 0.8554277003;
            values[10, 7] = 0.8576903456;
            values[10, 8] = 0.8599289099;
            values[10, 9] = 0.862143428;

            values[11, 0] = 0.8643339391;
            values[11, 1] = 0.8665004868;
            values[11, 2] = 0.868643119;
            values[11, 3] = 0.8707618878;
            values[11, 4] = 0.8728568494;
            values[11, 5] = 0.8749280644;
            values[11, 6] = 0.8769755969;
            values[11, 7] = 0.8789995156;
            values[11, 8] = 0.8809998925;
            values[11, 9] = 0.882976804;

            values[12, 0] = 0.8849303298;
            values[12, 1] = 0.8868605536;
            values[12, 2] = 0.8887675626;
            values[12, 3] = 0.8906514476;
            values[12, 4] = 0.8925123029;
            values[12, 5] = 0.8943502263;
            values[12, 6] = 0.8961653189;
            values[12, 7] = 0.8979576849;
            values[12, 8] = 0.899727432;
            values[12, 9] = 0.901474671;

            values[13, 0] = 0.9031995154;
            values[13, 1] = 0.9049020822;
            values[13, 2] = 0.906582491;
            values[13, 3] = 0.9082408643;
            values[13, 4] = 0.9098773275;
            values[13, 5] = 0.9114920086;
            values[13, 6] = 0.9130850381;
            values[13, 7] = 0.9146565492;
            values[13, 8] = 0.9162066776;
            values[13, 9] = 0.9177355613;

            values[14, 0] = 0.9192433408;
            values[14, 1] = 0.9207301585;
            values[14, 2] = 0.9221961595;
            values[14, 3] = 0.9236414905;
            values[14, 4] = 0.9250663005;
            values[14, 5] = 0.9264707404;
            values[14, 6] = 0.927854963;
            values[14, 7] = 0.929219123;
            values[14, 8] = 0.9305633767;
            values[14, 9] = 0.931887882;

            values[15, 0] = 0.9331927987;
            values[15, 1] = 0.9344782879;
            values[15, 2] = 0.9357445122;
            values[15, 3] = 0.9369916355;
            values[15, 4] = 0.9382198233;
            values[15, 5] = 0.939429242;
            values[15, 6] = 0.9406200594;
            values[15, 7] = 0.9417924444;
            values[15, 8] = 0.9429465668;
            values[15, 9] = 0.9440825975;

            values[16, 0] = 0.9452007083;
            values[16, 1] = 0.9463010719;
            values[16, 2] = 0.9473838615;
            values[16, 3] = 0.9484492515;
            values[16, 4] = 0.9494974165;
            values[16, 5] = 0.950528532;
            values[16, 6] = 0.9515427737;
            values[16, 7] = 0.9525403182;
            values[16, 8] = 0.9535213421;
            values[16, 9] = 0.9544860227;

            values[17, 0] = 0.9554345372;
            values[17, 1] = 0.9563670635;
            values[17, 2] = 0.9572837792;
            values[17, 3] = 0.9581848624;
            values[17, 4] = 0.959070491;
            values[17, 5] = 0.9599408431;
            values[17, 6] = 0.9607960967;
            values[17, 7] = 0.9616364296;
            values[17, 8] = 0.9624620197;
            values[17, 9] = 0.9632730443;

            values[18, 0] = 0.9640696809;
            values[18, 1] = 0.9648521064;
            values[18, 2] = 0.9656204976;
            values[18, 3] = 0.9663750306;
            values[18, 4] = 0.9671158813;
            values[18, 5] = 0.9678432252;
            values[18, 6] = 0.968557237;
            values[18, 7] = 0.9692580911;
            values[18, 8] = 0.969945961;
            values[18, 9] = 0.97062102;

            values[19, 0] = 0.9712834402;
            values[19, 1] = 0.9719333933;
            values[19, 2] = 0.9725710503;
            values[19, 3] = 0.9731965811;
            values[19, 4] = 0.9738101551;
            values[19, 5] = 0.9744119405;
            values[19, 6] = 0.9750021049;
            values[19, 7] = 0.9755808147;
            values[19, 8] = 0.9761482357;
            values[19, 9] = 0.9767045322;

            values[20, 0] = 0.9772498681;
            values[20, 1] = 0.9777844056;
            values[20, 2] = 0.9783083062;
            values[20, 3] = 0.9788217304;
            values[20, 4] = 0.9793248371;
            values[20, 5] = 0.9798177846;
            values[20, 6] = 0.9803007296;
            values[20, 7] = 0.9807738278;
            values[20, 8] = 0.9812372336;
            values[20, 9] = 0.9816911001;

            values[21, 0] = 0.9821355794;
            values[21, 1] = 0.9825708221;
            values[21, 2] = 0.9829969774;
            values[21, 3] = 0.9834141933;
            values[21, 4] = 0.9838226166;
            values[21, 5] = 0.9842223926;
            values[21, 6] = 0.9846136652;
            values[21, 7] = 0.984996577;
            values[21, 8] = 0.9853712692;
            values[21, 9] = 0.9857378816;

            values[22, 0] = 0.9860965525;
            values[22, 1] = 0.9864474189;
            values[22, 2] = 0.9867906162;
            values[22, 3] = 0.9871262786;
            values[22, 4] = 0.9874545386;
            values[22, 5] = 0.9877755273;
            values[22, 6] = 0.9880893746;
            values[22, 7] = 0.9883962085;
            values[22, 8] = 0.9886961558;
            values[22, 9] = 0.9889893417;

            values[23, 0] = 0.98927589;
            values[23, 1] = 0.9895559229;
            values[23, 2] = 0.9898295613;
            values[23, 3] = 0.9900969244;
            values[23, 4] = 0.9903581301;
            values[23, 5] = 0.9906132945;
            values[23, 6] = 0.9908625325;
            values[23, 7] = 0.9911059574;
            values[23, 8] = 0.991343681;
            values[23, 9] = 0.9915758136;

            values[24, 0] = 0.9918024641;
            values[24, 1] = 0.9920237397;
            values[24, 2] = 0.9922397464;
            values[24, 3] = 0.9924505886;
            values[24, 4] = 0.992656369;
            values[24, 5] = 0.9928571893;
            values[24, 6] = 0.9930531492;
            values[24, 7] = 0.9932443474;
            values[24, 8] = 0.9934308809;
            values[24, 9] = 0.9936128452;

            values[25, 0] = 0.9937903347;
            values[25, 1] = 0.9939634419;
            values[25, 2] = 0.9941322583;
            values[25, 3] = 0.9942968737;
            values[25, 4] = 0.9944573766;
            values[25, 5] = 0.994613854;
            values[25, 6] = 0.9947663918;
            values[25, 7] = 0.9949150743;
            values[25, 8] = 0.9950599842;
            values[25, 9] = 0.9952012034;

            values[26, 0] = 0.995338812;
            values[26, 1] = 0.9954728889;
            values[26, 2] = 0.9956035117;
            values[26, 3] = 0.9957307566;
            values[26, 4] = 0.9958546986;
            values[26, 5] = 0.9959754115;
            values[26, 6] = 0.9960929674;
            values[26, 7] = 0.9962074377;
            values[26, 8] = 0.996318892;
            values[26, 9] = 0.996427399;

            values[27, 0] = 0.9965330262;
            values[27, 1] = 0.9966358396;
            values[27, 2] = 0.9967359042;
            values[27, 3] = 0.9968332837;
            values[27, 4] = 0.9969280408;
            values[27, 5] = 0.9970202368;
            values[27, 6] = 0.9971099319;
            values[27, 7] = 0.9971971854;
            values[27, 8] = 0.9972820551;
            values[27, 9] = 0.9973645979;

            values[28, 0] = 0.9974448697;
            values[28, 1] = 0.997522925;
            values[28, 2] = 0.9975988175;
            values[28, 3] = 0.9976725998;
            values[28, 4] = 0.9977443233;
            values[28, 5] = 0.9978140385;
            values[28, 6] = 0.997881795;
            values[28, 7] = 0.997947641;
            values[28, 8] = 0.9980116241;
            values[28, 9] = 0.9980737909;

            values[29, 0] = 0.9981341867;
            values[29, 1] = 0.9981928562;
            values[29, 2] = 0.9982498431;
            values[29, 3] = 0.99830519;
            values[29, 4] = 0.9983589388;
            values[29, 5] = 0.9984111304;
            values[29, 6] = 0.9984618048;
            values[29, 7] = 0.9985110013;
            values[29, 8] = 0.9985587581;
            values[29, 9] = 0.9986051128;

            values[30, 0] = 0.998650102;
            values[30, 1] = 0.9986937616;
            values[30, 2] = 0.9987361266;
            values[30, 3] = 0.9987772313;
            values[30, 4] = 0.9988171093;
            values[30, 5] = 0.9988557932;
            values[30, 6] = 0.998893315;
            values[30, 7] = 0.9989297061;
            values[30, 8] = 0.998964997;
            values[30, 9] = 0.9989992175;

            values[31, 0] = 0.9990323968;
            values[31, 1] = 0.9990645633;
            values[31, 2] = 0.9990957448;
            values[31, 3] = 0.9991259685;
            values[31, 4] = 0.9991552608;
            values[31, 5] = 0.9991836477;
            values[31, 6] = 0.9992111543;
            values[31, 7] = 0.9992378053;
            values[31, 8] = 0.9992636247;
            values[31, 9] = 0.999288636;

            values[32, 0] = 0.9993128621;
            values[32, 1] = 0.9993363251;
            values[32, 2] = 0.999359047;
            values[32, 3] = 0.9993810489;
            values[32, 4] = 0.9994023515;
            values[32, 5] = 0.999422975;
            values[32, 6] = 0.9994429389;
            values[32, 7] = 0.9994622626;
            values[32, 8] = 0.9994809646;
            values[32, 9] = 0.9994990631;

            values[33, 0] = 0.9995165759;
            values[33, 1] = 0.9995335201;
            values[33, 2] = 0.9995499128;
            values[33, 3] = 0.9995657701;
            values[33, 4] = 0.9995811081;
            values[33, 5] = 0.9995959422;
            values[33, 6] = 0.9996102876;
            values[33, 7] = 0.9996241591;
            values[33, 8] = 0.9996375709;
            values[33, 9] = 0.9996505369;

            values[34, 0] = 0.9996630707;
            values[34, 1] = 0.9996751856;
            values[34, 2] = 0.9996868943;
            values[34, 3] = 0.9996982094;
            values[34, 4] = 0.9997091429;
            values[34, 5] = 0.9997197067;
            values[34, 6] = 0.9997299123;
            values[34, 7] = 0.9997397708;
            values[34, 8] = 0.9997492931;
            values[34, 9] = 0.9997584897;

            values[35, 0] = 0.9997673709;
            values[35, 1] = 0.9997759467;
            values[35, 2] = 0.9997842266;
            values[35, 3] = 0.9997922202;
            values[35, 4] = 0.9997999365;
            values[35, 5] = 0.9998073844;
            values[35, 6] = 0.9998145726;
            values[35, 7] = 0.9998215094;
            values[35, 8] = 0.9998282029;
            values[35, 9] = 0.999834661;

            values[36, 0] = 0.9998408914;
            values[36, 1] = 0.9998469015;
            values[36, 2] = 0.9998526985;
            values[36, 3] = 0.9998582894;
            values[36, 4] = 0.999863681;
            values[36, 5] = 0.9998688798;
            values[36, 6] = 0.9998738924;
            values[36, 7] = 0.9998787248;
            values[36, 8] = 0.999883383;
            values[36, 9] = 0.999887873;

            values[37, 0] = 0.9998922003;
            values[37, 1] = 0.9998963704;
            values[37, 2] = 0.9999003886;
            values[37, 3] = 0.9999042601;
            values[37, 4] = 0.9999079899;
            values[37, 5] = 0.9999115827;
            values[37, 6] = 0.9999150433;
            values[37, 7] = 0.9999183762;
            values[37, 8] = 0.9999215858;
            values[37, 9] = 0.9999246764;

            values[38, 0] = 0.999927652;
            values[38, 1] = 0.9999305166;
            values[38, 2] = 0.9999332742;
            values[38, 3] = 0.9999359284;
            values[38, 4] = 0.9999384828;
            values[38, 5] = 0.9999409411;
            values[38, 6] = 0.9999433065;
            values[38, 7] = 0.9999455823;
            values[38, 8] = 0.9999477718;
            values[38, 9] = 0.9999498779;

            values[39, 0] = 0.9999519037;
            values[39, 1] = 0.9999538519;
            values[39, 2] = 0.9999557255;
            values[39, 3] = 0.9999575271;
            values[39, 4] = 0.9999592592;
            values[39, 5] = 0.9999609244;
            values[39, 6] = 0.9999625251;
            values[39, 7] = 0.9999640637;
            values[39, 8] = 0.9999655424;
            values[39, 9] = 0.9999669634;

            values[40, 0] = 0.9999683288;
            values[40, 1] = 0.9999696406;
            values[40, 2] = 0.9999709009;
            values[40, 3] = 0.9999721116;
            values[40, 4] = 0.9999732744;
            values[40, 5] = 0.9999743912;
            values[40, 6] = 0.9999754636;
            values[40, 7] = 0.9999764934;
            values[40, 8] = 0.9999774821;
            values[40, 9] = 0.9999784313;

            values[41, 0] = 0.9999793425;
            values[41, 1] = 0.999980217;
            values[41, 2] = 0.9999810564;
            values[41, 3] = 0.9999818618;
            values[41, 4] = 0.9999826347;
            values[41, 5] = 0.9999833762;
            values[41, 6] = 0.9999840876;
            values[41, 7] = 0.99998477;
            values[41, 8] = 0.9999854245;
            values[41, 9] = 0.9999860523;

            values[42, 0] = 0.9999866543;
            values[42, 1] = 0.9999872315;
            values[42, 2] = 0.9999877849;
            values[42, 3] = 0.9999883154;
            values[42, 4] = 0.999988824;
            values[42, 5] = 0.9999893115;
            values[42, 6] = 0.9999897787;
            values[42, 7] = 0.9999902264;
            values[42, 8] = 0.9999906553;
            values[42, 9] = 0.9999910663;
        }
    }
}