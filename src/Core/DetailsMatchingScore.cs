/*
    Copyright (C) 2018 Fernando Porrino Serrano.
    This software it's under the terms of the GNU Affero General Public License version 3.
    Please, refer to (https://github.com/FherStk/DocumentPlagiarismChecker/blob/master/LICENSE) for further licensing details.
 */
 
using System.Linq;
using System.Collections.Generic;

namespace DocumentPlagiarismChecker.Core
{
    /// <summary>
    /// Contains the mathing score full details.
    /// </summary>
    public class DetailsMatchingScore{         
        /// <summary>
        /// The output display level will be compared with this one in order to determine if the details data must be shown.
        /// </summary>
        /// <value></value>
        public DisplayLevel DisplayLevel {get; private set;}
        
        /// <summary>
        /// Child-level details
        /// </summary>
        /// <value></value>
        public DetailsMatchingScore Child {get; set;}

        /// <summary>
        /// The caption row used in order to display the details of the comparisson.
        /// </summary>
        public string[] DetailsCaption {get; set;}

        /// <summary>
        /// The details row used in order to display the details of the comparisson.
        /// </summary>
        public List<string[]> DetailsData {get; set;} 

        /// <summary>
        /// The matching score between [0,1].
        /// </summary>
        /// <value></value>
        public float Matching {
            get{                
                return (_matching.Count == 0 ? 0 : _matching.Sum(x => x)/_matching.Count);
            }            
        }  
        private List<float> _matching;
           
        /// <summary>
        /// Adds a match socre to the global amount.
        /// </summary>
        /// <param name="match">The match score to add (a number between [0,1])</param>
        public void AddMatch(float match){
            if(match < 0 || match > 1)
                throw new MatchValueNotValid();
            
            _matching.Add(match);
        }

        /// <summary>
        /// Instantiates a new details matching socre object.
        /// </summary>
        public DetailsMatchingScore(DisplayLevel displayLevel = Core.DisplayLevel.COMPARATOR){            
            if(displayLevel < Core.DisplayLevel.COMPARATOR) throw new DisplayLevelNotAllowed();
            else{
                this.DisplayLevel = displayLevel;
                this.DetailsData = new List<string[]>();
                _matching = new List<float>();            
            }            
        }
    }      
}