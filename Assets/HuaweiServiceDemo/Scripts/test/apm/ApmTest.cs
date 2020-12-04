using UnityEngine;
using HuaweiService.apm;
using HuaweiService;

namespace ApmTest
{
    public class ApmTest
    {
        public void sendCustomEvent()
        {
            CustomTrace customTrace = APMS.getInstance().createCustomTrace("CustomEvent1");
            if (customTrace != null)
            {
                UnityEngine.Debug.Log("customTrace is not null");
            }

            customTrace.start();
            // code you want trace

            CustomTracePropertyTest(customTrace);
            CustomTraceMeasureTest(customTrace);
            customTrace.stop();
        }

        public void CustomTraceMeasureTest(CustomTrace customTrace)
        {
            UnityEngine.Debug.Log("CustomTraceMeasureTest start");

            customTrace.putMeasure("ProcessingTimes", 0);
            for (int i = 0; i < 100; i++)
            {
                customTrace.incrementMeasure("ProcessingTimes", 1);
            }

            long value = customTrace.getMeasure("ProcessingTimes");
            Debug.Log("Measurename: ProcessingTimes, value: " + value);

            UnityEngine.Debug.Log("CustomTraceMeasureTest success");
        }

        public void CustomTracePropertyTest(CustomTrace customTrace)
        {
            UnityEngine.Debug.Log("CustomTracePropertyTest start");

            customTrace.putProperty("ProcessingResult", "Success");
            customTrace.putProperty("Status", "Normal");
            string prop = customTrace.getProperty("ProcessingResult");
            Debug.Log("get prop name: ProcessingResult, value: " + prop);

            customTrace.putProperty("Time", "2020-02-02");
            customTrace.removeProperty("Time");

            Map propertiesMap = customTrace.getTraceProperties();
            if (propertiesMap != null)
            {
                UnityEngine.Debug.Log("getTraceProperties, map size: " + propertiesMap.keySet().toArray().Length);
            }
            else
            {
                UnityEngine.Debug.Log("getTraceProperties fail");
            }

            UnityEngine.Debug.Log("CustomTracePropertyTest success");
        }


        public void switchAnrMonitorStatus(bool status)
        {
            if (status == false)
            {
                Debug.Log("switch enableAnrMonitor status from false -> true");
                APMS.getInstance().enableAnrMonitor(true);
            }
            else if (status == true)
            {
                Debug.Log("switch enableAnrMonitor status from true -> false");
                APMS.getInstance().enableAnrMonitor(false);
            }
        }

        public void switchCollectionStatus(bool status)
        {
            if (status == false)
            {
                Debug.Log("switch enableCollection status from false -> true");
                APMS.getInstance().enableCollection(true);
            }
            else if (status == true)
            {
                Debug.Log("switch enableCollection status from true -> false");
                APMS.getInstance().enableCollection(false);
            }
        }

        public void addNetworkMonitor()
        {
            string httpUrl = "https://www.developer.huawei.com";
            // 1. Create a networkMeasure for this special network request
            NetworkMeasure networkMeasure = APMS.getInstance().createNetworkMeasure(httpUrl, "GET");
            NetworkPropertyTest(networkMeasure);
            // 2. Add custom property for this network measure
            networkMeasure.putProperty("activityName", "MainActivity");
            // 3. start this network measure
            Debug.Log("networkMeasure start");
            networkMeasure.start();

            networkMeasure.setBytesSent(1024);
            networkMeasure.setContentType("UTF-8");

            Debug.Log("start the fake url request process");
            for (int i = 0; i < 1024; i++)
            {
            }

            int bodysize = 1024;
            // 4. Set response body size for this network measure
            networkMeasure.setBytesReceived(bodysize);

            // 5. Set network response code for this network measure
            int responseCode = 400;
            networkMeasure.setStatusCode(responseCode);

            // 6. Stop this network measure
            networkMeasure.stop();
            Debug.Log("networkMeasure stop");
        }

        public void NetworkPropertyTest(NetworkMeasure networkMeasure)
        {
            UnityEngine.Debug.Log("NetworkPropertyTest start");

            networkMeasure.putProperty("Unity", "unity.com");
            networkMeasure.putProperty("Group", "R&D");

            string value = networkMeasure.getProperty("Unity");
            Debug.Log("get prop name: Unity, value: " + value);

            networkMeasure.removeProperty("Unity");

            Map propertyMap = networkMeasure.getProperties();
            if (propertyMap != null)
            {
                UnityEngine.Debug.Log("NetworkPropertyTest success");
            }
        }
    }
}