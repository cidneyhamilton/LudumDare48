using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cyborg.Dialogue {
    
    public static class Parser {

								public static string Speaker(string line) {
												int index = line.IndexOf(": ");
												if (index == -1) {
																Debug.LogError("No speaker found.");
																return "Narrator";
												} else {
																return line.Substring(0, index);
												}
								}

								public static string Speech(string line) {
												int index = line.IndexOf(": ");
												if (index == -1) {
																Debug.LogError("No speaker found.");
																return line;
												} else {
																return line.Substring(index + 2);
												}
								}

    }
}
