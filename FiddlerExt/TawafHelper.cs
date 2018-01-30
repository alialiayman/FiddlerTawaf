using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Fiddler;

namespace onSoft
{
	public class TawafHelper
	{


		public TawafHelper()
		{

		}




		public Dictionary<string,string> GetTawafConfig(Session[] oSessions)
		{
			var output = new Dictionary<string,string>();
			foreach (var sess in oSessions)
			{
				if (sess.RequestMethod != "POST") continue;

				if (sess.fullUrl.ToLower() == "http://www.tawaf.com.sa/tawaf39/etawaf/rep_mofa")
				{
					//7|0|24|http://www.tawaf.com.sa/tawaf39/etawaf/|9EDD59606C05E3031439EADA3FEE5CBE|com.gwt.umra.client.async.Rep_Mofa_Service|getListData|com.gwt.umra.shared.wrapper.Rep_Mofa_Wrapper/2949375434|java.util.ArrayList/4159755760|java.lang.String/2004016611|Group Code|,|Group Name|Mutamer Code|Mutamer Name|Mofa No|Gender|Date of Birth|Nationality|Passport No|Dependant|Mahram|Serial No|Relation|MOI No|
					//|from  Rep_Mofa where group_no in(8696) order by nvl(nvl(m_parent_code,m_mahram_code),mut_code),m_gender,m_dpn_serial_no |1|2|3|4|1|5|5|0|6|28|7|8|7|9|7|10|-4|7|11|-4|7|12|-4|7|13|-4|7|14|-4|7|15|-4|7|16|-4|7|17|-4|7|18|-4|7|19|-4|7|20|-4|7|21|-4|7|22|7|23|0|0|50|24|0|0|0|


                    var mtch = Regex.Match(sess.GetRequestBodyAsString(), @"http://www.tawaf.com.sa/tawaf39/etawaf/\|(.*?)\|com.gwt.umra.client.async.Rep_Mofa_Service\|getListData\|(.*?)\|(.*?)\|(.*)\|Group Code\|,");
					if (mtch.Success)
					{
						output.Add("Rep_Mofa_BoxVer",mtch.Groups[1].ToString());
						output.Add("Rep_Mofa_Wrapper",mtch.Groups[2].ToString());
						output.Add("javautilArrayList",mtch.Groups[3].ToString());
						output.Add("javalangString",mtch.Groups[4].ToString());
					}
					//7|0|24|http://www.tawaf.com.sa/tawaf39/etawaf/|{Rep_Mofa_BoxVer}|com.gwt.umra.client.async.Rep_Mofa_Service|getListData|{Rep_Mofa_Wrapper}|{javautilArrayList}|{javalangString}|Group Code|,|Group Name|Mutamer Code|Mutamer Name|Mofa No|Gender|Date of Birth|Nationality|Passport No|Dependant|Mahram|Serial No|Relation|MOI No|
					//|from  Rep_Mofa where group_no in(8696) order by nvl(nvl(m_parent_code,m_mahram_code),mut_code),m_gender,m_dpn_serial_no |1|2|3|4|1|5|5|0|6|28|7|8|7|9|7|10|-4|7|11|-4|7|12|-4|7|13|-4|7|14|-4|7|15|-4|7|16|-4|7|17|-4|7|18|-4|7|19|-4|7|20|-4|7|21|-4|7|22|7|23|0|0|50|24|0|0|0|

				}
				else if (sess.fullUrl == "http://www.tawaf.com.sa/tawaf39/etawaf/V_Mut_Groups")
				{

					//7|0|6|http://www.tawaf.com.sa/tawaf39/etawaf/|0E955BD11DE0B65567E272F50C88C8E9|com.gwt.umra.client.async.V_Mut_Groups_Service|getTableData|com.gwt.umra.shared.wrapper.V_Mut_Groups_Wrapper/1672639591|from V_Mut_Groups where 1=1 AND grp_status=10 AND uo_code = 165  AND uo_code=165 AND uo_branch_code=0 AND ea_code=7147 AND grp_arch=0|1|2|3|4|1|5|5|0|0|0|0|0|0|20|6|0|0|0|0|0|

					 var mtch = Regex.Match(sess.GetRequestBodyAsString(),@"http://www.tawaf.com.sa/tawaf39/etawaf/\|(.*?)\|com.gwt.umra.client.async.V_Mut_Groups_Service\|getTableData\|(.*?)\|");
					if (mtch.Success)
					{
						output.Add("v_Mut_Groups_CodeToGetGroups",mtch.Groups[1].ToString());
						output.Add("V_Mut_Groups_Wrapper",mtch.Groups[2].ToString());
                        foreach (var head in sess.RequestHeaders)
                        {
                            if (head.Name.ToLower() == "x-gwt-permutation") 
                            {
                                output.Add("ThirtyTwoCode", head.Value);
                                break;
                            }
                        }
						
					}
					//7|0|6|http://www.tawaf.com.sa/tawaf39/etawaf/|{v_Mut_Groups_CodeToGetGroups}|com.gwt.umra.client.async.V_Mut_Groups_Service|getTableData|{V_Mut_Groups_Wrapper}|from V_Mut_Groups where 1=1 AND grp_status=10 AND uo_code = 165  AND uo_code=165 AND uo_branch_code=0 AND ea_code=7147 AND grp_arch=0|1|2|3|4|1|5|5|0|0|0|0|0|0|20|6|0|0|0|0|0|

				}
			}

			return output;
		}

	   
	}
}