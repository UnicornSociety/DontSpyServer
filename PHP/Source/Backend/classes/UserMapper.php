<?php

class UserMapper extends Mapper
{
    public function getUser()
    {
        $stmt = $this->db->query("SELECT * FROM User");
        $results = [];
        while ($row = $stmt->fetch()) {
            $results[] = new UserEntity($row);
        }
        return $results;
    }

    public function getUserByEMail($user_eMail)
    {
        $stmt = $this->db->prepare("SELECT * FROM user WHERE eMail = :user_eMail");
        $result = $stmt->execute(["user_eMail" => $user_eMail]);
        if ($result) {
            return new UserEntity($stmt->fetch());
        }
    }

    public function save(UserEntity $user)
    {
        $stmt = $this->db->prepare("INSERT INTO user(firstname, surname, eMail) VALUES (:firstname, :surname, :eMail)");
        $result = $stmt->execute([
            "firstname" => $user->getFirstname(),
            "surname" => $user->getSurname(),
            "eMail" => $user->getEMail()
        ]);
        if (!$result) {
            throw new Exception("Could not save record");
        }
    }
}
