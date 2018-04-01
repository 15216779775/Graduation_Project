using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarSys : MonoBehaviour {
    //private GameObject girlSource;//ziyuan 
    private GameObject girlTarget;//huanzhuangmubiao
    private Transform girlSourceTransform;
    private Dictionary<string, Dictionary<string, SkinnedMeshRenderer>>
        girlData = new Dictionary<string, Dictionary<string, SkinnedMeshRenderer>>();//mmingzi bianhao skinedmeshrenderer
    private Dictionary<string, SkinnedMeshRenderer> girlSmr= new Dictionary<string, SkinnedMeshRenderer>();//目标guge 的 信息
    //字典存储信息  buwei smr
    Transform[] girlHips;//gugexinxio 
    private string[,] girlstr = new string[,] { { "eyes","1"},
                                                {"hair","1" },
                                                { "top","1"},
                                                { "pants","1"},
                                                { "shoes","1"},
                                                {"face","1" } };

    private GameObject boyTarget;//huanzhuangmubiao
    private Transform boySourceTransform;
    private Dictionary<string, Dictionary<string, SkinnedMeshRenderer>>
        boyData = new Dictionary<string, Dictionary<string, SkinnedMeshRenderer>>();//mmingzi bianhao skinedmeshrenderer
    private Dictionary<string, SkinnedMeshRenderer> boySmr = new Dictionary<string, SkinnedMeshRenderer>();//目标guge 的 信息
    //字典存储信息  buwei smr
    Transform[] boyHips;//gugexinxio 
    private string[,] boystr = new string[,] { { "eyes","1"},
                                                {"hair","1" },
                                                { "top","1"},
                                                { "pants","1"},
                                                { "shoes","1"},
                                                {"face","1" } };
    // Use this for initialization
    void Start () {
        //initGirl(); 
        initBoy();
	}
    void initGirl()
    {
        instaniateGirlAvatar();
        saveDate(girlSourceTransform,girlData,girlTarget,girlSmr);
        initAvatar();
    }
    void initBoy()
    {
        instaniateBoyAvatar();
        saveDate(boySourceTransform, boyData, boyTarget, boySmr);
        initBoyAvatar();
    }
    void instaniateGirlAvatar()
    {
        GameObject go = Instantiate(Resources.Load("FemaleModel")) as GameObject;//加载资源
        girlSourceTransform = go.transform;
        go.SetActive(false);
        girlTarget = Instantiate(Resources.Load("FemaleTarget")) as GameObject;
        girlHips = girlTarget.GetComponentsInChildren<Transform>();
        //InstantiateSources();
        //InstantiateTarget();
    }
    void instaniateBoyAvatar()
    {
        GameObject go = Instantiate(Resources.Load("MaleModel")) as GameObject;//加载资源
        boySourceTransform = go.transform;
        go.SetActive(false);
        boyTarget = Instantiate(Resources.Load("MaleTarget")) as GameObject;
        boyHips = boyTarget.GetComponentsInChildren<Transform>();
        //InstantiateSources();
        //InstantiateTarget();
    }

    void saveDate(Transform sourceTransform,
                  Dictionary<string, Dictionary<string, SkinnedMeshRenderer>> data,
                  GameObject target,
                  Dictionary<string, SkinnedMeshRenderer> smr)
    {
        if (sourceTransform== null)
        {
            return;
        }
        SkinnedMeshRenderer[] parts = sourceTransform.GetComponentsInChildren<SkinnedMeshRenderer>();
        foreach (var part in parts)
        {
            string[] names = part.name.Split('-');
            //if (names[0] = )
            if (! data.ContainsKey(names[0]))//确保一个部位之声层一次
            {
                //声称对应的部位
                GameObject partGo = new GameObject();
                partGo.name = names[0];
                partGo.transform.parent = target.transform;

                smr.Add(names[0],partGo.AddComponent<SkinnedMeshRenderer>());//吧骨骼target的信息存储到skm信息

                data.Add(names[0],new Dictionary<string, SkinnedMeshRenderer>());

            }
            data[names[0]].Add(names[1], part);//存储所有的skinedmeshrennder信息
        }
    }
    void changeMesh(string part, string num,
                    Dictionary<string, Dictionary<string, SkinnedMeshRenderer>> data,
                    Transform[] hips,
                    Dictionary<string, SkinnedMeshRenderer> smr)//部位与编号
    {
        SkinnedMeshRenderer skm = data[part][num];//要更换的部位 
        List<Transform> bones = new List<Transform>();
        foreach (var trans in skm.bones)//如果一个骨骼既存在于要更换的部位中，有存在于target的骨骼中，name他就是要被更换的骨骼
        {
            foreach (var bone in hips)
            {
                if (bone.name == trans.name)
                {
                    bones.Add(bone);
                    break;
                }
            }
        }
        //huanzhuang shixian  guge caizhi mesh
        smr[part].bones = bones.ToArray();
        smr[part].material = skm.material;
        smr[part].sharedMesh = skm.sharedMesh;
    }
        
    void initAvatar()
    {
        int length = girlstr.GetLength(0);
        if (length == 0) return;
        for (int i=0;i<length;i++)
        {
            changeMesh(girlstr[i,0],girlstr[i,1],girlData,girlHips,girlSmr);
        }
    }
    void initBoyAvatar()
    {
        int length = boystr.GetLength(0);
        if (length == 0) return;
        for (int i = 0; i < length; i++)
        {
            changeMesh(boystr[i, 0], boystr[i, 1], boyData, boyHips, boySmr);
        }
    }
    // Update is called once per frame
    void Update () {
        //if (Input.GetMouseButtonDown(0))
        //{
          //  changeMesh("top",Random.Range(1,7).ToString(), girlData, girlHips, girlSmr);
        //}
	}
}
