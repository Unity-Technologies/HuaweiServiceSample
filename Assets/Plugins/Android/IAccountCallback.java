package com.unity.hms.account;
import android.content.Intent;

public interface IAccountCallback {
    void onActivityResult(int requestCode, int resultCode,Intent data);
}
