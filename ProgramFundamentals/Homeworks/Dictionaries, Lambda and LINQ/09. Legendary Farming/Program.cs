using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, int> keyMaterials = new SortedDictionary<string, int>();
            SortedDictionary<string, int> junkMaterials = new SortedDictionary<string, int>();
            keyMaterials.Add("fragments", 0);
            keyMaterials.Add("motes", 0);
            keyMaterials.Add("shards", 0);
            bool isntEnough = true;
            string neededMaterial = "";
            
            while (isntEnough)
            {
                string[] materials = Console.ReadLine().ToLower().Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries).ToArray();
                //Console.WriteLine(String.Join(" ",materials));                
                for (int i = 0; i < materials.Length; i=i+2)
                {
                    int quantity = int.Parse(materials[i]);
                    string material = materials[i+1];
                    if (material == "fragments" || material == "motes" || material == "shards")
                    {
                        keyMaterials[material] += quantity;
                        if (keyMaterials[material]>=250)
                        {
                            isntEnough = false;
                            keyMaterials[material] -= 250;
                            neededMaterial = material;
                            break;
                        }
                    }
                    else
                    {
                        if (!junkMaterials.ContainsKey(material))
                        {
                            junkMaterials.Add(material, quantity);
                        }
                        else
                        {
                            junkMaterials[material] += quantity;
                        }
                    }
                }
                //foreach (var item in keyMaterials)
                //{
                //    Console.WriteLine("{0}: {1}", item.Key, item.Value);
                //}
                //while (i<materials.Length-1) { 
                //    string material = materials[i];
                //    int quantity = int.Parse(materials[i-1]);
                //    if (material == "fragments"|| material == "motes" || material == "shards")
                //    {
                //        addMaterial(keyMaterials, material, quantity);
                //    }
                //    else
                //    {
                //        addMaterial(junkMaterials, material, quantity);
                //    }
                //    i = i + 2;
                //}

                //if (checkedForEnough(keyMaterials))
                //{
                //    break;
                //}               
            }
            //neededMaterial = checkForMaterial(keyMaterials);
            //keyMaterials[neededMaterial] -= 250;
            keyMaterials.OrderByDescending(x => x.Value);
            junkMaterials.OrderByDescending(x => x.Key);
            if (neededMaterial=="fragments")
            {
                Console.WriteLine("Valanyr obtained!");
            }
            else if(neededMaterial == "motes")
            {
                Console.WriteLine("Dragonwrath obtained!");
            }
            else if (neededMaterial == "shards")
            {
                Console.WriteLine("Shadowmourne obtained!");
            }
            foreach (var item in keyMaterials.OrderByDescending(x => x.Value))
            {
                Console.WriteLine("{0}: {1}",item.Key,item.Value);
            }
            foreach (var item in junkMaterials)
            {
                Console.WriteLine("{0}: {1}", item.Key, item.Value);
            }


        }

        private static bool checkedForEnough(SortedDictionary<string, int> keyMaterials)
        {

            foreach (var item in keyMaterials)
            {
                if (item.Value==250)
                {
                    return true;
                }
            }
            return false;
        }

        private static string checkForMaterial(SortedDictionary<string, int> keyMaterials)
        {
            string material = "";
            foreach (var item in keyMaterials)
            {
                if (item.Value == 250)
                {
                    material = item.Key;
                              
                    
                }
            }

            return material;
        }

        private static void addMaterial(SortedDictionary<string, int> Materials, string material, int quantity)
        {
            if (!Materials.ContainsKey(material))
            {
                Materials.Add(material, quantity);
            }
            else
            {
                Materials[material] += quantity;
            }
        }
    }
}
