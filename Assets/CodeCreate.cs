using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

/// <summary>
/// 创建代码测试
/// Author：Sun
/// Time:2019/5/29 23:59
/// </summary>
public class CodeCreate : MonoBehaviour
{

	/// <summary>
	/// 脚本名
	/// </summary>
	public string ScriptName;
	/// <summary>
	/// 命名空间
	/// </summary>
	public string NameSpace;
	/// <summary>
	/// 模板内容
	/// </summary>
	private string _templateContent;
	/// <summary>
	/// 模板路径
	/// </summary>
	private string _templatePath;
	/// <summary>
	/// 生成路径
	/// </summary>
	private string _spawnPath;
	
	private void Start()
	{
		_templatePath = "Assets/ScriptTemplate.cs";
		_spawnPath = "Assets/SpawnCode/";
		//读取模板内容
		_templateContent = File.ReadAllText(_templatePath);

	}

	private void OnGUI()
	{
		if (GUI.Button(new Rect(0,0,200,200),"创建模板脚本" ))
		{
			if (ScriptName!=null)
			{
				//生成路径
				var path = _spawnPath + ScriptName+".cs";
				//替换类名
				_templateContent = _templateContent.Replace("ScriptTemplate",ScriptName);

				if (NameSpace!=null)
				{
					//替换命名空间
					_templateContent = _templateContent.Replace("TemplateNameSpace",NameSpace);
				}
				//将组织好的内容写入文件
				File.WriteAllText(path, _templateContent, Encoding.UTF8);
				//刷新一下资源，不然创建好文件后第一时间不会显示
				AssetDatabase.Refresh();
			}
			else
			{
				Debug.LogWarning("文件名不能为空");
			}
		}
	}
}
