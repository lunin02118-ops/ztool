using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;

namespace ZTool.My;

[StandardModule]
[HideModuleName]
[GeneratedCode("MyTemplate", "10.0.0.0")]
internal sealed class MyProject
{
	[MyGroupCollection("System.Windows.Forms.Form", "Create__Instance__", "Dispose__Instance__", "My.MyProject.Forms")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	internal sealed class MyForms
	{
		public CheckUpdate m_CheckUpdate;

		public DGVPrinter m_DGVPrinter;

		public frm_copyswfile m_frm_copyswfile;

		public FrmAbout m_FrmAbout;

		public FrmAsk m_FrmAsk;

		public Frmbom m_Frmbom;

		public Frmbomset m_Frmbomset;

		public Frmcompare m_Frmcompare;

		public FrmCopy m_FrmCopy;

		public Frmcustomsort m_Frmcustomsort;

		public Frmexchangecol m_Frmexchangecol;

		public Frmexportbom m_Frmexportbom;

		public FrmFileList m_FrmFileList;

		public FrmFilling m_FrmFilling;

		public FrmFilterrules m_FrmFilterrules;

		public Frmmain m_Frmmain;

		public Frmmapping m_Frmmapping;

		public Frmmerge_split_pdf m_Frmmerge_split_pdf;

		public FrmOptions m_FrmOptions;

		public FrmOutputlist m_FrmOutputlist;

		public FrmOutputoptions m_FrmOutputoptions;

		public FrmPreview m_FrmPreview;

		public FrmPrintlist m_FrmPrintlist;

		public FrmPrintoptions m_FrmPrintoptions;

		public FrmRename m_FrmRename;

		public FrmReplace m_FrmReplace;

		public FrmReplacePartslist m_FrmReplacePartslist;

		public FrmRg m_FrmRg;

		public FrmRverify m_FrmRverify;

		public FrmSaveOption m_FrmSaveOption;

		public FrmSelType m_FrmSelType;

		public FrmSelType2 m_FrmSelType2;

		public FrmSetDrwlist m_FrmSetDrwlist;

		public FrmSetDrwOption m_FrmSetDrwOption;

		public FrmSetNewFolder m_FrmSetNewFolder;

		public Frmsetpropname m_Frmsetpropname;

		public FrmSplitcloumn m_FrmSplitcloumn;

		public FrmSuffixes m_FrmSuffixes;

		public FrmSWUnit m_FrmSWUnit;

		public Frmsymbol m_Frmsymbol;

		public FrmSyncDrwName m_FrmSyncDrwName;

		public Frmtips m_Frmtips;

		public FrmUpdatelog m_FrmUpdatelog;

		public SWList m_SWList;

		public toolbox m_toolbox;

		[ThreadStatic]
		private static Hashtable m_FormBeingCreated;

		public CheckUpdate CheckUpdate
		{
			[DebuggerNonUserCode]
			get
			{
				m_CheckUpdate = Create__Instance__(m_CheckUpdate);
				return m_CheckUpdate;
			}
			[DebuggerNonUserCode]
			set
			{
				if (value != m_CheckUpdate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_CheckUpdate);
				}
			}
		}

		public DGVPrinter DGVPrinter
		{
			[DebuggerNonUserCode]
			get
			{
				m_DGVPrinter = Create__Instance__(m_DGVPrinter);
				return m_DGVPrinter;
			}
			[DebuggerNonUserCode]
			set
			{
				if (value != m_DGVPrinter)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_DGVPrinter);
				}
			}
		}

		public frm_copyswfile frm_copyswfile
		{
			[DebuggerNonUserCode]
			get
			{
				m_frm_copyswfile = Create__Instance__(m_frm_copyswfile);
				return m_frm_copyswfile;
			}
			[DebuggerNonUserCode]
			set
			{
				if (value != m_frm_copyswfile)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_frm_copyswfile);
				}
			}
		}

		public FrmAbout FrmAbout
		{
			[DebuggerNonUserCode]
			get
			{
				m_FrmAbout = Create__Instance__(m_FrmAbout);
				return m_FrmAbout;
			}
			[DebuggerNonUserCode]
			set
			{
				if (value != m_FrmAbout)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_FrmAbout);
				}
			}
		}

		public FrmAsk FrmAsk
		{
			[DebuggerNonUserCode]
			get
			{
				m_FrmAsk = Create__Instance__(m_FrmAsk);
				return m_FrmAsk;
			}
			[DebuggerNonUserCode]
			set
			{
				if (value != m_FrmAsk)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_FrmAsk);
				}
			}
		}

		public Frmbom Frmbom
		{
			[DebuggerNonUserCode]
			get
			{
				m_Frmbom = Create__Instance__(m_Frmbom);
				return m_Frmbom;
			}
			[DebuggerNonUserCode]
			set
			{
				if (value != m_Frmbom)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_Frmbom);
				}
			}
		}

		public Frmbomset Frmbomset
		{
			[DebuggerNonUserCode]
			get
			{
				m_Frmbomset = Create__Instance__(m_Frmbomset);
				return m_Frmbomset;
			}
			[DebuggerNonUserCode]
			set
			{
				if (value != m_Frmbomset)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_Frmbomset);
				}
			}
		}

		public Frmcompare Frmcompare
		{
			[DebuggerNonUserCode]
			get
			{
				m_Frmcompare = Create__Instance__(m_Frmcompare);
				return m_Frmcompare;
			}
			[DebuggerNonUserCode]
			set
			{
				if (value != m_Frmcompare)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_Frmcompare);
				}
			}
		}

		public FrmCopy FrmCopy
		{
			[DebuggerNonUserCode]
			get
			{
				m_FrmCopy = Create__Instance__(m_FrmCopy);
				return m_FrmCopy;
			}
			[DebuggerNonUserCode]
			set
			{
				if (value != m_FrmCopy)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_FrmCopy);
				}
			}
		}

		public Frmcustomsort Frmcustomsort
		{
			[DebuggerNonUserCode]
			get
			{
				m_Frmcustomsort = Create__Instance__(m_Frmcustomsort);
				return m_Frmcustomsort;
			}
			[DebuggerNonUserCode]
			set
			{
				if (value != m_Frmcustomsort)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_Frmcustomsort);
				}
			}
		}

		public Frmexchangecol Frmexchangecol
		{
			[DebuggerNonUserCode]
			get
			{
				m_Frmexchangecol = Create__Instance__(m_Frmexchangecol);
				return m_Frmexchangecol;
			}
			[DebuggerNonUserCode]
			set
			{
				if (value != m_Frmexchangecol)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_Frmexchangecol);
				}
			}
		}

		public Frmexportbom Frmexportbom
		{
			[DebuggerNonUserCode]
			get
			{
				m_Frmexportbom = Create__Instance__(m_Frmexportbom);
				return m_Frmexportbom;
			}
			[DebuggerNonUserCode]
			set
			{
				if (value != m_Frmexportbom)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_Frmexportbom);
				}
			}
		}

		public FrmFileList FrmFileList
		{
			[DebuggerNonUserCode]
			get
			{
				m_FrmFileList = Create__Instance__(m_FrmFileList);
				return m_FrmFileList;
			}
			[DebuggerNonUserCode]
			set
			{
				if (value != m_FrmFileList)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_FrmFileList);
				}
			}
		}

		public FrmFilling FrmFilling
		{
			[DebuggerNonUserCode]
			get
			{
				m_FrmFilling = Create__Instance__(m_FrmFilling);
				return m_FrmFilling;
			}
			[DebuggerNonUserCode]
			set
			{
				if (value != m_FrmFilling)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_FrmFilling);
				}
			}
		}

		public FrmFilterrules FrmFilterrules
		{
			[DebuggerNonUserCode]
			get
			{
				m_FrmFilterrules = Create__Instance__(m_FrmFilterrules);
				return m_FrmFilterrules;
			}
			[DebuggerNonUserCode]
			set
			{
				if (value != m_FrmFilterrules)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_FrmFilterrules);
				}
			}
		}

		public Frmmain Frmmain
		{
			[DebuggerNonUserCode]
			get
			{
				m_Frmmain = Create__Instance__(m_Frmmain);
				return m_Frmmain;
			}
			[DebuggerNonUserCode]
			set
			{
				if (value != m_Frmmain)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_Frmmain);
				}
			}
		}

		public Frmmapping Frmmapping
		{
			[DebuggerNonUserCode]
			get
			{
				m_Frmmapping = Create__Instance__(m_Frmmapping);
				return m_Frmmapping;
			}
			[DebuggerNonUserCode]
			set
			{
				if (value != m_Frmmapping)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_Frmmapping);
				}
			}
		}

		public Frmmerge_split_pdf Frmmerge_split_pdf
		{
			[DebuggerNonUserCode]
			get
			{
				m_Frmmerge_split_pdf = Create__Instance__(m_Frmmerge_split_pdf);
				return m_Frmmerge_split_pdf;
			}
			[DebuggerNonUserCode]
			set
			{
				if (value != m_Frmmerge_split_pdf)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_Frmmerge_split_pdf);
				}
			}
		}

		public FrmOptions FrmOptions
		{
			[DebuggerNonUserCode]
			get
			{
				m_FrmOptions = Create__Instance__(m_FrmOptions);
				return m_FrmOptions;
			}
			[DebuggerNonUserCode]
			set
			{
				if (value != m_FrmOptions)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_FrmOptions);
				}
			}
		}

		public FrmOutputlist FrmOutputlist
		{
			[DebuggerNonUserCode]
			get
			{
				m_FrmOutputlist = Create__Instance__(m_FrmOutputlist);
				return m_FrmOutputlist;
			}
			[DebuggerNonUserCode]
			set
			{
				if (value != m_FrmOutputlist)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_FrmOutputlist);
				}
			}
		}

		public FrmOutputoptions FrmOutputoptions
		{
			[DebuggerNonUserCode]
			get
			{
				m_FrmOutputoptions = Create__Instance__(m_FrmOutputoptions);
				return m_FrmOutputoptions;
			}
			[DebuggerNonUserCode]
			set
			{
				if (value != m_FrmOutputoptions)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_FrmOutputoptions);
				}
			}
		}

		public FrmPreview FrmPreview
		{
			[DebuggerNonUserCode]
			get
			{
				m_FrmPreview = Create__Instance__(m_FrmPreview);
				return m_FrmPreview;
			}
			[DebuggerNonUserCode]
			set
			{
				if (value != m_FrmPreview)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_FrmPreview);
				}
			}
		}

		public FrmPrintlist FrmPrintlist
		{
			[DebuggerNonUserCode]
			get
			{
				m_FrmPrintlist = Create__Instance__(m_FrmPrintlist);
				return m_FrmPrintlist;
			}
			[DebuggerNonUserCode]
			set
			{
				if (value != m_FrmPrintlist)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_FrmPrintlist);
				}
			}
		}

		public FrmPrintoptions FrmPrintoptions
		{
			[DebuggerNonUserCode]
			get
			{
				m_FrmPrintoptions = Create__Instance__(m_FrmPrintoptions);
				return m_FrmPrintoptions;
			}
			[DebuggerNonUserCode]
			set
			{
				if (value != m_FrmPrintoptions)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_FrmPrintoptions);
				}
			}
		}

		public FrmRename FrmRename
		{
			[DebuggerNonUserCode]
			get
			{
				m_FrmRename = Create__Instance__(m_FrmRename);
				return m_FrmRename;
			}
			[DebuggerNonUserCode]
			set
			{
				if (value != m_FrmRename)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_FrmRename);
				}
			}
		}

		public FrmReplace FrmReplace
		{
			[DebuggerNonUserCode]
			get
			{
				m_FrmReplace = Create__Instance__(m_FrmReplace);
				return m_FrmReplace;
			}
			[DebuggerNonUserCode]
			set
			{
				if (value != m_FrmReplace)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_FrmReplace);
				}
			}
		}

		public FrmReplacePartslist FrmReplacePartslist
		{
			[DebuggerNonUserCode]
			get
			{
				m_FrmReplacePartslist = Create__Instance__(m_FrmReplacePartslist);
				return m_FrmReplacePartslist;
			}
			[DebuggerNonUserCode]
			set
			{
				if (value != m_FrmReplacePartslist)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_FrmReplacePartslist);
				}
			}
		}

		public FrmRg FrmRg
		{
			[DebuggerNonUserCode]
			get
			{
				m_FrmRg = Create__Instance__(m_FrmRg);
				return m_FrmRg;
			}
			[DebuggerNonUserCode]
			set
			{
				if (value != m_FrmRg)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_FrmRg);
				}
			}
		}

		public FrmRverify FrmRverify
		{
			[DebuggerNonUserCode]
			get
			{
				m_FrmRverify = Create__Instance__(m_FrmRverify);
				return m_FrmRverify;
			}
			[DebuggerNonUserCode]
			set
			{
				if (value != m_FrmRverify)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_FrmRverify);
				}
			}
		}

		public FrmSaveOption FrmSaveOption
		{
			[DebuggerNonUserCode]
			get
			{
				m_FrmSaveOption = Create__Instance__(m_FrmSaveOption);
				return m_FrmSaveOption;
			}
			[DebuggerNonUserCode]
			set
			{
				if (value != m_FrmSaveOption)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_FrmSaveOption);
				}
			}
		}

		public FrmSelType FrmSelType
		{
			[DebuggerNonUserCode]
			get
			{
				m_FrmSelType = Create__Instance__(m_FrmSelType);
				return m_FrmSelType;
			}
			[DebuggerNonUserCode]
			set
			{
				if (value != m_FrmSelType)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_FrmSelType);
				}
			}
		}

		public FrmSelType2 FrmSelType2
		{
			[DebuggerNonUserCode]
			get
			{
				m_FrmSelType2 = Create__Instance__(m_FrmSelType2);
				return m_FrmSelType2;
			}
			[DebuggerNonUserCode]
			set
			{
				if (value != m_FrmSelType2)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_FrmSelType2);
				}
			}
		}

		public FrmSetDrwlist FrmSetDrwlist
		{
			[DebuggerNonUserCode]
			get
			{
				m_FrmSetDrwlist = Create__Instance__(m_FrmSetDrwlist);
				return m_FrmSetDrwlist;
			}
			[DebuggerNonUserCode]
			set
			{
				if (value != m_FrmSetDrwlist)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_FrmSetDrwlist);
				}
			}
		}

		public FrmSetDrwOption FrmSetDrwOption
		{
			[DebuggerNonUserCode]
			get
			{
				m_FrmSetDrwOption = Create__Instance__(m_FrmSetDrwOption);
				return m_FrmSetDrwOption;
			}
			[DebuggerNonUserCode]
			set
			{
				if (value != m_FrmSetDrwOption)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_FrmSetDrwOption);
				}
			}
		}

		public FrmSetNewFolder FrmSetNewFolder
		{
			[DebuggerNonUserCode]
			get
			{
				m_FrmSetNewFolder = Create__Instance__(m_FrmSetNewFolder);
				return m_FrmSetNewFolder;
			}
			[DebuggerNonUserCode]
			set
			{
				if (value != m_FrmSetNewFolder)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_FrmSetNewFolder);
				}
			}
		}

		public Frmsetpropname Frmsetpropname
		{
			[DebuggerNonUserCode]
			get
			{
				m_Frmsetpropname = Create__Instance__(m_Frmsetpropname);
				return m_Frmsetpropname;
			}
			[DebuggerNonUserCode]
			set
			{
				if (value != m_Frmsetpropname)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_Frmsetpropname);
				}
			}
		}

		public FrmSplitcloumn FrmSplitcloumn
		{
			[DebuggerNonUserCode]
			get
			{
				m_FrmSplitcloumn = Create__Instance__(m_FrmSplitcloumn);
				return m_FrmSplitcloumn;
			}
			[DebuggerNonUserCode]
			set
			{
				if (value != m_FrmSplitcloumn)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_FrmSplitcloumn);
				}
			}
		}

		public FrmSuffixes FrmSuffixes
		{
			[DebuggerNonUserCode]
			get
			{
				m_FrmSuffixes = Create__Instance__(m_FrmSuffixes);
				return m_FrmSuffixes;
			}
			[DebuggerNonUserCode]
			set
			{
				if (value != m_FrmSuffixes)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_FrmSuffixes);
				}
			}
		}

		public FrmSWUnit FrmSWUnit
		{
			[DebuggerNonUserCode]
			get
			{
				m_FrmSWUnit = Create__Instance__(m_FrmSWUnit);
				return m_FrmSWUnit;
			}
			[DebuggerNonUserCode]
			set
			{
				if (value != m_FrmSWUnit)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_FrmSWUnit);
				}
			}
		}

		public Frmsymbol Frmsymbol
		{
			[DebuggerNonUserCode]
			get
			{
				m_Frmsymbol = Create__Instance__(m_Frmsymbol);
				return m_Frmsymbol;
			}
			[DebuggerNonUserCode]
			set
			{
				if (value != m_Frmsymbol)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_Frmsymbol);
				}
			}
		}

		public FrmSyncDrwName FrmSyncDrwName
		{
			[DebuggerNonUserCode]
			get
			{
				m_FrmSyncDrwName = Create__Instance__(m_FrmSyncDrwName);
				return m_FrmSyncDrwName;
			}
			[DebuggerNonUserCode]
			set
			{
				if (value != m_FrmSyncDrwName)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_FrmSyncDrwName);
				}
			}
		}

		public Frmtips Frmtips
		{
			[DebuggerNonUserCode]
			get
			{
				m_Frmtips = Create__Instance__(m_Frmtips);
				return m_Frmtips;
			}
			[DebuggerNonUserCode]
			set
			{
				if (value != m_Frmtips)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_Frmtips);
				}
			}
		}

		public FrmUpdatelog FrmUpdatelog
		{
			[DebuggerNonUserCode]
			get
			{
				m_FrmUpdatelog = Create__Instance__(m_FrmUpdatelog);
				return m_FrmUpdatelog;
			}
			[DebuggerNonUserCode]
			set
			{
				if (value != m_FrmUpdatelog)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_FrmUpdatelog);
				}
			}
		}

		public SWList SWList
		{
			[DebuggerNonUserCode]
			get
			{
				m_SWList = Create__Instance__(m_SWList);
				return m_SWList;
			}
			[DebuggerNonUserCode]
			set
			{
				if (value != m_SWList)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_SWList);
				}
			}
		}

		public toolbox toolbox
		{
			[DebuggerNonUserCode]
			get
			{
				m_toolbox = Create__Instance__(m_toolbox);
				return m_toolbox;
			}
			[DebuggerNonUserCode]
			set
			{
				if (value != m_toolbox)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_toolbox);
				}
			}
		}

		[DebuggerHidden]
		private static T Create__Instance__<T>(T Instance) where T : Form, new()
		{
			if (Instance == null || (Instance.IsDisposed ? true : false))
			{
				if (m_FormBeingCreated != null)
				{
					if (m_FormBeingCreated.ContainsKey(typeof(T)))
					{
						throw new InvalidOperationException(Utils.GetResourceString("WinForms_RecursiveFormCreate"));
					}
				}
				else
				{
					m_FormBeingCreated = new Hashtable();
				}
				m_FormBeingCreated.Add(typeof(T), null);
				try
				{
					return new T();
				}
				catch (TargetInvocationException ex) when (((Func<bool>)delegate
				{
					// Could not convert BlockContainer to single expression
					ProjectData.SetProjectError(ex);
					return ex.InnerException != null;
				}).Invoke())
				{
					string resourceString = Utils.GetResourceString("WinForms_SeeInnerException", ex.InnerException.Message);
					throw new InvalidOperationException(resourceString, ex.InnerException);
				}
				finally
				{
					m_FormBeingCreated.Remove(typeof(T));
				}
			}
			return Instance;
		}

		[DebuggerHidden]
		private void Dispose__Instance__<T>(ref T instance) where T : Form
		{
			instance.Dispose();
			instance = null;
		}

		[DebuggerHidden]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public MyForms()
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override bool Equals(object o)
		{
			return base.Equals(RuntimeHelpers.GetObjectValue(o));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		internal new Type GetType()
		{
			return typeof(MyForms);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override string ToString()
		{
			return base.ToString();
		}
	}

	[MyGroupCollection("System.Web.Services.Protocols.SoapHttpClientProtocol", "Create__Instance__", "Dispose__Instance__", "")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	internal sealed class MyWebServices
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerHidden]
		public override bool Equals(object o)
		{
			return base.Equals(RuntimeHelpers.GetObjectValue(o));
		}

		[DebuggerHidden]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerHidden]
		internal new Type GetType()
		{
			return typeof(MyWebServices);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerHidden]
		public override string ToString()
		{
			return base.ToString();
		}

		[DebuggerHidden]
		private static T Create__Instance__<T>(T instance) where T : new()
		{
			if (instance == null)
			{
				return new T();
			}
			return instance;
		}

		[DebuggerHidden]
		private void Dispose__Instance__<T>(ref T instance)
		{
			instance = default(T);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerHidden]
		public MyWebServices()
		{
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(false)]
	internal sealed class ThreadSafeObjectProvider<T> where T : new()
	{
		[ThreadStatic]
		[CompilerGenerated]
		private static T m_ThreadStaticValue;

		internal T GetInstance
		{
			[DebuggerHidden]
			get
			{
				if (m_ThreadStaticValue == null)
				{
					m_ThreadStaticValue = new T();
				}
				return m_ThreadStaticValue;
			}
		}

		[DebuggerHidden]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public ThreadSafeObjectProvider()
		{
		}
	}

	private static readonly ThreadSafeObjectProvider<MyComputer> m_ComputerObjectProvider = new ThreadSafeObjectProvider<MyComputer>();

	private static readonly ThreadSafeObjectProvider<MyApplication> m_AppObjectProvider = new ThreadSafeObjectProvider<MyApplication>();

	private static readonly ThreadSafeObjectProvider<User> m_UserObjectProvider = new ThreadSafeObjectProvider<User>();

	private static ThreadSafeObjectProvider<MyForms> m_MyFormsObjectProvider = new ThreadSafeObjectProvider<MyForms>();

	private static readonly ThreadSafeObjectProvider<MyWebServices> m_MyWebServicesObjectProvider = new ThreadSafeObjectProvider<MyWebServices>();

	[HelpKeyword("My.Computer")]
	internal static MyComputer Computer
	{
		[DebuggerHidden]
		get
		{
			return m_ComputerObjectProvider.GetInstance;
		}
	}

	[HelpKeyword("My.Application")]
	internal static MyApplication Application
	{
		[DebuggerHidden]
		get
		{
			return m_AppObjectProvider.GetInstance;
		}
	}

	[HelpKeyword("My.User")]
	internal static User User
	{
		[DebuggerHidden]
		get
		{
			return m_UserObjectProvider.GetInstance;
		}
	}

	[HelpKeyword("My.Forms")]
	internal static MyForms Forms
	{
		[DebuggerHidden]
		get
		{
			return m_MyFormsObjectProvider.GetInstance;
		}
	}

	[HelpKeyword("My.WebServices")]
	internal static MyWebServices WebServices
	{
		[DebuggerHidden]
		get
		{
			return m_MyWebServicesObjectProvider.GetInstance;
		}
	}
}
