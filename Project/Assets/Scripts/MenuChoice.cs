using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuChoice {

    public static MenuChoice menuChoice = new MenuChoice();

    private int menuIdx;

    public int GetMenuIdx() {
        return menuIdx;
    }

    public void SetMenuIdx(int idx) {
        menuIdx = idx;
    }

}
