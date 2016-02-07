package apdevelopment.powerofgod.alphaphase.User;

/**
 * Created by apotter96 on 4/8/2015.
 */
public class Json {

   /* public static void Write(UserInfo uI) throws JsonWriteException {
        try {
            JSONObject obj = new JSONObject();
            obj.put("name", uI.name);
            obj.put("email", uI.email);
            obj.put("username", uI.username);
            if (!Files.filesObj()[0].exists())
            {
                System.out.println("Doesn't exist");
                Files.filesObj()[0].mkdirs();
            }
            if (!Files.filesObj()[1].exists())
            {
                Files.filesObj()[1].createNewFile();
            }
            else
            {
                Files.filesObj()[1].delete();
                Write(uI);
            }
            FileWriter file = new FileWriter(Files.filesStr()[1]);

            file.write(obj.toJSONString());
            file.flush();
            file.close();
        } catch (Exception e) {
            throw new JsonWriteException(e);
        }
    }*/
    public static void Read()
    {

    }
}
