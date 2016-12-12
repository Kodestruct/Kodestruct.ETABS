#region Copyright
   /*Copyright (C) 2015 Konstantin Udilovich

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

   http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
   */
#endregion
 
 
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using Dynamo.Controls;
using Dynamo.Models;
using Dynamo.Wpf;
using ProtoCore.AST.AssociativeAST;
using System.Xml;
using Dynamo.Nodes;
using Dynamo.Graph;
using Dynamo.Graph.Nodes;
using Kodestruct.ETABS.Dynamo.Common;
using Kodestruct.ETABS.ModelOutput.Frame;
using GalaSoft.MvvmLight.Command;
using Kodestruct.ETABS.Interop.Entities.Group;
using Kodestruct.ETABS.Interop;
using System.Collections.ObjectModel;
using Kodestruct.ETABS.Interop.Entities.Frame.ForceExtraction;
using Kodestruct.ETABS.Interop.Entities.Frame;


namespace Kodestruct.ETABS.ModelOutput.Frame
{

    /// <summary>
    ///Group force at end extraction 
    /// </summary>

    [NodeName("Extract envelope frame end forces for group ")]
    [NodeCategory("Kodestruct.ETABS.ModelOutput.Frame")]
    [NodeDescription("Extract envelope frame end forces for group")]
    [IsDesignScriptCompatible]
    public class GroupReactionExtract : UiNodeBase
    {

        public GroupReactionExtract()
        {
            
            
            OutPortData.Add(new PortData("V_major_left","Major (strong axis) shear at the left end of frame member"));
            OutPortData.Add(new PortData("V_major_right","Major (strong axis) shear at the right end of frame member"));
            OutPortData.Add(new PortData("M_major_left","Major (strong axis) moment at the left end of frame member"));
            OutPortData.Add(new PortData("M_major_right","Major (strong axis) moment at the right end of frame member"));
            OutPortData.Add(new PortData("P_left","Axial force at the left end of frame member"));
            OutPortData.Add(new PortData("P_right","Axial force  at the right end of frame member"));
            OutPortData.Add(new PortData("V_minor_left","Minor (weak axis) shear at the left end of frame member"));
            OutPortData.Add(new PortData("V_minor_right","Minor (weak axis) shear at the right end of frame member"));
            OutPortData.Add(new PortData("M_minor_left","Minor (weak axis) moment at the left end of frame member"));
            OutPortData.Add(new PortData("M_minor_right","Minor (weak axis) moment at the right end of frame member"));

            RegisterAllPorts();
            SetDefaultParameters();

            RefreshCommand = new RelayCommand(RefreshEtabsData, canGetForces);
            GetReactionsCommand = new RelayCommand(GetReactions, canGetForces);
            //PropertyChanged += NodePropertyChanged;
        }



        private void SetDefaultParameters()
        {
            SelectedCombo = "Select combination from list";
            SelectedGroup = "Select group from list";

                V_major_left  =0.0;
                V_major_right =0.0;
                M_major_left  =0.0;
                M_major_right =0.0;
                P_left        =0.0;
                P_right       =0.0;
                V_minor_left  =0.0;
                V_minor_right =0.0;
                M_minor_left  =0.0;
                M_minor_right = 0.0;
                ErrorMessage = "";
        }



        /// <summary>
        ///     Gets the type of this class, to be used in base class for reflection
        /// </summary>
        protected override Type GetModelType()
        {
            return GetType();
        }

        #region properties

        #region InputProperties

        #region AvaliableCombosProperty
		
		/// <summary>
		/// AvaliableCombos property
		/// </summary>
		/// <value>AvaliableCombos</value>
        public ObservableCollection<string> _AvaliableCombos;

        public ObservableCollection<string> AvaliableCombos
		{
		    get { return _AvaliableCombos; }
		    set
		    {
		        _AvaliableCombos= value;
		        RaisePropertyChanged("AvaliableCombos");
		        //OnNodeModified(true); 
		    }
		}
		#endregion

        #region SelectedComboProperty
		
		/// <summary>
		/// SelectedCombo property
		/// </summary>
		/// <value>SelectedCombo</value>
		public string _SelectedCombo;
		
		public string SelectedCombo
		{
		    get { return _SelectedCombo; }
		    set
		    {
		        _SelectedCombo= value;
		        RaisePropertyChanged("SelectedCombo");
		        //OnNodeModified(true); 
		    }
		}
		#endregion

        #region ErrorMessageProperty

        /// <summary>
        /// ErrorMessage property
        /// </summary>
        /// <value>ErrorMessage</value>
        public string _ErrorMessage;

        public string ErrorMessage
        {
            get { return _ErrorMessage; }
            set
            {
                _ErrorMessage = value;
                RaisePropertyChanged("ErrorMessage");
                //OnNodeModified(true); 
            }
        }
        #endregion

        #region AvailableGroupsProperty
		
		/// <summary>
		/// AvailableGroups property
		/// </summary>
		/// <value>AvailableGroups</value>
		public ObservableCollection<string> _AvailableGroups;

        public ObservableCollection<string> AvailableGroups
		{
		    get { return _AvailableGroups; }
		    set
		    {
		        _AvailableGroups= value;
		        RaisePropertyChanged("AvailableGroups");
		        //OnNodeModified(true); 
		    }
		}
		#endregion

        #region SelectedGroupProperty
		
		/// <summary>
		/// SelectedGroup property
		/// </summary>  
		/// <value>SelectedGroup</value>
		public string _SelectedGroup;
		
		public string SelectedGroup
		{
		    get { return _SelectedGroup; }
		    set
		    {
		        _SelectedGroup= value;
		        RaisePropertyChanged("SelectedGroup");
		        //OnNodeModified(true); 
		    }
		}
		#endregion

	    #endregion

        #region OutputProperties


        #region V_major_leftProperty
		
		/// <summary>
		/// V_major_left property
		/// </summary>
		/// <value>V_major_left</value>
		public double _V_major_left;
		
		public double V_major_left
		{
		    get { return _V_major_left; }
		    set
		    {
		        _V_major_left= value;
		        RaisePropertyChanged("V_major_left");
		        OnNodeModified(true); 
		    }
		}
		#endregion

		#region V_major_rightProperty
		
		/// <summary>
		/// V_major_right property
		/// </summary>
		/// <value>V_major_right</value>
		public double _V_major_right;
		
		public double V_major_right
		{
		    get { return _V_major_right; }
		    set
		    {
		        _V_major_right= value;
		        RaisePropertyChanged("V_major_right");
		        OnNodeModified(true); 
		    }
		}
		#endregion

		#region M_major_leftProperty
		
		/// <summary>
		/// M_major_left property
		/// </summary>
		/// <value>M_major_left</value>
		public double _M_major_left;
		
		public double M_major_left
		{
		    get { return _M_major_left; }
		    set
		    {
		        _M_major_left= value;
		        RaisePropertyChanged("M_major_left");
		        OnNodeModified(true); 
		    }
		}
		#endregion

        #region M_major_rightProperty
		
		/// <summary>
		/// M_major_right property
		/// </summary>
		/// <value>M_major_right</value>
		public double _M_major_right;
		
		public double M_major_right
		{
		    get { return _M_major_right; }
		    set
		    {
		        _M_major_right= value;
		        RaisePropertyChanged("M_major_right");
		        OnNodeModified(true); 
		    }
		}
		#endregion

        #region P_leftProperty
		
		/// <summary>
		/// P_left property
		/// </summary>
		/// <value>P_left</value>
		public double _P_left;
		
		public double P_left
		{
		    get { return _P_left; }
		    set
		    {
		        _P_left= value;
		        RaisePropertyChanged("P_left");
		        OnNodeModified(true); 
		    }
		}
		#endregion

        #region P_rightProperty
		
		/// <summary>
		/// P_right property
		/// </summary>
		/// <value>P_right</value>
		public double _P_right;
		
		public double P_right
		{
		    get { return _P_right; }
		    set
		    {
		        _P_right= value;
		        RaisePropertyChanged("P_right");
		        OnNodeModified(true); 
		    }
		}
		#endregion

        #region V_minor_leftProperty
		
		/// <summary>
		/// V_minor_left property
		/// </summary>
		/// <value>V_minor_left</value>
		public double _V_minor_left;
		
		public double V_minor_left
		{
		    get { return _V_minor_left; }
		    set
		    {
		        _V_minor_left= value;
		        RaisePropertyChanged("V_minor_left");
		        OnNodeModified(true); 
		    }
		}
		#endregion

        #region V_minor_rightProperty
		
		/// <summary>
		/// V_minor_right property
		/// </summary>
		/// <value>V_minor_right</value>
		public double _V_minor_right;
		
		public double V_minor_right
		{
		    get { return _V_minor_right; }
		    set
		    {
		        _V_minor_right= value;
		        RaisePropertyChanged("V_minor_right");
		        OnNodeModified(true); 
		    }
		}
		#endregion

        #region M_minor_leftProperty
		
		/// <summary>
		/// M_minor_left property
		/// </summary>
		/// <value>M_minor_left</value>
		public double _M_minor_left;
		
		public double M_minor_left
		{
		    get { return _M_minor_left; }
		    set
		    {
		        _M_minor_left= value;
		        RaisePropertyChanged("M_minor_left");
		        OnNodeModified(true); 
		    }
		}
		#endregion

        #region M_minor_rightProperty
		
		/// <summary>
		/// M_minor_right property
		/// </summary>
		/// <value>M_minor_right</value>
		public double _M_minor_right;
		
		public double M_minor_right
		{
		    get { return _M_minor_right; }
		    set
		    {
		        _M_minor_right= value;
		        RaisePropertyChanged("M_minor_right");
		        OnNodeModified(true); 
		    }
		}
		#endregion

        #endregion
        #endregion

        #region Serialization

        /// <summary>
        ///Saves property values to be retained when opening the node     
        /// </summary>
        protected override void SerializeCore(XmlElement nodeElement, SaveContext context)
        {
            base.SerializeCore(nodeElement, context);
            //nodeElement.SetAttribute("BeamCopeCase", BeamCopeCase);
            nodeElement.SetAttribute("V_major_left", V_major_left.ToString());
            nodeElement.SetAttribute("V_major_right", V_major_right.ToString());
            nodeElement.SetAttribute("M_major_left", M_major_left.ToString());
            nodeElement.SetAttribute("M_major_right", M_major_right.ToString());
            nodeElement.SetAttribute("P_left", P_left.ToString());
            nodeElement.SetAttribute("P_right", P_right.ToString());
            nodeElement.SetAttribute("V_minor_left", V_minor_left.ToString());
            nodeElement.SetAttribute("V_minor_right", V_minor_right.ToString());
            nodeElement.SetAttribute("M_minor_left", M_minor_left.ToString());
            nodeElement.SetAttribute("M_minor_right", M_minor_right.ToString());


            nodeElement.SetAttribute("SelectedCombo", SelectedCombo);
            nodeElement.SetAttribute("SelectedGroup", SelectedGroup);
        }

        /// <summary>
        ///Retrieved property values when opening the node     
        /// </summary>
        protected override void DeserializeCore(XmlElement nodeElement, SaveContext context)
        {
            base.DeserializeCore(nodeElement, context);


            var attribV_major_left = nodeElement.Attributes["V_major_left"]; V_major_left = Double.Parse(attribV_major_left.Value);
            var attribV_major_right = nodeElement.Attributes["V_major_right"]; V_major_right = Double.Parse(attribV_major_right.Value);
            var attribM_major_left = nodeElement.Attributes["M_major_left"]; M_major_left = Double.Parse(attribM_major_left.Value);
            var attribM_major_right = nodeElement.Attributes["M_major_right"]; M_major_right = Double.Parse(attribM_major_right.Value);
            var attribP_left = nodeElement.Attributes["P_left"]; P_left = Double.Parse(attribP_left.Value);
            var attribP_right = nodeElement.Attributes["P_right"]; P_right = Double.Parse(attribP_right.Value);
            var attribV_minor_left = nodeElement.Attributes["V_minor_left"]; V_minor_left = Double.Parse(attribV_minor_left.Value);
            var attribV_minor_right = nodeElement.Attributes["V_minor_right"]; V_minor_right = Double.Parse(attribV_minor_right.Value);

            var attribM_minor_left = nodeElement.Attributes["M_minor_left"]; M_minor_left = Double.Parse(attribM_minor_left.Value);
            var attribM_minor_right = nodeElement.Attributes["M_minor_right"]; M_minor_right = Double.Parse(attribM_minor_right.Value);

            var attrSC = nodeElement.Attributes["SelectedCombo"]; SelectedCombo =attrSC.Value;
            var attrSG = nodeElement.Attributes["SelectedGroup"]; SelectedGroup = attrSG.Value;


        }


        #endregion

        #region Commands

       public RelayCommand RefreshCommand { get; private set; }
       public RelayCommand GetReactionsCommand { get; private set; }
        
        private void RefreshEtabsData()
        {
            ErrorMessage = "";

            try
            {
                ETABSModelManager manager = new ETABSModelManager();
                List<string> comboNames = manager.GetModelComboNames();
                AvaliableCombos = new ObservableCollection<string>(comboNames);

                List<string> groupNames = manager.GetModelGroupNames();
                AvailableGroups = new ObservableCollection<string>(groupNames);
            }
            catch (Exception)
            {

                ErrorMessage = "Could not connect to ETABS model.";
            }


        }


        private void GetReactions()
        {
            try
            {
                ErrorMessage = "";
                FrameDataExtractor mde = new FrameDataExtractor();
                FrameEnvelopeReactionResult result = mde.GetFrameReactions(SelectedGroup, SelectedCombo, "kip_in");
                V_major_left = result.ShearMajorStart;
                V_major_right = result.ShearMajorEnd;
                M_major_left = result.MomentMajorStart;
                M_major_right = result.MomentMajorEnd;
                P_left = result.AxialForceStart;
                P_right = result.AxialForceEnd;
                V_minor_left = result.ShearMinorStart;
                V_minor_right = result.ShearMinorEnd;
                M_minor_left = result.MomentMinorStart;
                M_minor_right = result.MomentMinorEnd;
            }
            catch (Exception)
            {
                SetDefaultParameters();
                ErrorMessage = "Data extraction failed. Either ETABS is not running, or results are unavailable for selected Group/Combo.";
            }
        }

        private bool canGetForces()
        {
            //Add check if ETABS is running
            return true;
        }
        #endregion

        /// <summary>
        ///Customization of WPF view in Dynamo UI      
        /// </summary>
        public class ReactionExtractorViewCustomization : INodeViewCustomization<GroupReactionExtract>
        {
            public void CustomizeView(GroupReactionExtract model, NodeView nodeView)
            {

                GroupReactionExtractView control = new GroupReactionExtractView();
                control.DataContext = model;
                
               
                nodeView.inputGrid.Children.Add(control);
            }


            public void Dispose()
            {
                //throw new NotImplementedException();
            }
        }
    }


}
