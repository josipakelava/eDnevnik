package hr.fer.oo.ednevnik;

/**
 * Created by luka0 on 22.1.2017..
 */

public class Utils {

    private static String ADDRES = "http://LUKA:3000";
    private static RestApi RestApi;

    public static String getADDRES() {
        return ADDRES;
    }

    public static void setADDRES(String ADDRES) {
        Utils.ADDRES = ADDRES;
    }

    public static RestApi getRestApi() {
        return RestApi;
    }

    public static void setRestApi(RestApi RestApi) {
        Utils.RestApi = RestApi;
    }
}
