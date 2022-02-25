package com.hms.hms_account_activity;
import android.content.Intent;

public interface AccountCallback {
    void onActivityResult(int requestCode, int resultCode,Intent data);
}
